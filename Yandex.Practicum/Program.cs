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
            
            QueueNode queue = new QueueNode();

            int commandCount = ReadInt();
            while(commandCount > 0)
            {
                string command = ReadString();
                switch(command)
                {
                    case "get":
                        PrintGotten(queue);
                        break;
                    case "size":
                        PrintSizeOfQueue(queue);
                        break;
                    default: 
                        PushValueToQueue(queue, command);
                        break;
                }
                commandCount--;
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

        private static void PrintGotten(QueueNode queue)
        {
            if (queue.Count <= 0)
            {
                _writer.WriteLine("error");
            }
            else 
            {
                _writer.WriteLine(queue.Pop());
            }
        }

        private static void PrintSizeOfQueue(QueueNode queue)
        {
            _writer.WriteLine(queue.Count);
        }

        private static void PushValueToQueue(QueueNode queue, string command)
        {
            string[] commandArr = command.Split(' ');
            int value = Convert.ToInt32(commandArr[1]);

            queue.Push(value);
        }
	}

    public class Node<TValue>
    {
        public TValue Value { get; private set; }
        public Node<TValue> Next { get; set; }
        public Node<TValue> Prev { get; set; }
        
        public Node(TValue value, Node<TValue> next, Node<TValue> prev)
        {
            Value = value;
            Next = next;
            Prev = prev;
        }
    }

    public class QueueNode
    {
        private int _count;
        private Node<int> _queue;
        public int Count { get => _count; private set => _count = value; }
        public QueueNode()
        {
            _queue = null;
            _count = 0;
        }

        public void Push(int value)
        {
            Node<int> item = new Node<int>(value, null, null);
            if (item == null)
                throw new OverflowException(message: "Heap overflow");

            _count ++;
            if (_queue == null)
            {
                _queue = item;
                return;
            }

            Node<int> temp = _queue;
            for (int i = _count - 2; i > 0; i--)
            {
                _queue = _queue.Next;
            }

            _queue.Next = item;
            _queue = temp;
        }

        public int Pop()
        {   
            if (_count <= 0)
                throw new UnderflowException(message: "Can not pop an empty queue");
            
            _count--;
            Node<int> node = _queue;
            _queue = _queue.Next;

            return node.Value;
        }

        public int Peek()
        {
            if (_count <= 0)
                throw new UnderflowException(message: "Can not peek an empty queue");

            return _queue.Value;
        }
    }

	public class UnderflowException : Exception
    {
        public UnderflowException(string message): base(message)
        {
        }
    }
}
