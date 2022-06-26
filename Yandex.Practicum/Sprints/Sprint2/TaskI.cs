using System;
using Yandex.Practicum.Classes;

namespace Yandex.Practicum.Sprints.Sprint2
{
    public class TaskI : BaseClass
    {
        #region Tests
        // 1)  8 2 peek push 5 push 2 peek size size push 1 size 
        // None 5 2 2 error 2

        // 2) 10 1 push 1 size push 3 size push 1 pop push 1 pop push 3 push 3
        // 1 error 1 error 1 1 error

        // 3) 3 1 peek peek peek
        // None None None

        // 4) 3 1 pop pop pop
        // None None None

        // 5) 3 1 push 1 push -2 push 9
        // error error

        // 6. 4 1 pop peek pop peek
        // None None None None

        // 7. 6 10 push 4 peek pop push -124 peek pop 
        // 4 4 -124 -124

        // 8. 6 10 push 4 peek peek push -124 peek pop
        // 4 4 4 4

        // 9. 9 5 push 4 push -35 push 543 push 43 push -41 pop pop push 0 peek
        // 5 -35 543

        // 10. 1 1 pop
        // None

        // 11. 1 1 peek
        // None

        // 12. 13 4 push 35 push -341 push 9 push -21 push 0 pop pop pop push -51 pop push 33 pop peek
        // error 35 -341 9 -21 -51 33

        // 13. 5 2 push 0 push 1 push 2 push 4 push 13
        // error error error

        #endregion
        public static void Execute()
        {
            InitReaderAndWriter();

            int commandsCount = Common.ReadInt(_reader);
            int queueMaxSize = Common.ReadInt(_reader);

            Queue queue = new Queue(queueMaxSize);
            while(commandsCount > 0)
            {
                string command = Common.ReadString(_reader);
                switch (command)
                {
                    case "pop":
                        PrintPoped(queue);
                        break;
                    case "peek":
                        PrintPeeked(queue);
                        break;
                    case "size":
                        PrintSizeOfQueue(queue);
                        break;
                    default:
                        PushToQueueIfHasSpace(queue, command, queueMaxSize);
                        break;
                }
                commandsCount--;
            }

            CloseReaderAndWriter();
        }

        private static void PrintPoped(Queue queue)
        {
            if (queue.Count <= 0)
            {
                _writer.WriteLine("None");
            }
            else 
            {
                _writer.WriteLine(queue.Pop());
            }
        }

        private static void PrintPeeked(Queue queue)
        {
            if (queue.Count <= 0)
            {
                _writer.WriteLine("None");
            }
            else
            {
                _writer.WriteLine(queue.Peek());
            }
        }

        private static void PrintSizeOfQueue(Queue queue)
        {
            _writer.WriteLine(queue.Count);
        }

        private static void PushToQueueIfHasSpace(Queue queue, string command, int queueMaxSize)
        {
            var commandArr = command.Split(' ');
            int value = Convert.ToInt32(commandArr[1]);

            if (queue.Count >= queueMaxSize)
            {
                _writer.WriteLine("error");
            }
            else
            {
                queue.Push(value);
            }
        }
    }
}