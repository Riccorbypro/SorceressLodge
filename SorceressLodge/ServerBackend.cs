using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using SorceressLibs;

namespace ServerSide {
    class ServerBackend {

        private Dictionary<Socket, Thread> commsThreads = new Dictionary<Socket, Thread>();
        public bool isRunning = false;
        private Users user;
        private Main main;
        private Thread clientAccepter;
        private Backend b;
        private Socket s;
        private Thread waitThread = null, stopThread = null;

        public ServerBackend(Users user, bool autoStart) {
            this.user = user;
            b = new Backend();
            main = new Main(autoStart);
            main.Show();
            waitThread = new Thread(new ThreadStart(() => {
                while (!main.Started) {
                    Thread.Sleep(25);
                }
                Thread startThread = new Thread(new ThreadStart(Start));
                startThread.Start();
            }));
            stopThread = new Thread(new ThreadStart(() => {
                while (main.started) {
                    Thread.Sleep(25);
                }
                Thread stoppingThread = new Thread(new ThreadStart(Stop));
                stoppingThread.Start();
            }));
            if (autoStart) {
                Start();
            } else {
                waitThread.Start();
            }
        }

        public void Start() {
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);//socket()
            s.Bind(new IPEndPoint(IPAddress.Parse(GetLocalIPAddress()), 3006));//Bind()
            s.Listen(32);
            main.AppendWorker("Starting Server...");
            isRunning = true;
            clientAccepter = new Thread(new ThreadStart(() => {
                try {
                    while (isRunning) {
                        Socket client = null;
                        if (!commsThreads.Keys.Contains(client = s.Accept())) {
                            byte[] init = new byte[32];
                            client.Receive(init);
                            int size = int.Parse(Encoding.ASCII.GetString(init));
                            byte[] accept = new byte[] { 0x00 };
                            client.Send(accept);
                            byte[] handshake = new byte[size];
                            client.Receive(handshake);
                            string str = Encoding.ASCII.GetString(handshake);
                            byte[] reply = Encoding.ASCII.GetBytes(str);
                            client.Send(reply);
                            byte[] complete = new byte[1];
                            client.Receive(complete);
                            if (complete[0] == 0x00) {
                                commsThreads.Add(client, new Thread(new ThreadStart(() => CommsThread(client))));
                                main.AppendWorker(string.Format("Client {0} connected at {1}.", client.RemoteEndPoint.ToString(), DateTime.Now));
                            }
                        }
                    }
                } catch (Exception) { }
            }));
            main.AppendWorker("Server Started Successfully.");
            waitThread = new Thread(WaitThread);
            stopThread = new Thread(StopThread);
            if (stopThread.ThreadState != ThreadState.Running) {
                stopThread.Start();
            }
            if (waitThread.ThreadState != ThreadState.Stopped) {
                waitThread.Abort();
            }
            clientAccepter.Start();
        }

        private void WaitThread() {
            while (!main.Started) {
                Thread.Sleep(25);
            }
            Thread startThread = new Thread(new ThreadStart(Start));
            startThread.Start();
        }

        private void StopThread() {
            while (main.started) {
                Thread.Sleep(25);
            }
            Thread stoppingThread = new Thread(new ThreadStart(Stop));
            stoppingThread.Start();
        }

        public void Stop() {
            try {
                main.AppendWorker("Stopping Server...");
                isRunning = false;

                foreach (var thread in commsThreads) {
                    thread.Key.Send(Encoding.ASCII.GetBytes("SERVER SHUTTING DOWN!!! 882246467913"));
                    thread.Value.Abort();
                }

                commsThreads = new Dictionary<Socket, Thread>();

                s.Dispose();

                waitThread = new Thread(WaitThread);
                stopThread = new Thread(StopThread);
                if (waitThread.ThreadState != ThreadState.Running) {
                    waitThread.Start();
                }
                if (stopThread.ThreadState != ThreadState.Stopped || stopThread.ThreadState != ThreadState.Unstarted) {
                    stopThread.Abort();
                }
                main.AppendWorker("Server Stopped Successfully");
                if (main.closed) {
                    Environment.Exit(0);
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                main.AppendWorker("Server Failed to Stop - Killing...");
                Thread.Sleep(5000);
                Environment.Exit(1);
            }
        }

        public void CommsThread(Socket client) {
            while (true) {
                try {
                    byte[] size = new byte[32];
                    client.Receive(size);
                    int recSize = int.Parse(Encoding.ASCII.GetString(size));
                    byte[] data = new byte[recSize];
                    client.Receive(data);
                    MemoryStream stream = new MemoryStream(data);
                    MemoryStream ms = new MemoryStream();
                    try {
                        BinaryFormatter formatter = new BinaryFormatter();
                        object o = formatter.Deserialize(stream);
                        try {
                            SerializedObject obj = (SerializedObject)o;
                            SerializedObject val = null;
                            val = new SerializedObject(obj.ObjectClass, obj.ObjectMethod, new object[] { b.GetType().GetMethod(obj.ObjectMethod).Invoke(b, obj.ObjectS) }, obj.User);
                            if (val != null) {
                                formatter.Serialize(ms, val);
                                byte[] arr = ms.GetBuffer();
                                byte[] sendSize = Encoding.ASCII.GetBytes(arr.Length.ToString());
                                client.Send(sendSize);
                                Thread.Sleep(10);
                                client.Send(arr);
                            }
                        } catch (Exception) {
                            try {
                                Users user = (Users)o;
                                Users result = LoginBackend.LoginClient(user.UserName, user.Password);
                                ms = new MemoryStream();
                                formatter.Serialize(ms, result);
                                byte[] toSend = ms.GetBuffer();
                                byte[] sizetoSend = Encoding.ASCII.GetBytes(toSend.Length.ToString());
                                IAsyncResult ASRes;
                                client.BeginSend(sizetoSend,0,toSend.Length,SocketFlags.None,AsyncCallback(ASRes));
                            } catch (Exception) {
                                try {
                                    MagicUser user = (MagicUser)o;
                                } catch (Exception) { }
                            }
                        }
                    } catch (Exception) { } finally {
                        stream.Dispose();
                        ms.Dispose();
                    }
                } catch (Exception) { }
            }
        }

        public static string GetLocalIPAddress() {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList) {
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    return ip.ToString();
                }
            }
            throw new Exception("IP not found");
        }
    }
}
