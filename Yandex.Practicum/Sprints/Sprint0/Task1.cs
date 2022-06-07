using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint0
{
    public class Task1 : BaseClass
    {
        public static void MainTask1()
        {
            InitReaderAndWriter();

            int a = Common.ReadInt(_reader);
            int b = Common.ReadInt(_reader);

            _writer.WriteLine(Sum(a, b));

            CloseReaderAndWriter();
        }

        public static void ReadMultiDigitsFromStream()
        {
            InitReaderAndWriter();

            var numbers = Common.ReadList(_reader);
            _writer.WriteLine(numbers[0] + numbers[1]);

            CloseReaderAndWriter();
        }

        public static void ReadArrayOfNDigits()
        {
            InitReaderAndWriter();

            var n = Common.ReadInt(_reader);
            var numbers = Common.ReadList(_reader);

            for (int i = 0; i < n; i++)
            {
                _writer.Write("{0} ", numbers[i]);
            }

            CloseReaderAndWriter();
        }

        private static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
