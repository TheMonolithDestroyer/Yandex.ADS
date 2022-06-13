using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum
{
    public static class Common
    {
        public static string ReadString(TextReader reader)
        {
            return reader.ReadLine();
        }

        public static string[] ReadStringArray(TextReader reader)
        {
            return reader.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }

        public static int ReadInt(TextReader reader)
        {
            return int.Parse(reader.ReadLine());
        }

        public static List<int> ReadList(TextReader reader)
        {
            return reader.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }

        public static int[] ReadArray(TextReader reader)
        {
            return reader.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
