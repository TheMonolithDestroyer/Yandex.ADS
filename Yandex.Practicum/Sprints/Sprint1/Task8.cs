using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class Task8 : BaseClass
    {
        public static void MainTask8()
        {
            InitReaderAndWriter();

            // < 10^5
            var firstBinary = Common.ReadString(_reader);
            var secondBinary = Common.ReadString(_reader);

            int i = firstBinary.Length - 1;
            int j = secondBinary.Length - 1;
            
            int reminder = 0;
            Stack myStack = new();
            while (i >= 0 || j >= 0)
            {
                var a = firstBinary[i];
                var b = secondBinary[j];

                switch (a, b)
                {
                    case ('0', '0'):
                        {
                            if (reminder > 0)
                            {
                                myStack.Push('1');
                                reminder -= 1;
                            }
                            else
                            {
                                myStack.Push('0');
                            }
                        }
                        break;
                    case ('1', '0'):
                    case ('0', '1'):
                        {
                            myStack.Push(reminder > 0 ? '0' : '1');
                        }
                        break;
                    case ('1', '1'):
                        {
                            if (reminder > 0)
                            {
                                myStack.Push('1');
                            }
                            else
                            {
                                myStack.Push('0');
                                reminder += 1;
                            }
                        }
                        break;
                }

                i--;
                j--;
            }

            if (reminder > 0)
            {
                myStack.Push('1');
            }

            _writer.WriteLine(string.Join(string.Empty, myStack.ToArray()));

            CloseReaderAndWriter();
        }
    }
}
