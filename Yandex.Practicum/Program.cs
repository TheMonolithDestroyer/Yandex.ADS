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

            string result = string.Empty;

            do
            {
                var reminder = number % 2;
                number /= 2;
                result = reminder + result;
            }
            while (number > 0);

            _writer.WriteLine(result);

            CloseReaderAndWriter();
        }

        private static int ReadInt()
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
