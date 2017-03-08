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

        public Connection(IPAddress ip, Socket s) {
            this.ip = ip;
            client = s;
            byte[] complete = new byte[] { 0x00 };
            client.Send(complete);
            shutdownWaiter = null;
            shutdownWaiter = new Thread(new ThreadStart(() => {
                while (true) {
                    byte[] received = new byte[36];
                    client.Receive(received);
                    if (Encoding.ASCII.GetString(received).Equals("SERVER SHUTTING DOWN!!! 882246467913")) {
                        client.Dispose();
                        System.Windows.Forms.MessageBox.Show("You have been logged out as the server is shutting down.", "Shutting Down", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        Thread.Sleep(5000);
                        Environment.Exit(0);
                    }
                }
            }));
            shutdownWaiter.Start();
        }

        public SerializedObject Comm(SerializedObject val) {
            shutdownWaiter.Suspend();
            SerializedObject obj = new SerializedObject();
            try {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                formatter.Serialize(ms, val);
                byte[] arr = ms.GetBuffer();
                byte[] sendSize = Encoding.ASCII.GetBytes(arr.Length.ToString());
                client.Send(sendSize);
                byte[] confirm = new byte[1];
                client.Receive(confirm);
                if (confirm[0] == 0x00) {
                    client.Send(arr);
                }
                byte[] size = new byte[32];
                client.Receive(size);
                int recSize = int.Parse(Encoding.ASCII.GetString(size));
                client.Send(Encoding.ASCII.GetBytes(recSize.ToString()));
                SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                args.SetBuffer(0, recSize);
                client.ReceiveAsync(args);
                while (client.Available < recSize) {
                    Thread.Sleep(1);
                }
                byte[] data = args.Buffer;
                MemoryStream stream = new MemoryStream(data);
                try {
                    obj = (SerializedObject)formatter.Deserialize(stream);
                } catch (Exception) { } finally {
                    stream.Dispose();
                    ms.Dispose();
                }
            } catch (Exception) { }
            shutdownWaiter.Resume();
            return obj;
        }
    }
}
