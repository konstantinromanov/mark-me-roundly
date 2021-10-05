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
            bool inputLengthError = true;

            string inputErrorLength
                = $"{fileNameRead} file, has {inputLength} grades in it. Allowed number of grades should be from 1 to 60 included";

            int inputValue = 0;

            string inputErrorValue = $"{fileNameRead} file, has grade {inputValue} in it. Grade should be from 0 to 100 included";

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
                        writer.WriteToDisk(fileNameWrite, GradesProcessing.RoundGrades(arr));
                    }

                    inputLengthError = false;
                }

            }

            Console.WriteLine(inputLengthError ? inputErrorLength : inputErrorValue);
        }
    }
}
