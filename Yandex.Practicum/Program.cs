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

            var textLength = ReadInt();
            var text = ReadStringArray();

            int maxSubStrLength = 0;
            string mostLongSubStr = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                if (maxSubStrLength < text[i].Length)
                {
                    maxSubStrLength = text[i].Length;
                    mostLongSubStr = text[i];
                }
            }

            _writer.WriteLine(mostLongSubStr);
            _writer.WriteLine(maxSubStrLength);

            CloseReaderAndWriter();
        }

        private static string[] ReadStringArray()
        {
            return _reader.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static int[] ReadArray()
        {
            return _reader.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
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
