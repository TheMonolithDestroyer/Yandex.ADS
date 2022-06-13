using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class Task1 : BaseClass
    {
        public static void MainTask1()
        {
            InitReaderAndWriter();

            var numbers = Common.ReadArray(_reader);

            var result = (numbers[0] * Math.Abs(numbers[1] * numbers[1])) + (numbers[2] * numbers[1]) + numbers[3];

            _writer.WriteLine(result);

            CloseReaderAndWriter();
        }
    }
}
