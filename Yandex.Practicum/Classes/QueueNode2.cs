using System;
using Yandex.Practicum.Exceptions;

namespace Yandex.Practicum.Classes
{
    public class QueueNode2
    {
        private int _count;
        private Node<int> _queue;
        public int Count { get => _count; private set => _count = value; }
        public QueueNode2()
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
                throw new ArgumentUnderflowException(message: "Can not pop an empty queue");
            
            _count--;
            Node<int> node = _queue;
            _queue = _queue.Next;

            return node.Value;
        }

        public int Peek()
        {
            if (_count <= 0)
                throw new ArgumentUnderflowException(message: "Can not peek an empty queue");

            return _queue.Value;
        }
    }
}