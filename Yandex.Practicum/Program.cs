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
            
            CloseReaderAndWriter();
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

		private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

		private static string ReadString()
        {
            return _reader.ReadLine();
        }
	}
}
