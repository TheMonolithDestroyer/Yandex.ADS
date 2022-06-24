using System;
using Yandex.Practicum.Classes;

namespace Yandex.Practicum.Sprints.Sprint2
{
    public class TaskC
    {
        public static Node<T> Execute<T>(Node<T> head, int idx)
        {
            if (idx == 0)
            {
                head = head.Next;
                return head;
            }

            var targetNode = GetNodeByIndex(head, idx);
            if (targetNode == null)
                return null;

            var previousNode = GetNodeByIndex(head, idx - 1);
            

            previousNode.Next = targetNode.Next; 
            targetNode.Next = null;

            return head;
        }

        static Node<T> GetNodeByIndex<T>(Node<T> head, int idx)
        {
            while(idx > 0)
            {
                head = head.Next;
                
                if (head == null) 
                    return head;

                idx--;
            }

            return head;
        }

/* Tests
        static Node<string> Test0()
		{
			Node<string> node4 = new Node<string>("node4", null);
			Node<string> node3 = new Node<string>("node3", node4);
			Node<string> node2 = new Node<string>("node2", node3);
			Node<string> node1 = new Node<string>("node1", node2);
			Node<string> node0 = new Node<string>("node0", node1);

			int value = 2;
			return TaskC.Execute(node0, value);
		}

		static Node<string> Test1()
		{
			Node<string> node3 = new Node<string>("node3", null);
			Node<string> node2 = new Node<string>("node2", node3);
			Node<string> node1 = new Node<string>("node1", node2);
			Node<string> node0 = new Node<string>("node0", node1);

			int value = 0;
			return TaskC.Execute(node0, value);
		}

		static Node<string> Test2()
		{
			Node<string> node3 = new Node<string>("node3", null);
			Node<string> node2 = new Node<string>("node2", node3);
			Node<string> node1 = new Node<string>("node1", node2);
			Node<string> node0 = new Node<string>("node0", node1);

			int value = 3;
			return TaskC.Execute(node0, value);
		}

		static Node<string> Test3()
		{
			Node<string> node0 = new Node<string>("node0", null);

			int value = 0;
			return TaskC.Execute(node0, value);
		}

		static Node<string> Test4()
		{
			Node<string> node1 = new Node<string>("node1", null);
			Node<string> node0 = new Node<string>("node0", node1);

			int value = 2;
			return TaskC.Execute(node0, value);
		}
*/
    }
}