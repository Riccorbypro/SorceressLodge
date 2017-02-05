using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorceressLodge
{
    class FileHandler
    {
        private FileStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private string filePathPrime;

        public FileHandler(string filePathParam = "default.csv")
        {
            this.filePathPrime = filePathParam;
        }

        public void WriteData(List<string> dataToWrite)
        {
            try
            {
                stream = new FileStream(this.filePathPrime, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(stream);

                foreach (string item in dataToWrite)
                {
                    writer.WriteLine(item);
                    writer.Flush();
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("fILE mISSING");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("dIRECTORY mISSING");
            }
            catch (IOException)
            {
                Console.WriteLine("cRITICAL eRROR");
            }
            finally
            {
                writer.Close();
                stream.Close();
            }
        }

        public void WriteDataAppend(List<string> dataToWrite)
        {
            try
            {
                stream = new FileStream(this.filePathPrime, FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(stream);

                foreach (string item in dataToWrite)
                {
                    writer.WriteLine(item);
                    writer.Flush();
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("fILE mISSING");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("dIRECTORY mISSING");
            }
            catch (IOException)
            {
                Console.WriteLine("cRITICAL eRROR");
            }
            finally
            {
                writer.Close();
                stream.Close();
            }
        }

        public List<string> ReadData()
        {
            List<string> dataRaw = new List<string>();

            try
            {
                stream = new FileStream(filePathPrime, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(stream);

                while (!reader.EndOfStream)
                {
                    dataRaw.Add(reader.ReadLine());
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("fILE mISSING");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("dIRECTORY mISSING");
            }
            catch (IOException)
            {
                Console.WriteLine("cRITICAL eRROR");
            }
            finally
            {
                reader.Close();
                stream.Close();
            }

            return dataRaw;
        }

    }
}
