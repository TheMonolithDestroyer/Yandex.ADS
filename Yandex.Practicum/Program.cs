using System;
using System.Collections;
using System.IO;
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

            var firstBinary = ReadString();
            var secondBinary = ReadString();

            int i = firstBinary.Length - 1;
            int j = secondBinary.Length - 1;

            int reminder = 0;
            Stack myStack = new();
            while (i >= 0 || j >= 0)
            {
                char? a = i < 0 ? null : firstBinary[i];
                char? b = j < 0 ? null : secondBinary[j];

                switch (a, b)
                {
                    case (null, '1'):
                    case ('1', null):
                        {
                            myStack.Push(reminder > 0 ? '0' : '1');
                        }
                        break;
                    case (null, '0'):
                    case ('0', null):
                        {
                            if (reminder > 0)
                            {
                                myStack.Push('1');
                                reminder -= 1;
                            }
                            else
                            {
                                myStack.Push('0');
                            }
                        }
                        break;
                    case ('0', '0'):
                        {
                            if (reminder > 0)
                            {
                                myStack.Push('1');
                                reminder -= 1;
                            }
                            else
                            {
                                myStack.Push('0');
                            }
                        }
                        break;
                    case ('1', '0'):
                    case ('0', '1'):
                        {
                            myStack.Push(reminder > 0 ? '0' : '1');
                        }
                        break;
                    case ('1', '1'):
                        {
                            if (reminder > 0)
                            {
                                myStack.Push('1');
                            }
                            else
                            {
                                myStack.Push('0');
                                reminder += 1;
                            }
                        }
                        break;
                }

                i--;
                j--;
            }

            if (reminder > 0)
            {
                myStack.Push('1');
            }

            StringBuilder sb = new(); 
            
            while(myStack.Count > 0)
            {
                sb.Append(myStack.Pop());
            }

            _writer.WriteLine(sb.ToString());

            CloseReaderAndWriter();
        }

        public static string ReadString()
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
