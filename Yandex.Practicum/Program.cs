using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Yandex.Practicum.Sprints.Sprint1;

namespace Yandex.Practicum
{
    public class Program
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        static void Main(string[] args)
        {
            Task10.MainTask10();
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
