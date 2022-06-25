using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint2
{
    public class TaskG : BaseClass
    {
		#region Tests
		// 8, get_max, push 7, pop, push -2, push -1, pop, get_max, get_max
		// None -2 -2 

		// 7 get_max pop pop pop push 10 get_max push -9
		// None error error error 10

		// 7 push 0 push 10 push 120 push -102 push -6 push -67  get_max
		// -67

		// 7 pop pop pop pop pop pop pop
		// error error error error error error error

		// 5 get_max get_max get_max get_max get_max get_max
		// None None None None None

		// 4 get_max pop get_max pop
		// None error None error

		// 5 get_max get_max get_max get_max pop
		// None None None None error

		// 5 pop pop pop pop get_max
		// error error error error None

		// 5 push 3 push -2 pop get_max
		// 3

		// 5 push -2 push 3 get_max pop
		// 3

		// 2 push -34 get_max
		// -34

		// 4 push 45 get_max push -54 get_max
		// 45 -54

		// 6 push 6 push 5 push 12 pop get_max pop
		// 5
		#endregion
		public static void Execute(string[] args)
		{
			InitReaderAndWriter();

			int commandsCount = Common.ReadInt(_reader);

			Stack<int> trackStack = new Stack<int>();
			Stack<int> mainStack = new Stack<int>();
			while (commandsCount > 0)
			{
				string command = Common.ReadString(_reader);
				switch (command)
				{
					case "get_max":
						GetMax(mainStack, trackStack);
						break;

					case "pop":
						Pop(mainStack, trackStack);
						break;

					default:
						Push(mainStack, trackStack, command);
						break;
				}
				commandsCount--;
			}

			CloseReaderAndWriter();
		}

		private static void Push(Stack<int> mainStack, Stack<int> trackStack, string command)
		{
			string[] splitCommand = command.Split(' ');

			int value = Convert.ToInt32(splitCommand[1]);

			if (trackStack.Count > 0)
			{
				int maxValue = trackStack.Peek();
				trackStack.Push(maxValue < value ? value : maxValue);
			}
			else
			{
				trackStack.Push(value);
			}

			mainStack.Push(value);
		}

		private static void Pop(Stack<int> mainStack, Stack<int> trackStack)
		{
			if (mainStack.Count > 0)
			{
				mainStack.Pop();
				trackStack.Pop();
			}
			else
			{
				_writer.WriteLine("error");
			}
		}

		private static void GetMax(Stack<int> mainStack, Stack<int> trackStack)
		{
			if (mainStack.Count > 0)
			{
				_writer.WriteLine(trackStack.Peek());
			}
			else
			{
				_writer.WriteLine("None");
			}
		}
	}
}
