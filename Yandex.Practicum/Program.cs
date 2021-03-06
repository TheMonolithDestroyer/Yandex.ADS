using System;
using System.IO;
using System.Linq;

namespace Yandex.Practicum
{
    public class Program
    {
        static TextReader _reader;
        static TextWriter _writer;

        static void Main(string[] args)
        {
            _writer.WriteLine("Pnh!");
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

        public static int[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}