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
        private byte[] tempByteArr;
        private Socket tempClient;
        public ManualResetEvent allDone = new ManualResetEvent(false);
        private ManualResetEvent receiveDone = new ManualResetEvent(false);

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
            s.Listen(100);
            byte[] bytes = new byte[1024];
            main.AppendWorker("Starting Server...");
            isRunning = true;
            clientAccepter = new Thread(new ThreadStart(() => {
                try {
                    while (isRunning) {
                        allDone.Reset();
                        s.BeginAccept(new AsyncCallback(AcceptCallback), s);
                        allDone.WaitOne();
                        Socket tempClient1 = tempClient;
                        if (!commsThreads.Keys.Contains(tempClient1)) {
                            byte[] key;
                            byte[] arr = { 0x6e, 0x30, 0x4f, 0x78, 0x37, 0x4b, 0x51, 0x42, 0x51, 0x65, 0x65, 0x74, 0x44, 0x50, 0x45, 0x69 };
                            bool authenticated = true;
                            Receive(tempClient1);
                            receiveDone.WaitOne();
                            key = tempByteArr;
                            for (int i = 0; i < 16; i++) {
                                if (key[i] != arr[i]) {
                                    authenticated = false;
                                    break;
                                }
                            }
                            if (authenticated) {
                                Send(tempClient1, new byte[] { 0x00 });
                                Receive(tempClient1);
                                receiveDone.WaitOne();
                                byte[] complete = tempByteArr;
                                if (complete[0] == 0x00) {
                                    commsThreads.Add(tempClient1, new Thread(new ThreadStart(() => CommsThread(tempClient1))));
                                    main.AppendWorker(string.Format("{0} - Client {1} connected.", DateTime.Now, tempClient1.RemoteEndPoint.ToString()));
                                }
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
                                client.BeginSend(sizetoSend, 0, toSend.Length, SocketFlags.None, new AsyncCallback(SendCallback), client);
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

        private void Receive(Socket client) {
            try {
                StateObject state = new StateObject();
                state.workSocket = client;
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        private void ReceiveCallback(IAsyncResult ar) {
            try {
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0) {
                    state.data.AddRange(state.buffer);
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                } else {
                    if (state.data.Count > 1) {
                        tempByteArr = state.data.ToArray();
                    }
                    receiveDone.Set();
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public void AcceptCallback(IAsyncResult ar) {
            try {
                allDone.Set();
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);
                tempClient = handler;
            } catch (Exception) { }
        }

        public void Read(Socket socket) {
            StateObject state = new StateObject();
            state.workSocket = socket;
            socket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        public void ReadCallback(IAsyncResult ar) {
            byte[] content = new byte[1024];

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket.   
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0) {
                // There  might be more data, so store the data received so far.  
                state.data.AddRange(state.buffer);

                // Check for end-of-file tag. If it is not there, read   
                // more data.  
                content = state.data.ToArray();
                byte[] EOFTag = new byte[] { 0x47, 0x33, 0x37, 0x70, 0x61, 0x4d, 0x49, 0x37, 0x6a, 0x48, 0x6c,
                    0x47, 0x32, 0x64, 0x30, 0x61, 0x35, 0x49, 0x52, 0x6b, 0x47, 0x44, 0x66, 0x51, 0x44, 0x50,
                    0x52, 0x57, 0x44, 0x4c, 0x4d, 0x6e, 0x49, 0x57, 0x32, 0x61, 0x61, 0x42, 0x38, 0x6d, 0x58,
                    0x7a, 0x6a, 0x73, 0x68, 0x45, 0x37, 0x75, 0x6e, 0x41, 0x56, 0x42, 0x4c, 0x68, 0x71, 0x48,
                    0x6d, 0x4f, 0x4e, 0x6a, 0x41, 0x75, 0x74, 0x39, 0x46, 0x32, 0x52, 0x78, 0x35, 0x62, 0x72,
                    0x4f, 0x72, 0x56, 0x47, 0x77, 0x4e, 0x63, 0x72, 0x6d, 0x36, 0x72, 0x73, 0x38, 0x68, 0x50,
                    0x70, 0x77, 0x30, 0x79, 0x55, 0x75, 0x50, 0x54, 0x6e, 0x6b, 0x69, 0x72, 0x4e, 0x45 };
                int EOFPos = -1;
                bool EOFFound = false;
                for (int i = 0; i < content.Length; i++) {
                    if (content[i] == EOFTag[EOFPos + 1]) {
                        EOFPos++;
                    } else {
                        EOFPos = -1;
                    }
                    if (EOFPos == 98 && i == content.Length - 1) {
                        EOFFound = true;
                    }
                }

                if (EOFFound) {
                    Console.WriteLine("Read {0} bytes from socket.", content.Length);
                    tempByteArr = new byte[content.Length - 100];
                    for (int i = 0; i < tempByteArr.Length; i++) {
                        tempByteArr[i] = content[i];
                    }

                } else {
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
            }
        }

        private void Send(Socket handler, byte[] data) {
            handler.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        private void SendCallback(IAsyncResult ar) {
            try {
                Socket handler = (Socket)ar.AsyncState;
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
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

    public class StateObject {
        // Client  socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 1024;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public List<byte> data = new List<byte>();
    }
}
