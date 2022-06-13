using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class Task6 : BaseClass
    {
        public static void MainTask6()
        {
            InitReaderAndWriter();

            string text = Common.ReadString(_reader);
            StringBuilder cleanString = new();

            int i = 0;
            while (i < text.Length)
            {
                if (char.IsDigit(text[i]) || ((text[i] >= 'a' && text[i] <= 'z') || (text[i] >= 'A' && text[i] <= 'Z')))
                {
                    cleanString.Append(text[i]);
                }

                i++;
            }

            var middle = cleanString.Length / 2;
            var left = string.Empty;
            var right = string.Empty;
            if (cleanString.Length % 2 == 0)
            {
                left = cleanString.ToString()[0..middle];
                right = Reverse(cleanString.ToString()[middle..]);
            }
            else
            {
                left = cleanString.ToString()[0..(middle + 1)];
                right = Reverse(cleanString.ToString()[middle..]);
            }

            var result = left.Equals(right, StringComparison.OrdinalIgnoreCase);

            _writer.WriteLine(result ? "True" : "False");

            CloseReaderAndWriter();
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
