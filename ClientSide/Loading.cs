﻿using System;
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

        private CountdownEvent countdown;
        private int upCount = 0;
        private object lockObj = new object();
        private List<IPHostEntry> hosts = new List<IPHostEntry>();
        const bool resolveNames = true;

        public Loading() {
            InitializeComponent();
            Thread searchThr = new Thread(new ThreadStart(() => {
                countdown = new CountdownEvent(1);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                string ipBase = "10.0.0.";
                for (int i = 1; i < 255; i++) {
                    string ip = ipBase + i.ToString();
                    Ping p = new Ping();
                    p.PingCompleted += new PingCompletedEventHandler(p_PingCompleted);
                    countdown.AddCount();
                    p.SendAsync(ip, 100, ip);
                }
                countdown.Signal();
                countdown.Wait();
                sw.Stop();
                TimeSpan span = new TimeSpan(sw.ElapsedTicks);
                Console.WriteLine("Took {0} milliseconds. {1} hosts active.", sw.ElapsedMilliseconds, upCount);
                Console.WriteLine("Searching for server...");
                foreach (IPHostEntry host in hosts) {
                    IPAddress ip = host.AddressList[0];

                    //send request to server in format:
                    Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                    s.Connect(new IPEndPoint(ip, 3006));
                    string getIP = GetLocalIP();
                    byte[] arr =  {0x3a, 0x6e, 0x30, 0x4f, 0x78, 0x37, 0x4b, 0x51, 0x42, 0x51, 0x65, 0x65, 0x74, 0x44, 0x50, 0x45, 0x69 };
                    List<byte> bytelist = new List<byte>();
                    bytelist.AddRange(Encoding.ASCII.GetBytes(getIP));
                    bytelist.AddRange(arr);
                    byte[] Sendarr = bytelist.ToArray();
                    s.Send(Sendarr);
                    // [CLIENT IP] [KEY]
                    //where CLIENT IP is the machine's IP
                    //and
                    //KEY is a pre-defined byte array
                    //
                    //expect response of de-serialized key from server. format:
                    // [SERVER IP] [KEY]
                    //where SERVER IP is the IP of the server
                    //and
                    //KEY is a string
                    //
                    //if key matches byte array,
                    //use current IP as server, break.


                }
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

        private void p_PingCompleted(object sender, PingCompletedEventArgs e) {
            string ip = (string)e.UserState;
            if (e.Reply != null && e.Reply.Status == IPStatus.Success) {
                if (resolveNames) {
                    string name;
                    try {
                        IPHostEntry hostEntry = Dns.GetHostEntry(ip);
                        hosts.Add(hostEntry);
                        name = hostEntry.HostName;
                    } catch (SocketException ex) {
                        name = "?";
                    }
                    Console.WriteLine("{0} ({1}) is up: ({2} ms)", ip, name, e.Reply.RoundtripTime);
                } else {
                    Console.WriteLine("{0} is up: ({1} ms)", ip, e.Reply.RoundtripTime);
                }
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
