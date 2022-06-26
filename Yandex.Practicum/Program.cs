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

            int commandsCount = ReadInt();
            int queueMaxSize = ReadInt();

            Queue queue = new Queue(queueMaxSize);
            while(commandsCount > 0)
            {
                string command = Common.ReadString(_reader);
                switch (command)
                {
                    case "pop":
                        PrintPoped(queue);
                        break;
                    case "peek":
                        PrintPeeked(queue);
                        break;
                    case "size":
                        PrintSizeOfQueue(queue);
                        break;
                    default:
                        PushToQueueIfHasSpace(queue, command, queueMaxSize);
                        break;
                }
                commandsCount--;
            }

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

		private static void PrintPoped(Queue queue)
        {
            if (queue.Count <= 0)
            {
                _writer.WriteLine("None");
            }
            else 
            {
                _writer.WriteLine(queue.Pop());
            }
        }

        private static void PrintPeeked(Queue queue)
        {
            if (queue.Count <= 0)
            {
                _writer.WriteLine("None");
            }
            else
            {
                _writer.WriteLine(queue.Peek());
            }
        }

        private static void PrintSizeOfQueue(Queue queue)
        {
            _writer.WriteLine(queue.Count);
        }

        private static void PushToQueueIfHasSpace(Queue queue, string command, int queueMaxSize)
        {
            var commandArr = command.Split(' ');
            int value = Convert.ToInt32(commandArr[1]);

            if (queue.Count >= queueMaxSize)
            {
                _writer.WriteLine("error");
            }
            else
            {
                queue.Push(value);
            }
        }
	}

	public class Queue
    {
        private int _head;
        private int _tail;
        private int _count;
        private readonly int _maxSize;
        public int Count { get => _count; private set => _count = value; }
        private int[] _queue = null;

        public Queue(int maxSize) 
        {
            InitQueue(maxSize);

            _head = 0;
            _tail = 0;
            _maxSize = maxSize;
            _count = 0;
        }

        public void Push(int item)
        {
            if (_count >= _maxSize) 
                throw new OverflowException(message: "You can not insert an item into the full queue");
            
            _queue[_tail] = item;
            _tail = (_tail + 1) % _maxSize;
            _count++;
        }

        public int Pop()
        {
            if (_count <= 0) 
                throw new UnderflowException("You can not pop an empty queue!");

            int item = _queue[_head];
            _queue[_head] = 0;
            _head = (_head + 1) % _maxSize;
            Count--;

            return item;
        }

        public int Peek()
        {
            if (_count <= 0) 
                throw new UnderflowException("You can not peek an empty queue!");

            int item = _queue[_head];

            return item;
        }

        private void InitQueue(int size)
        {
            if (size <= 0) 
                throw new ArgumentOutOfRangeException(message: "The size of a Queue can not be 0 or less", paramName: $"Input size: { size }");

            _queue = new int[size];
        }
    }

	public class UnderflowException : Exception
    {
        public UnderflowException(string message): base(message)
        {
        }
    }
}
