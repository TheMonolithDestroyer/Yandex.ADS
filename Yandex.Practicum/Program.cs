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

            int listFormLength = ReadInt();
            string listForm = ReadString();
            int kNumber = ReadInt();

            string concatedListForm = string.Empty;
            for (int i = 0; i < listForm.Length; i++)
            {
                if (listForm[i] != ' ')
                {
                    concatedListForm += listForm[i];
                }
            }

            int xNumber = Convert.ToInt32(concatedListForm);
            int numberResult = xNumber + kNumber;

            string result = string.Empty;
            while (numberResult > 0)
            {
                var middleNumber = numberResult % 10;
                numberResult /= 10;

                result = middleNumber.ToString() + ' ' + result;
            }

            _writer.WriteLine(result.TrimEnd());

            CloseReaderAndWriter();
        }

        public static string ReadString()
        {
            return _reader.ReadLine();
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
