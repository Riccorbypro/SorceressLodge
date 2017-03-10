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
using SorceressLibs;

namespace ClientSide {
    public class Connection {

        private IPAddress ip;
        private Socket client;
        private Thread shutdownWaiter;
        private bool loggedIn = false;

        public bool LoggedIn {
            get {
                return loggedIn;
            }
            set {
                loggedIn = value;
            }
        }

        public Connection(IPAddress ip, Socket s) {
            this.ip = ip;
            client = s;
            byte[] complete = new byte[] { 0x00 };
            client.Send(complete);
            shutdownWaiter = new Thread(ShutdownWaiter);
            shutdownWaiter.Start();
        }

        private void ShutdownWaiter() {
            while (loggedIn) {
                if (!client.Connected) {
                    System.Windows.Forms.MessageBox.Show("Connection Lost. Exiting...", "Shutting Down", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
            }
        }

        public void Shutdown() {
            client.Send(Encoding.ASCII.GetBytes("SHUTDOWN"));
            client.Disconnect(false);
            client.Dispose();
        }

        public Object Comm(object val) {
            shutdownWaiter.Abort();
            Object obj = null;
            try {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                formatter.Serialize(ms, val);
                byte[] toSend = ms.GetBuffer();
                client.Send(toSend);
                byte[] data = new byte[65536];
                try {
                    client.Receive(data);
                    ms = new MemoryStream(data);
                    obj = formatter.Deserialize(ms);
                } catch (Exception ex) { Console.WriteLine(ex.Message); }
            } catch (Exception) { }
            shutdownWaiter = new Thread(ShutdownWaiter);
            shutdownWaiter.Start();
            return obj;
        }
    }
}
