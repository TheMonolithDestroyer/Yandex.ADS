using Yandex.Practicum.Classes;

namespace Yandex.Practicum.Sprints.Sprint2
{
    public class TaskB
    {
        private static System.IO.TextWriter _writer;
        public static void Execute<T>(Node<T> head)
        {
            _writer = new System.IO.StreamWriter(System.Console.OpenStandardOutput());

            while(head.Next != null)
            {
                _writer.WriteLine(head.Value);
                head = head.Next;
            }

            _writer.WriteLine(head.Value);
            _writer.Close();
        }

/* Tests
        private static void Test0()
		{
			var node3 = new Node<string>("node3", null);
			var node2 = new Node<string>("node2", node3);
			var node1 = new Node<string>("node1", node2);
			var node0 = new Node<string>("node0", node1);

			Execute(node0);
		}

		private static void Test1()
		{
			var node0 = new Node<string>("node0", null);

			Execute(node0);
		}

		private static void Test2()
        {
            var node19 = new Node<string>("node19", null);
			var node18 = new Node<string>("node18", node19);
			var node17 = new Node<string>("node17", node18);
			var node16 = new Node<string>("node16", node17);
			var node15 = new Node<string>("node15", node16);
			var node14 = new Node<string>("node14", node15);
			var node13 = new Node<string>("node13", node14);
			var node12 = new Node<string>("node12", node13);
			var node11 = new Node<string>("node11", node12);
			var node10 = new Node<string>("node10", node11);
			var node9 = new Node<string>("node9", node10);
			var node8 = new Node<string>("node8", node9);
			var node7 = new Node<string>("node7", node8);
			var node6 = new Node<string>("node6", node7);
			var node5 = new Node<string>("node5", node6);
			var node4 = new Node<string>("node4", node5);
			var node3 = new Node<string>("node3", node4);
			var node2 = new Node<string>("node2", node3);
			var node1 = new Node<string>("node1", node2);
			var node0 = new Node<string>("node0", node1);

			Execute(node0);
        }
*/
    }
}
