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
            string fileNameW = "output.txt";
            string fileNameR = "input.txt";

            var writer = new FileHandling(docPath);

            string input = writer.ReadFromDisk(fileNameR);
            input = input.Replace("\"", string.Empty);

            int[] arr = Array.ConvertAll(input.Split(","), s => int.Parse(s.Trim()));

            writer.WriteToDisk(fileNameW, GradesProcessing.RoundGrades(arr));
        }
    }
}
