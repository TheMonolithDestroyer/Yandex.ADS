using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandex.Practicum.Exceptions;

namespace Yandex.Practicum.Classes
{
    public class StackLinkedList
    {
        private Node<int> _head;
        private int _count;

        public int Count { get => _count; }

        public StackLinkedList()
        {
            _head = null;
            _count = 0;
        }

        public void Push(int value)
        {
            Node<int> node = new Node<int>(value, null, null);
            if (node == null)
                throw new OverflowException(message: "Heap overflow");

            _count++;
            if (_head == null)
            {
                _head = node;
                return;
            }
            
            node.Next = _head;
            _head = node;
        }

        public int Pop ()
        {
            if (_head == null)
                throw new ArgumentUnderflowException("A stack is empty!");

            int item = _head.Value;
            _head = _head.Next;
            _count--;

            return item;
        }

        public int Peek()
        {
            if (_head == null)
                throw new ArgumentUnderflowException("A stack is empty!");

            return _head.Value;
        }
    }
}
