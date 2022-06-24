using System;

namespace Yandex.Practicum.Classes
{
    public class Node<TValue>
    {
        public TValue Value { get; private set; }
        public Node<TValue> Next { get; set; }

        public Node(TValue value, Node<TValue> next)
        {
            Value = value;
            Next = next;
        }
    }
}