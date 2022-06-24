using System;
using Yandex.Practicum.Classes;

namespace Yandex.Practicum.Sprints.Sprint2
{
    public class TaskE
    {
        public static Node<string> Execute(Node<string> head)
        {
            Node<string> nextNode = null;
            Node<string> prevNode = head.Prev;
            while(head != null)
            {
                nextNode = head.Next;

                head.Next = prevNode;
                head.Prev = nextNode;

                prevNode = head;
                head = head.Prev;
            }
            
            head = prevNode;
            return head;
        }

        /*Tests
        static void Test0()
		{
			var node3 = new Node<string>("node3", null, null);
			var node2 = new Node<string>("node2", node3, null);
			var node1 = new Node<string>("node1", node2, null);
			var node0 = new Node<string>("node0", node1, null);
			var newNode = TaskE.Execute(node0);
			
			while(newNode != null)
			{
				if (newNode?.Next != null)
					System.Console.WriteLine(newNode?.Next?.Value);

				if (newNode?.Prev != null)
					System.Console.WriteLine(newNode?.Prev?.Value);

				newNode = newNode.Next;
			}
		}

		static void Test1()
		{
			var node1 = new Node<string>("node1", null, null);
			var node0 = new Node<string>("node0", node1, null);
			var newNode = TaskE.Execute(node0);
			
			while(newNode != null)
			{
				if (newNode?.Next != null)
					System.Console.WriteLine(newNode?.Next?.Value);

				if (newNode?.Prev != null)
					System.Console.WriteLine(newNode?.Prev?.Value);

				newNode = newNode.Next;
			}
		}

		static void Test2()
		{
			var node0 = new Node<string>("node0", null, null);
			var newNode = TaskE.Execute(node0);
			
			while(newNode != null)
			{
				if (newNode?.Next != null)
					System.Console.WriteLine(newNode?.Next?.Value);

				if (newNode?.Prev != null)
					System.Console.WriteLine(newNode?.Prev?.Value);

				newNode = newNode.Next;
			}
        }
        */
    }
}