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
            InitReaderAndWriter();

            int[] numbers = ReadArray();
            int x = ReadInt();

            Task4(numbers, x);

            CloseReaderAndWriter();
        }

        private static int[] Task4 (int[] numbers, int x)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] != x)
                    {
                        continue;
                    }

                    return new int[2] { numbers[i], numbers[j] };
                }
            }

            return null;
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
