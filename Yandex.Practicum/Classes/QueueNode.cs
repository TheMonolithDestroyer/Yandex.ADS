using System;

namespace Yandex.Practicum.Classes
{
    public class QueueNode
    {
        private Node<int> _head;
        private Node<int> _tail;
        private int _count;
        public int Count { get => _count; private set => _count = value; }

        public QueueNode()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public void Push(int value)
        {
            Node<int> node = new Node<int>(value, null, null);
            if (node == null) 
                throw new OverflowException(message: "Heap overflow");

            _count++;
            if (_tail == null)
            {
                _head = node;
                _tail = node;
                return;
            }

            _tail.Next = node;
            _tail = node;
        }

        public int Pop()
        {
            if (_head == null) 
                throw new UnderflowException("Can not pop an empty queue");

            Node<int> node = _head;
            _head = _head.Next;

            _count--;

            if (_head == null) 
                _tail = null;

            return node.Value;
        }

        public int Peek()
        {
            if (_head == null) 
                throw new UnderflowException("Can not peek an empty queue");

            return _head.Value;
        }
    }
}