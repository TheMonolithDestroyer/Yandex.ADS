using System;
using System.IO;
using System.Linq;

namespace Yandex.Practicum
{
    public class Program
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        static void Main(string[] args)
        {
            InitReaderAndWriter();

            string originalStr = ReadString();
            originalStr = string.Concat(originalStr.OrderBy(i => i));
            string damagedStr = ReadString();
            damagedStr = string.Concat(damagedStr.OrderBy(i => i));

            string result = string.Empty;
            int i = 0, j = 0;
            while (j >= 0)
            {
                if (i > originalStr.Length - 1 || originalStr[i] != damagedStr[j])
                {
                    result += damagedStr[j];
                    break;
                }

                i++;
                j++;
            }

            _writer.WriteLine(result);

            CloseReaderAndWriter();
        }

        public static string ReadString()
        {
            return _reader.ReadLine();
        }

        private static void InitReaderAndWriter()
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());
        }

        private static void CloseReaderAndWriter()
        {
            _reader.Close();
            _writer.Close();
        }
    }
}
