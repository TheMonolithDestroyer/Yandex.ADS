using System;

namespace Yandex.Practicum.Classes
{
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
}