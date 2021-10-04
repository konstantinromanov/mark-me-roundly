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



            int[] arr = Array.ConvertAll(input.Split(","), s => int.Parse(s.Trim()));

            int[] outArr = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                var remainder = arr[i] % 5;
                if (arr[i]! < 40 || remainder == 0 || remainder < 3)
                {
                    outArr[i] = arr[i];
                }
                else
                {
                    var a = arr[i] - remainder + 5;
                    outArr[i] = a;
                }


            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in outArr)
            {
                sb.Append(item.ToString());
                sb.Append(", ");

            }


            writer.WriteToDisk(fileNameW, sb.ToString());


        }


    }


}
