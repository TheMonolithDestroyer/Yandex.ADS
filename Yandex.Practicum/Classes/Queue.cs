using System;
using Yandex.Exceptions;

namespace Yandex.Practicum.Classes
{
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
}