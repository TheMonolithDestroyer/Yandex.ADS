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
        //  Как написано в описании задачи, мне нужно было реализовать структуру данных Deque через кольцевой буфер.
        //  Кольцевой буфер или циклический буфер - это буфер фиксированного размера таким образом, как будто бы после последнего элемента сразу же снова идет первый.
        //  То есть, Deque Я реализовал с помощью Array, где если ячейка под индексом maxSize - 1 будет заполнена, то добавление идет в ячейку под индексом 0, и наоборот.

        //  При pop_back и pop_front проверяю пустой ли массив чтобы избежать Underflow Exception. Если дек пуст, то вывожу "error", иначе вывожу значение.
        //  При push_front и push_back проверяю не полный ли массив чтоюы избежать Overflow Exception. Если дек полн, то вывожу "error", иначе добавляю.

        //  Чтобы после последнего элемента происходило добавление по индексу 0, произвожу операцию (tail+1) mod maxSize.
        //  При операции push_front, если ячейка под индексом 0 занят, добавляю элемент в ячейку под индексом maxSize - 1.

        //  Операции push_front, push_back, pop_front, pop_back вынес в отдельный метод, по принципy SOLID. S - single responsibility.

        // ДОКАЗАТЕЛЬСТВО КОРРЕКТНОСТИ
        //  В описании задачи написано, что Дек должен быть фиксированного размера.
        //  Поэтому я реализовал данную структуру данных через массив с фиксированным размером.
        //  Я мог реализовать через массив, меняя его размер при переполнении, но это потребовало бы амортизированной временной сложности и O(N) пространственной сложности. 
        //
        //  Еще написано, что нужно использовать принцип кольцевого буфера.
        //  В пустом деке и голова, и хвост указывают на ячейку с индексом 0.
        //  При манипуляции полями _head и _tail, можно добавлять элементы из обоих концов дека. 
        //  Если push_front, значение _head уменьшается и элемент будет добавлен в ячейку под _head.
        //  Если push_back, значение _tail увеличивается по модулю _maxSize и элемент будет добавлен в ячейку под _tail.
        //  Если pop_front, значение _head увеличивается по модулю _maxSize и элемент будет добавлен в ячейку под _head.
        //  Если pop_back, значение _tail ументшается и элемент будет добавлен в ячейку под _tail.

        // ВРЕМЕННАЯ СЛОЖНОСТЬ
        // Перебор всех команд в цикле - O(N)
        // Дек у нас фиксированного размера и использован принцип кольцевого буфера, то добавление и удаление занимает O(1) константное время.

        // ПРОСТРАНСТВЕННАЯ СЛОЖНОСТЬ
        // Space complexity - O(1) константное. Так как для любой операции не потребуется дополнительное пространство

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
                        PushFront(deque, commandAndValue, dequeMaxSize);
                        break;
                    case "push_back":
                        PushBack(deque, commandAndValue, dequeMaxSize);
                        break;
                    case "pop_front":
                        PopFront(deque);
                        break;
                    case "pop_back":
                        PopBack(deque);
                        break;
                }
            }

            _writer.Close();
            CloseReaderAndWriter();
        }

        static void PushFront(Deque deque, string[] commandAndValue,  int dequeMaxSize)
        {
            if (deque.Count >= dequeMaxSize)
            {
                _writer.WriteLine("error");
            }
            else
            {
                int value = Convert.ToInt32(commandAndValue[1]);
                deque.PushFront(value);
            }
        }

        static void PushBack(Deque deque, string[] commandAndValue, int dequeMaxSize)
        {
            if (deque.Count >= dequeMaxSize)
            {
                _writer.WriteLine("error");
            }
            else
            {
                var value = Convert.ToInt32(commandAndValue[1]);
                deque.PushBack(value);
            }
        }

        static void PopFront(Deque deque)
        {
            if (deque.Count == 0)
            {
                _writer.WriteLine("error");
            }
            else
            {
                _writer.WriteLine(deque.PopFront());
            }
        }

        static void PopBack(Deque deque)
        {
            if (deque.Count == 0)
            {
                _writer.WriteLine("error");
            }
            else
            {
                _writer.WriteLine(deque.PopBack());
            }
        }
    }
}
