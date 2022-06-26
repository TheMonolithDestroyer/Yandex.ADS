using System;
using Yandex.Practicum.Classes;

namespace Yandex.Practicum.Sprints.Sprint2
{
    public class TaskJ : BaseClass
    {
        
        public static void Execute()
        {
            InitReaderAndWriter();
            
            int commandCount = Common.ReadInt(_reader);

            QueueNode2 queue = new QueueNode2(); 
            while(commandCount > 0)
            {
                string command = Common.ReadString(_reader);
                switch(command)
                {
                    case "get":
                        PrintGotten(queue);
                        break;
                    case "size":
                        PrintSizeOfQueue(queue);
                        break;
                    default: 
                        PushValueToQueue(queue, command);
                        break;
                }
                commandCount--;
            }

            CloseReaderAndWriter();
        }

        private static void PrintGotten(QueueNode2 queue)
        {
            if (queue.Count <= 0)
            {
                _writer.WriteLine("error");
            }
            else 
            {
                _writer.WriteLine(queue.Pop());
            }
        }

        private static void PrintSizeOfQueue(QueueNode2 queue)
        {
            _writer.WriteLine(queue.Count);
        }

        private static void PushValueToQueue(QueueNode2 queue, string command)
        {
            string[] commandArr = command.Split(' ');
            int value = Convert.ToInt32(commandArr[1]);

            queue.Push(value);
        }
    }
}