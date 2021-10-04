using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_MarkMeRoundly
{
    public class FileHandling
    {
        public string Arg { get; }
        public FileHandling(string arg)
        {
            Arg = arg;
        }

        
        public string ReadFromDisk(string file)
        {
            string readStream = string.Empty;

            string docPath = Arg;
            try
            {
                using (var sr = new StreamReader(Path.Combine(Arg, file)))
                {
                    readStream = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {

                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }

            return readStream;
        }

        public void WriteToDisk(string file, string input)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Arg, file)))
            {
                outputFile.WriteLine(input);
            }
        }
    }
}
