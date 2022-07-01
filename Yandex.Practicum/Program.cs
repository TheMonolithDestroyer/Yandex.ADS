using System;
using System.IO;

namespace Yandex.Practicum
{
    public class Program
    {
        static TextReader _reader;
        static TextWriter _writer;

        static void Main(string[] args)
        {
            InitReaderAndWriter();

            _writer.WriteLine("Hello Yandex!");

            _writer.Close();
            CloseReaderAndWriter();
        }

        static void InitReaderAndWriter()
        {
            _reader = new StreamReader(Console.OpenStandardInput());
            _writer = new StreamWriter(Console.OpenStandardOutput());
        }

        static void CloseReaderAndWriter()
        {
            _reader.Close();
            _writer.Close();
        }

        static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        static string ReadString()
        {
            return _reader.ReadLine();
        }
    }
}