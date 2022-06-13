using System;
using System.IO;

namespace Yandex.Practicum
{
    public class Program
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        static void Main(string[] args)
        {
            InitReaderAndWriter();

            int number = ReadInt();

            string result;
            if (number == 1)
                result = "True";

            int multiplier = 1;
            while (multiplier < number)
            {
                multiplier *= 4;
            }

            result = multiplier == number ? "True" : "False";

            _writer.WriteLine(result);
            CloseReaderAndWriter();
        }

        public static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
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
