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

        private List<Socket> clients = new List<Socket>();
        private Dictionary<Socket, Thread> commsThreads = new Dictionary<Socket, Thread>();
        public bool isRunning = false;
        private Users user;
        private Main main;
        private Thread clientAccepter;
        private Backend b;
        private Socket s;

        public ServerBackend(Users user, bool autoStart) {
            this.user = user;
            b = new Backend();
            main = new Main(autoStart);
            main.Show();
            Thread waitThread = null;
            Thread stopThread = null;
            waitThread = new Thread(new ThreadStart(() => {
                while (!main.Started) {
                    Thread.Sleep(25);
                }
                Start();
                stopThread.Start();
                waitThread.Abort();
            }));
            stopThread = new Thread(new ThreadStart(() => {
                while (main.started) {
                    Thread.Sleep(25);
                }
                Stop();
                waitThread.Start();
                stopThread.Abort();
            }));
            waitThread.Start();
        }

        public void Start() {
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);//socket()
            s.Bind(new IPEndPoint(IPAddress.Parse(GetLocalIPAddress()), 3006));//Bind()
            s.Listen(32);
            main.AppendWorker("Starting Server...");

            clientAccepter = new Thread(new ThreadStart(() => {
                while (true) {
                    Socket client = null;
                    if (!clients.Contains(client = s.Accept())) {
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
                            clients.Add(client);
                            commsThreads.Add(client, new Thread(new ThreadStart(() => CommsThread(client))));
                            main.AppendWorker(string.Format("Client {0} connected at {1}.", client.RemoteEndPoint.ToString(), DateTime.Now));
                        }
                        //}
                    }
                }
            }));
            clientAccepter.Start();
            main.AppendWorker("Server Started Successfully.");
        }

        public void Stop() {
            main.AppendWorker("Stopping Server...");

            clientAccepter.Abort();

            foreach (Socket client in clients) {
                client.Send(Encoding.ASCII.GetBytes("SERVER SHUTTING DOWN!!! 882246467913"));
            }

            clients.Clear();

            foreach (KeyValuePair<Socket, Thread> thread in commsThreads) {
                thread.Value.Abort();
            }

            commsThreads.Clear();

            main.AppendWorker("Server Stopped Successfully");
        }

        public void CommsThread(Socket client) {
            while (true) {
                try {
                    byte[] size = new byte[32];
                    client.Receive(size);
                    int recSize = int.Parse(Encoding.ASCII.GetString(size));
                    client.Send(new byte[] { 0x00 });
                    SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                    args.SetBuffer(0, recSize);
                    client.ReceiveAsync(args);
                    while (client.Available < recSize) {
                        Thread.Sleep(1);
                    }
                    byte[] data = args.Buffer;
                    MemoryStream stream = new MemoryStream(data);
                    MemoryStream ms = new MemoryStream();
                    try {
                        BinaryFormatter formatter = new BinaryFormatter();
                        SerializedObject obj = (SerializedObject)formatter.Deserialize(stream);
                        SerializedObject val = null;
                        switch (obj.ObjectClass) {
                            case "LoginBackend":
                                val = new SerializedObject(obj.ObjectClass, obj.ObjectMethod, new object[] { LoginBackend.LoginClient(obj.ObjectS[0].ToString(), obj.ObjectS[1].ToString()) }, obj.User);
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
