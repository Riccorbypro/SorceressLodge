using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorceressLodge {
    class FileHandler {
        private FileStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private string filePath;

        public FileHandler(string filePath) {
            this.filePath = filePath;
        }

        public void WriteData(List<string> dataToWrite) {
            try {
                stream = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(stream);

                foreach (string item in dataToWrite) {
                    writer.WriteLine(item);
                    writer.Flush();
                }

            } catch (FileNotFoundException) {
                Console.WriteLine("File not Found");
            } catch (DirectoryNotFoundException) {
                Console.WriteLine("Directory Missing");
            } catch (IOException) {
                Console.WriteLine("Critical Error");
            } finally {
                writer.Close();
                stream.Close();
            }
        }

        public void WriteDataAppend(List<string> dataToWrite) {
            try {
                stream = new FileStream(this.filePath, FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(stream);

                foreach (string item in dataToWrite) {
                    writer.WriteLine(item);
                    writer.Flush();
                }

            } catch (FileNotFoundException) {
                Console.WriteLine("File not Found");
            } catch (DirectoryNotFoundException) {
                Console.WriteLine("Directory Missing");
            } catch (IOException) {
                Console.WriteLine("Critical Error");
            } finally {
                writer.Close();
                stream.Close();
            }
        }

        public List<List<string>> ReadData() {
            List<List<string>> dataRaw = new List<List<string>>();
            IEnumerable<string> files = Directory.EnumerateFiles(filePath);
            foreach (string s in files) {
                try {
                    string[] sArr = s.Split('.');
                    switch (sArr[sArr.Length - 1]) {
                        case "txt":
                            stream = new FileStream(s, FileMode.Open, FileAccess.Read);
                            reader = new StreamReader(stream);
                            List<string> tempList = new List<string>();

                            while (!reader.EndOfStream) {
                                tempList.Add(reader.ReadLine());
                            }
                            dataRaw.Add(tempList);
                            break;
                        default:
                            break;
                    }
                } catch (FileNotFoundException) {
                    Console.WriteLine("File not Found");
                } catch (DirectoryNotFoundException) {
                    Console.WriteLine("Directory Missing");
                } catch (IOException) {
                    Console.WriteLine("Critical Error");
                } finally {
                    reader.Close();
                    stream.Close();
                }
            }
            foreach (string s in files) {
                try {
                    string[] sArr = s.Split('.');
                    switch (sArr[sArr.Length - 1]) {
                        case "jpg":
                            stream = new FileStream(s, FileMode.Open, FileAccess.Read);
                            Bitmap bitmap = new Bitmap(stream);

                            foreach (List<string> sList in dataRaw) {
                                
                            }

                            break;
                        default:
                            break;
                    }
                } catch (FileNotFoundException) {
                    Console.WriteLine("File not Found");
                } catch (DirectoryNotFoundException) {
                    Console.WriteLine("Directory Missing");
                } catch (IOException) {
                    Console.WriteLine("Critical Error");
                } finally {
                    reader.Close();
                    stream.Close();
                }
            }

            return dataRaw;
        }

    }
}
