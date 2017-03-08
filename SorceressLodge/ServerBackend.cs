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

            clientAccepter = new Thread(new ThreadStart(() => {
                while (true) {
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
                        //if (strSpl.Equals(IPAddress.Parse(client.RemoteEndPoint.ToString()).ToString())) {
                        //string ret = str;
                        byte[] reply = Encoding.ASCII.GetBytes(str);
                        client.Send(reply);
                        byte[] complete = new byte[1];
                        client.Receive(complete);
                        if (complete[0] == 0x00) {
                            commsThreads.Add(client, new Thread(new ThreadStart(() => CommsThread(client))));
                            main.AppendWorker(string.Format("Client {0} connected at {1}.", client.RemoteEndPoint.ToString(), DateTime.Now));
                        }
                        //}
                    }
                }
            }));
            clientAccepter.Start();
            main.AppendWorker("Server Started Successfully.");

            stopThread.Start();
            waitThread.Abort();
        }

        public void Stop() {
            try {
                main.AppendWorker("Stopping Server...");

                clientAccepter.Abort();

                foreach (KeyValuePair<Socket, Thread> thread in commsThreads) {
                    thread.Key.Dispose();
                    thread.Value.Abort();
                }

                commsThreads.Clear();

                main.AppendWorker("Server Stopped Successfully");
                waitThread.Start();
                stopThread.Abort();
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
                    client.Send(new byte[] { 0x00 });
                    byte[] data = new byte[recSize];
                    client.Receive(data);
                    MemoryStream stream = new MemoryStream(data);
                    MemoryStream ms = new MemoryStream();
                    try {
                        BinaryFormatter formatter = new BinaryFormatter();
                        SerializedObject obj = (SerializedObject)formatter.Deserialize(stream);
                        SerializedObject val = null;
                        switch (obj.ObjectClass) {
                            case "LoginBackend":
                                val = new SerializedObject("Users", "", new object[] { LoginBackend.LoginClient(obj.ObjectS[0].ToString(), obj.ObjectS[1].ToString()) }, obj.User);
                                break;
                            default:
                                val = new SerializedObject(obj.ObjectClass, obj.ObjectMethod, new object[] { b.GetType().GetMethod(obj.ObjectMethod).Invoke(b, obj.ObjectS) }, obj.User);
                                break;
                        }
                        if (val != null) {
                            formatter.Serialize(ms, val);
                            byte[] arr = ms.GetBuffer();
                            byte[] sendSize = Encoding.ASCII.GetBytes(arr.Length.ToString());
                            client.Send(sendSize);
                            byte[] confirm = new byte[1];
                            client.Receive(confirm);
                            if (confirm[0] == 0x00) {
                                client.Send(arr);
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
