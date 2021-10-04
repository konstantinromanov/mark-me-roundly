using System;

namespace _01_MarkMeRoundly
{
    class Program
    {
        static void Main(string[] args)
        {


            string input = "23, 65, 76, 78, 23, 43";
            
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



            for (int i = 0; i < outArr.Length; i++)
            {
                Console.WriteLine(outArr[i]);
            }


        }


    }


}
