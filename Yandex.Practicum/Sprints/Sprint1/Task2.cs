using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class Task2 : BaseClass
    {
        public static void MainTask2()
        {
            InitReaderAndWriter();

            var numbers = Common.ReadArray(_reader);

            var a = numbers[0] % 2 == 0;
            var b = numbers[1] % 2 == 0;
            var c = numbers[2] % 2 == 0;

            if ((!a && !b && !c) || (a && b && c))
                _writer.WriteLine("WIN");
            else
                _writer.WriteLine("FAIL");

            CloseReaderAndWriter();
        }
    }
}
