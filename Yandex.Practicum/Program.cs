using System;
using System.Collections.Generic;
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

		private static void Push(Stack<string> digits, string command)
		{
			string[] splitCommand = command.Split(' ');
			digits.Push(splitCommand[1]);
		}

		private static void Pop(Stack<string> digits)
		{				
			if (digits.Count > 0)
			{
				digits.Pop();
			}
			else 
			{
				_writer.WriteLine("error");
			}
		}

		private static void GetMax(Stack<string> digits)
		{
			if (digits.Count > 0)
			{
				_writer.WriteLine(digits.Peek());
			}
			else
			{
				_writer.WriteLine("None");
			}
		}
	}
}
