using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace _01_MarkMeRoundly
{
    class Program
    {
        static void Main(string[] args)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileNameWrite = "output.txt";
            string fileNameRead = "input.txt";
            int inputLength = 0;

            string inputErrorLength
                = $"{fileNameRead} file, has {inputLength} grades in it. Allowed number of grades should be from 1 to 60 included";

            string inputErrorValue = $"{fileNameRead} file, has grade that is out of allowed range. Grades should be from 0 to 100 included";

            string error = inputErrorLength;

            var writer = new FileHandling(docPath);

            string input = writer.ReadFromDisk(fileNameRead);
            input = input.Replace("\"", string.Empty);

            if (input.Length != 0)
            {
                int[] arr = Array.ConvertAll(input.Split(","), s => int.Parse(s.Trim()));
                inputLength = arr.Length;

                if (inputLength <= 60)
                {
                    if (Array.TrueForAll(arr, value => { return value <= 100 && value >= 0; }))
                    {
                        error = null;
                        writer.WriteToDisk(fileNameWrite, GradesProcessing.RoundGrades(arr));
                    }
                    else
                    {
                        error = inputErrorValue;
                    }
                }
            }

            Console.WriteLine(error != null ? error : "Job done!");
        }
    }
}
