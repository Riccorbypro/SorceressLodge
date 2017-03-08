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
        private CountdownEvent countdown;
        private int upCount = 0;
        private object lockObj = new object();
        private List<string> hosts = new List<string>();
        const bool resolveNames = true;

        public Loading() {
            InitializeComponent();
            Thread searchThr = null;
            searchThr = new Thread(new ThreadStart(() => {
                countdown = new CountdownEvent(1);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                string ipBase = "10.0.0.";
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
                    string[] sub = host.Split('.');
                    IPAddress ip = new IPAddress(new byte[] { (byte)int.Parse(sub[0]), (byte)int.Parse(sub[1]), (byte)int.Parse(sub[2]), (byte)int.Parse(sub[3]) });

                    //send request to server in format:
                    // [CLIENT IP]:[KEY]
                    //where CLIENT IP is the machine's IP
                    //and
                    //KEY is a pre-defined byte array

                    Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                    s.Connect(new IPEndPoint(ip, 3006));
                    string getIP = GetLocalIP();
                    byte[] arr = { 0x6e, 0x30, 0x4f, 0x78, 0x37, 0x4b, 0x51, 0x42, 0x51, 0x65, 0x65, 0x74, 0x44, 0x50, 0x45, 0x69 };
                    List<byte> bytelist = new List<byte>();
                    bytelist.AddRange(Encoding.ASCII.GetBytes(getIP));
                    bytelist.Add(0x3a);
                    bytelist.AddRange(arr);
                    byte[] Sendarr = bytelist.ToArray();
                    int size = Sendarr.Length;
                    byte[] bArrSize = Encoding.ASCII.GetBytes(size.ToString());
                    s.Send(bArrSize);
                    byte[] confirm = new byte[1];
                    s.Receive(confirm);
                    if (confirm[0] == 0x00) {
                        Console.WriteLine(ip.ToString() + "is server - sending key...");
                        setProgressTextWorker(string.Format("Found possible server at {0}. Initiating Handshake...", ip.ToString()));
                        Thread.Sleep(5000);
                        s.Send(Sendarr);

                        //expect response of de-serialized key from server. format:
                        // [SERVER IP]:[KEY]
                        //where SERVER IP is the IP of the server
                        //and
                        //KEY is a string

                        int count = Encoding.ASCII.GetByteCount(ip.ToString());
                        count += arr.Length + 1;
                        byte[] recBArr = new byte[count];
                        s.Receive(recBArr);
                        string received = Encoding.ASCII.GetString(recBArr);
                        string[] recArr = received.Split(':');

                        //if key matches byte array,
                        //use current IP as server, break.

                        if (recArr[0].Equals(ip.ToString()) && Encoding.ASCII.GetBytes(recArr[1]).Equals(arr)) {
                            Console.WriteLine("Server Handshake Complete: Beginning Login Process...");
                            setProgressTextWorker("Server Handshake Complete: Beginning Login Process...");
                            Thread.Sleep(5000);
                            new Login(ip).Show();
                            this.Visible = false;
                            searchThr.Abort();
                        }
                    } else {
                        Console.WriteLine(ip.ToString() + " is not server.");
                    }
                }
                setMainTextWorker("    :(");
                setProgressTextWorker("  No suitable servers were found. Program exiting...");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }));
            searchThr.Start();
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
                    Console.WriteLine("{0} ({1}) is up: ({2} ms)", ip, name, e.Reply.RoundtripTime);
                lock (lockObj) {
                    upCount++;
                }
            } else if (e.Reply == null) {
                Console.WriteLine("Pinging {0} failed. (Null Reply object?)", ip);
            }
            countdown.Signal();
        }
    }
}
