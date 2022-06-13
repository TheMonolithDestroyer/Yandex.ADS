﻿using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Yandex.Practicum
{
    public class Program
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        static void Main(string[] args)
        {
            InitReaderAndWriter();

            string text = ReadString();
            StringBuilder cleanString = new();

            int i = 0;
            while (i < text.Length)
            {
                if (char.IsDigit(text[i]) || ((text[i] >= 'a' && text[i] <= 'z') || (text[i] >= 'A' && text[i] <= 'Z')))
                {
                    cleanString.Append(text[i]);
                }

                i++;
            }

            var middle = cleanString.Length / 2;
            var left = string.Empty;
            var right = string.Empty;
            if (cleanString.Length % 2 == 0)
            {
                left = cleanString.ToString()[0..middle];
                right = Reverse(cleanString.ToString()[middle..]);
            }
            else
            {
                left = cleanString.ToString()[0..(middle + 1)];
                right = Reverse(cleanString.ToString()[middle..]);
            }

            var result = left.Equals(right, StringComparison.OrdinalIgnoreCase);

            _writer.WriteLine(result ? "True" : "False");

            CloseReaderAndWriter();
        }

        public static string ReadString()
        {
            return _reader.ReadLine();
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
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
