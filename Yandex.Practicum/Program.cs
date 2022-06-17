using System;
using System.IO;

namespace Yandex.Practicum
{
    // URL - https://contest.yandex.ru/contest/22450/run-report/69009987/
    // ID - 69009987
    public class Program
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        static void Main(string[] args)
        {
            InitReaderAndWriter();

            int keyCountToPress = ReadInt();

            var keyCounts = new int[10];
            for (int i = 0; i < 4; i++)
            {
                var row = ReadString();
                for (int j = 0; j < 4; j++)
                {
                    if (row[j] != '.')
                    {
                        keyCounts[row[j] - '0']++;
                    }
                }
            }

            int points = 0;
            for (int i = 1; i <= 9; i++)
            {
                var keyCount = keyCounts[i];
                if (keyCount > 0 && keyCount <= keyCountToPress * 2)
                {
                    points++;
                }
            }

            _writer.WriteLine(points);
            CloseReaderAndWriter();
        }

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        private static string ReadString()
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
