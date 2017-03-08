using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClientSide {
    public partial class Loading : Form {

        delegate void SetTextCallback(string text);
        delegate void CallbackHide();
        delegate void CallbackLogin(IPAddress ip, Socket client);
        private ManualResetEvent connectDone = new ManualResetEvent(false);
        private ManualResetEvent sendDone = new ManualResetEvent(false);
        private ManualResetEvent receiveDone = new ManualResetEvent(false);
        private CountdownEvent countdown;
        private int upCount = 0;
        private object lockObj = new object();
        private List<string> hosts = new List<string>();
        const bool resolveNames = true;
        private Login login;
        private Thread searchThr = null;
        private byte[] tempByteArr;

        public Loading() {
            InitializeComponent();
            searchThr = new Thread(new ThreadStart(() => {
                countdown = new CountdownEvent(1);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                string[] localIP = GetLocalIP().Split('.');
                string ipBase = localIP[0] + "." + localIP[1] + "." + localIP[2] + ".";
                for (int i = 1; i < 255; i++) {
                    string ip = ipBase + i.ToString();
                    Ping p = new Ping();
                    p.PingCompleted += new PingCompletedEventHandler(p_PingCompleted);
                    countdown.AddCount();
                    p.SendAsync(ip, 50, ip);
                }
                countdown.Signal();
                countdown.Wait();
                sw.Stop();
                TimeSpan span = new TimeSpan(sw.ElapsedTicks);
                Console.WriteLine("Took {0} milliseconds. {1} hosts active.", sw.ElapsedMilliseconds, upCount);
                setProgressTextWorker(string.Format("Found {0} hosts. Querying server...", upCount));
                Thread.Sleep(5000);
                Console.WriteLine("Searching for server...");
                foreach (string host in hosts) {
                    try {
                        IPAddress ip = IPAddress.Parse(host);

                        //send request to server in format:
                        // [CLIENT IP]:[KEY]
                        //where CLIENT IP is the machine's IP
                        //and
                        //KEY is a pre-defined byte array

                        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

                        s.BeginConnect(new IPEndPoint(ip, 3006), new AsyncCallback(ConnectCallback), s);
                        connectDone.WaitOne();
                        byte[] arr = { 0x6e, 0x30, 0x4f, 0x78, 0x37, 0x4b, 0x51, 0x42, 0x51, 0x65, 0x65, 0x74, 0x44, 0x50, 0x45, 0x69 };
                        Send(s, arr);
                        sendDone.WaitOne();
                        Receive(s);
                        receiveDone.WaitOne();
                        byte[] confirm = tempByteArr;
                        if (confirm[0] == 0x00) {
                            Console.WriteLine(ip.ToString() + " is server - sending key...");
                            setProgressTextWorker(string.Format("Found possible server at {0}. Initiating Handshake...", ip.ToString()));
                            Send(s, arr);
                            sendDone.WaitOne();

                            //expect response of de-serialized key from server. format:
                            //[KEY]
                            //where KEY is a string

                            Receive(s);
                            receiveDone.WaitOne();
                            string received = Encoding.ASCII.GetString(tempByteArr);

                            //if key matches byte array,
                            //use current IP as server, break.

                            if (received.Equals(Encoding.ASCII.GetString(arr))) {
                                Console.WriteLine("Server Handshake Complete: Beginning Login Process...");
                                setProgressTextWorker("Server Handshake Complete: Beginning Login Process...");
                                Thread.Sleep(1500);
                                MakeLoginWorker(ip, s);
                                HideFrameWorker();
                                break;
                            }
                        } else {
                            Console.WriteLine(ip.ToString() + " is not server.");
                        }
                    } catch (Exception) { }
                }
                if (login == null) {
                    setMainTextWorker("    :(");
                    setProgressTextWorker("  No suitable servers were found. Program exiting...");
                    Thread.Sleep(2500);
                    Environment.Exit(0);
                }
            }));
        }

        private void MakeLoginWorker(IPAddress ip, Socket client) {
            MakeLogin(ip, client);
        }

        private void MakeLogin(IPAddress ip, Socket client) {
            if (InvokeRequired) {
                CallbackLogin d = new CallbackLogin(MakeLoginWorker);
                Invoke(d, new object[] { ip, client });
            } else {
                login = new Login(ip, client);
                login.Show();
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
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
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

        private void Send(Socket client, byte[] data) {
            client.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), client);
        }

        private void SendCallback(IAsyncResult ar) {
            try {
                Socket client = (Socket)ar.AsyncState;
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);
                sendDone.Set();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        private void ConnectCallback(IAsyncResult ar) {
            try {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);
                Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());
                connectDone.Set();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public string GetLocalIP() {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList) {
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    return ip.ToString();
                }
            }
            throw new Exception("IP Not Found");
        }

        private void HideFrameWorker() {
            HideFrame();
        }

        private void HideFrame() {
            if (InvokeRequired) {
                CallbackHide d = new CallbackHide(HideFrameWorker);
                Invoke(d);
            } else {
                Hide();
            }
        }

        private void setProgressTextWorker(string s) {
            setProgressText(s);
        }

        private void setProgressText(string s) {
            if (progressLabel.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(setProgressTextWorker);
                Invoke(d, new object[] { s });
            } else {
                progressLabel.Text = s;
            }
        }

        private void setMainTextWorker(string s) {
            setMainText(s);
        }

        private void setMainText(string s) {
            if (label1.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(setMainTextWorker);
                Invoke(d, new object[] { s });
            } else {
                TopMost = true;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                Font f = new Font(label1.Font.FontFamily, 200, FontStyle.Bold);
                label1.Font = f;
                label1.TextAlign = ContentAlignment.MiddleLeft;
                label1.ForeColor = Color.White;
                label1.BackColor = Color.Transparent;
                BackColor = Color.DodgerBlue;
                BackgroundImage = null;
                progressBar1.Visible = false;
                label1.Text = s;
                label1.Size = new Size(1024, 600);
                progressLabel.ForeColor = Color.White;
                progressLabel.BackColor = Color.Transparent;
                f = new Font(progressLabel.Font.FontFamily, 50, FontStyle.Regular);
                progressLabel.TextAlign = ContentAlignment.TopLeft;
                progressLabel.Font = f;
                progressLabel.Size = new Size(1024, 300);
            }
        }

        private void p_PingCompleted(object sender, PingCompletedEventArgs e) {
            string ip = (string)e.UserState;
            if (e.Reply != null && e.Reply.Status == IPStatus.Success) {
                string name;
                try {
                    IPHostEntry hostEntry = Dns.GetHostEntry(ip);
                    name = hostEntry.HostName;
                } catch (SocketException) {
                    name = "?";
                }
                hosts.Add(ip);
                Console.WriteLine("{0} ({1}) is up: ({2} ms)", ip, name, e.Reply.RoundtripTime);
                lock (lockObj) {
                    upCount++;
                }
            } else if (e.Reply == null) {
                Console.WriteLine("Pinging {0} failed. (Null Reply object?)", ip);
            }
            countdown.Signal();
        }

        private void StartButt_Click(object sender, EventArgs e) {
            StartButt.Visible = false;
            label1.Visible = true;
            progressBar1.Visible = true;
            progressLabel.Visible = true;
            searchThr.Start();
        }
    }
    public class StateObject {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public List<byte> data = new List<byte>();
    }
}
