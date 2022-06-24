using System;
using Yandex.Practicum.Classes;

namespace Yandex.Practicum.Sprints.Sprint2
{
    public class TaskD
    {
        public static int Execute(Node<string> head, string item)
        {
            int index = -1;
            while(head != null)
            {
                index++;
                if (head.Value.Equals(item))
                    return index;

                head = head.Next;
            }

            index = -1;
            return index;
        }
    }
}