using System;
using System.IO;
using System.Linq;

namespace Yandex.Practicum
{
	// ID = 68983618
	public class Program
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        static void Main(string[] args)
        {
			InitReaderAndWriter();

			int streetLength = ReadInt();
			int[] blocks = ReadArray();

			int emptyBlock = -1;
			int nextEmptyBlock = -1;

			int[] result = new int[streetLength];
			for (int i = 0; i < streetLength; i++)
			{
				if (blocks[i] == 0)
				{
					result[i] = 0;
					emptyBlock = i;
					nextEmptyBlock = -1;
					continue;
				}

				int j = i;
				while (nextEmptyBlock < 0 && j < blocks.Length)
                {
					if (blocks[j] == 0)
                    {
						nextEmptyBlock = j;
						break;
                    }

					j++;
                }

				int distance = 0;
				if (emptyBlock >= 0 && nextEmptyBlock < 0)
				{
					distance = i - emptyBlock;
				}
				else if (emptyBlock < 0 && nextEmptyBlock >= 0)
				{
					distance = nextEmptyBlock - i;
				}
				else
				{
					int leftDistance = i - emptyBlock;
					int rightDistance = nextEmptyBlock - i;
					distance = leftDistance > rightDistance ? rightDistance : leftDistance;
				}

				result[i] = distance;
			}

			_writer.WriteLine(string.Join(' ', result));

			CloseReaderAndWriter();
		}

		private static int[] ReadArray()
		{
			return _reader.ReadLine()
				.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();
		}

		private static int ReadInt()
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
