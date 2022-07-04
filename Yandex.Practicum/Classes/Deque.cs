using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandex.Practicum.Exceptions;

namespace Yandex.Practicum.Classes
{
    public class Deque
    {
        private int _head;
        private int _tail;
        private int _count;
        private readonly int _maxSize;
        private int[] _deque = null;

        public int Count { get => _count; }

        public Deque(int maxSize)
        {
            _deque = new int[maxSize];
            _maxSize = maxSize;
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        public int PopBack()
        {
            if (_count == 0)
                throw new UnderflowException("A Deque is empty!");

            _tail = (_tail - 1 + _maxSize) % _maxSize;
            int item = _deque[_tail];
            _deque[_tail] = 0;
            _count--;

            return item;
        }

        public int PopFront()
        {
            if (_count == 0)
                throw new UnderflowException("A Deque is empty!");

            int item = _deque[_head];
            _deque[_head] = 0;
            _head = (_head + 1) % _maxSize;
            _count--;

            return item;
        }

        public void PushFront(int value)
        {
            if (_count >= _maxSize)
                throw new OverflowException("A Deque is full!");

            _head = (_head - 1 + _maxSize) % _maxSize;
            _deque[_head] = value;
            _count++;
        }

        public void PushBack(int value)
        {
            if (_count >= _maxSize)
                throw new OverflowException("A Deque is full!");

            _deque[_tail] = value;
            _tail = (_tail + 1) % _maxSize;
            _count++;
        }
    }
}
