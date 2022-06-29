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

            int trainee = ReadInt();

            var commits = ComputeTraineeCommits(trainee);

            _writer.WriteLine(commits);

            CloseReaderAndWriter();
        }

        static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        static int ComputeTraineeCommits(int trainee)
        {
            // 1 1 2 3 5 8 13 21 33 45
            // F1 = 1;
            // F2 = 2;
            // Fn = Fn-1 + Fn-2;

            if (trainee == 0 || trainee == 1)
                return 1;

            return ComputeTraineeCommits(trainee - 1) + ComputeTraineeCommits(trainee - 2);
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
    }
}
