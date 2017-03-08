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
                byte[] received = new byte[36];
                client.Receive(received);
                if (Encoding.ASCII.GetString(received).Equals("SERVER SHUTTING DOWN!!! 882246467913")) {
                    client.Dispose();
                    System.Windows.Forms.MessageBox.Show("You have been logged out.\nThe server is shutting down.", "Shutting Down", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
            }
        }

        public SerializedObject Comm(SerializedObject val) {
            shutdownWaiter.Abort();
            SerializedObject obj = new SerializedObject();
            try {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                formatter.Serialize(ms, val);
                byte[] arr = ms.GetBuffer();
                byte[] sendSize = Encoding.ASCII.GetBytes(arr.Length.ToString());
                client.Send(sendSize);
                client.Send(arr);
                byte[] size = new byte[32];
                client.Receive(size);
                int recSize = int.Parse(Encoding.ASCII.GetString(size));
                byte[] data = new byte[recSize];
                client.Receive(data);
                MemoryStream stream = new MemoryStream(data);
                try {
                    obj = (SerializedObject)formatter.Deserialize(stream);
                } catch (Exception) { } finally {
                    stream.Dispose();
                    ms.Dispose();
                }
            } catch (Exception) { }
            shutdownWaiter = new Thread(ShutdownWaiter);
            shutdownWaiter.Start();
            return obj;
        }

        public object SendReceive(object o) {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            formatter.Serialize(ms, o);
            byte[] toSend = ms.GetBuffer();
            client.Send(Encoding.ASCII.GetBytes(toSend.Length.ToString()));
            Thread.Sleep(100);
            client.Send(toSend);
            byte[] size = new byte[32];
            client.Receive(size);
            int recSize = int.Parse(Encoding.ASCII.GetString(size));
            byte[] data = new byte[recSize];
            client.Receive(data);
            ms = new MemoryStream(data);
            object obj = formatter.Deserialize(ms);
            return obj;
        }
    }
}
