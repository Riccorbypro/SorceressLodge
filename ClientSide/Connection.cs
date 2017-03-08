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
        private byte[] tempByteArr;
        private ManualResetEvent connectDone = new ManualResetEvent(false);
        private ManualResetEvent sendDone = new ManualResetEvent(false);
        private ManualResetEvent receiveDone = new ManualResetEvent(false);

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
            Send(client, new byte[] { 0x00 });
            sendDone.WaitOne();
            shutdownWaiter = new Thread(ShutdownWaiter);
            shutdownWaiter.Start();
        }

        private void ShutdownWaiter() {
            while (loggedIn) {
                Receive(client);
                receiveDone.WaitOne();
                if (Encoding.ASCII.GetString(tempByteArr).Equals("SERVER SHUTTING DOWN!!! 882246467913")) {
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
                Send(client, arr);
                sendDone.WaitOne();
                Receive(client);
                receiveDone.WaitOne();
                byte[] data = tempByteArr;
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

        private void Receive(Socket client) {
            try {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
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
            List<byte> tempLst = new List<byte>();
            tempLst.AddRange(data);
            tempLst.AddRange(new byte[] { 0x47, 0x33, 0x37, 0x70, 0x61, 0x4d, 0x49, 0x37, 0x6a, 0x48, 0x6c,
                    0x47, 0x32, 0x64, 0x30, 0x61, 0x35, 0x49, 0x52, 0x6b, 0x47, 0x44, 0x66, 0x51, 0x44, 0x50,
                    0x52, 0x57, 0x44, 0x4c, 0x4d, 0x6e, 0x49, 0x57, 0x32, 0x61, 0x61, 0x42, 0x38, 0x6d, 0x58,
                    0x7a, 0x6a, 0x73, 0x68, 0x45, 0x37, 0x75, 0x6e, 0x41, 0x56, 0x42, 0x4c, 0x68, 0x71, 0x48,
                    0x6d, 0x4f, 0x4e, 0x6a, 0x41, 0x75, 0x74, 0x39, 0x46, 0x32, 0x52, 0x78, 0x35, 0x62, 0x72,
                    0x4f, 0x72, 0x56, 0x47, 0x77, 0x4e, 0x63, 0x72, 0x6d, 0x36, 0x72, 0x73, 0x38, 0x68, 0x50,
                    0x70, 0x77, 0x30, 0x79, 0x55, 0x75, 0x50, 0x54, 0x6e, 0x6b, 0x69, 0x72, 0x4e, 0x45 });
            byte[] finalData = tempLst.ToArray();
            client.BeginSend(finalData, 0, finalData.Length, 0, new AsyncCallback(SendCallback), client);
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
    }
}
