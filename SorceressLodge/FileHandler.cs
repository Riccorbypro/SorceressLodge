using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using SorceressLibs;

namespace ServerSide {
    class FileHandler {
        private FileStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private string filePathPrime;

        public FileHandler(string filePathParam = "DatabaseChanges.txt") {
            filePathPrime = filePathParam;
        }

        public void WriteData(/*List<MagicUser> magicDataToWrite, Users userData*/ string[] data) {
            try {
                if (File.Exists(filePathPrime)) {
                    stream = new FileStream(filePathPrime, FileMode.Append, FileAccess.Write);
                    writer = new StreamWriter(stream);

                    foreach (string s in data) {
                        writer.WriteLine(s);
                        writer.Flush();
                    }

                    //foreach (MagicUser mItem in magicDataToWrite) {
                    //    writer.WriteLine("[{0}] {1} {2} ({3}) Added to database by {4}", DateTime.Now, mItem.Name, mItem.Surname, mItem.UID, userData.UserName);
                    //    writer.Flush();
                    //}
                } else {
                    stream = new FileStream(filePathPrime, FileMode.OpenOrCreate, FileAccess.Write);
                    writer = new StreamWriter(stream);

                    foreach (string s in data) {
                        writer.WriteLine(s);
                        writer.Flush();
                    }

                    //foreach (MagicUser mItem in magicDataToWrite) {
                    //    writer.WriteLine("[{0}] {1} {2} ({3}) Added to database by {4}", DateTime.Now, mItem.Name, mItem.Surname, mItem.UID, userData.UserName);
                    //    writer.Flush();
                    //}
                }
            } catch (FileNotFoundException) {
                MessageBox.Show("File was not found", "File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (DirectoryNotFoundException) {
                MessageBox.Show("No directory found", "Directory missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (IOException) {
                MessageBox.Show("A Critical Error Occurred", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                writer.Close();
                stream.Close();
            }
        }

        public List<string> ReadData() {
            List<string> dataRaw = new List<string>();

            try {
                stream = new FileStream(filePathPrime, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(stream);

                while (!reader.EndOfStream) {
                    dataRaw.Add(reader.ReadLine());
                }
            } catch (FileNotFoundException) {

            } catch (DirectoryNotFoundException) {

            } catch (IOException) {

            } finally {
                reader.Close();
                stream.Close();
            }

            return dataRaw;
        }
    }
}
