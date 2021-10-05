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
        private string _directory { get; }
        public FileHandling(string directory)
        {
            _directory = directory;
        }

        
        public string ReadFromDisk(string file)
        {
            string readStream = string.Empty;
            
            try
            {
                using (var sr = new StreamReader(Path.Combine(_directory, file)))
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
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_directory, file)))
            {
                outputFile.WriteLine(input);
            }
        }
    }
}
