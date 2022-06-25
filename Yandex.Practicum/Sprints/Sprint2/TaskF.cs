using System;
using System.Collections.Generic;

namespace Yandex.Practicum.Sprints.Sprint2
{
    public class TaskF : BaseClass
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
        public static void Execute()
        {
            InitReaderAndWriter();

            int commandsCount = Common.ReadInt(_reader);

			Stack<string> digits = new Stack<string>();
			while(commandsCount > 0)
			{
				string command = Common.ReadString(_reader);
				switch(command)
				{
					case "get_max":
						GetMax(digits);
						break;

					case "pop":
						Pop(digits);
						break;

					default:
						Push(digits, command);
						break;
				}
				commandsCount--;	
			}

            CloseReaderAndWriter();
        }

        private static void Push(Stack<string> digits, string command)
		{
			string[] splitCommand = command.Split(' ');
			digits.Push(splitCommand[1]);
		}

		private static void Pop(Stack<string> digits)
		{				
			if (digits.Count > 0)
			{
				digits.Pop();
			}
			else 
			{
				_writer.WriteLine("error");
			}
		}

		private static void GetMax(Stack<string> digits)
		{
			if (digits.Count > 0)
			{
				_writer.WriteLine(digits.Peek());
			}
			else
			{
				_writer.WriteLine("None");
			}
		}
    }
}