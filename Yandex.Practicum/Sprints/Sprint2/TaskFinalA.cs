using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandex.Practicum.Classes;

namespace Yandex.Practicum.Sprints.Sprint2
{
    public class TaskFinalA : BaseClass
    {
        // ПРИНЦИП РАБОТЫ
        // ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ
        // ВРЕМЕННАЯ СЛОЖНОСТЬ
        // ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ

        #region Examples
        // 1) 4 4 pushF 861, pushF -819 popB popB
        //    861 -819
        // 2) 7 10 pushF -855 pushF 0 popB popB pushB 844 popB pushB 823
        //    -855 0 844
        // 3) 6 6 pushF -201 pushB 959 pushB 102 pushF 20 popF popB
        //    20 102
        // 4) 4 4 pushB 3 pushB -1 popF popF
        //    3 -1
        // 5) 7 10 pushB 42 pushB 0 popF popF pushF 121 popF pushF 45
        //    42 0 121
        // 6) 6 6 pushB -421 pushF 41 pushF 12 pushB 81 popB popF
        //    81 12
        // 7) 12 10 pushF 12 pushB 321 pushF -31 pushB 819 pushF 8 pushB 2 popB popF popB popF popB popF
        //    2 8 819 -31 312 12
        // 8) 5 4 pushB 1 pushF 0 pushB 314 pushF -654 popB
        //    314
        // 9) 5 4 pushF 1 pushB 0 popF pushF 314 pushB -654
        //    1
        // 10) 2 1 pushB 8 popF
        //     8
        // 11) 2 1 pushF 9 popB
        //     9
        #endregion

        public void Execute()
        {
            InitReaderAndWriter();

            int commandsCount = Common.ReadInt(_reader);
            int dequeMaxSize = Common.ReadInt(_reader);

            Deque deque = new Deque(dequeMaxSize);
            for (int i = 0; i < commandsCount; i++)
            {
                string command = Common.ReadString(_reader);
                string[] commandAndValue = command.Split(' ');

                switch (commandAndValue[0])
                {
                    case "push_front":
                        if (deque.Count >= dequeMaxSize)
                        {
                            _writer.WriteLine("error");
                        }
                        else
                        {
                            int value = Convert.ToInt32(commandAndValue[1]);
                            deque.PushFront(value);
                        }
                        break;
                    case "push_back":
                        if (deque.Count >= dequeMaxSize)
                        {
                            _writer.WriteLine("error");
                        }
                        else
                        {
                            var value = Convert.ToInt32(commandAndValue[1]);
                            deque.PushBack(value);
                        }
                        break;
                    case "pop_front":
                        if (deque.Count == 0)
                        {
                            _writer.WriteLine("error");
                        }
                        else
                        {
                            _writer.WriteLine(deque.PopFront());
                        }
                        break;
                    case "pop_back":
                        if (deque.Count == 0)
                        {
                            _writer.WriteLine("error");
                        }
                        else
                        {
                            _writer.WriteLine(deque.PopBack());
                        }
                        break;
                }
            }

            _writer.Close();
            CloseReaderAndWriter();
        }
    }
}
