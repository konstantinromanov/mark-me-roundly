using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_MarkMeRoundly
{
    public static class GradesProcessing
    {

        public static string RoundGrades(int[] arr)
        {
            int[] outArr = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                var remainder = arr[i] % 5;

                outArr[i] = (arr[i]! < 40 || remainder == 0 || remainder < 3) ? arr[i] : arr[i] - remainder + 5;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("\"");

            for (int i = 0; i < outArr.Length; i++)
            {
                sb.Append(outArr[i].ToString());

                if (i != outArr.Length - 1)
                {
                    sb.Append(", ");
                }
            }

            sb.Append("\"");

            return sb.ToString();
        }
    }
}
