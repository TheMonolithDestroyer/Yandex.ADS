using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Yandex.Practicum
{
    public class Program
    {
        protected static TextReader _reader;
        protected static TextWriter _writer;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static List<int> ReadList()
        {
            return _reader.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
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
