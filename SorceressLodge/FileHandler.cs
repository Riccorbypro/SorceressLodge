using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SorceressLodge {
    class FileHandler {
        private FileStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private string filePathPrime;

        public FileHandler(string filePathParam = "DatabaseChanges.txt") {
            this.filePathPrime = filePathParam;
        }

        public void WriteData(List<MagicUser> dataToWrite) {
            try {
                stream = new FileStream(this.filePathPrime, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(stream);

                foreach (MagicUser item in dataToWrite) {
                    writer.WriteLine(item);
                    writer.Flush();
                }

            } catch (FileNotFoundException) {
                Console.WriteLine("fILE mISSING");
            } catch (DirectoryNotFoundException) {
                Console.WriteLine("dIRECTORY mISSING");
            } catch (IOException) {
                Console.WriteLine("cRITICAL eRROR");
            } finally {
                writer.Close();
                stream.Close();
            }
        }

        public void WriteDataAppend(List<MagicUser> dataToWrite) {
            try {
                stream = new FileStream(this.filePathPrime, FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(stream);

                foreach (MagicUser item in dataToWrite) {
                    writer.WriteLine(item);
                    writer.Flush();
                }

            } catch (FileNotFoundException) {
                
            } catch (DirectoryNotFoundException) {
                
            } catch (IOException) {
                
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
