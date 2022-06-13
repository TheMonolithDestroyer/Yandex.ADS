using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class Task7 : BaseClass
    {
        public static void MainTask7()
        {
            InitReaderAndWriter();

            int number = Common.ReadInt(_reader);

            string result = string.Empty;
           
            do
            {
                var reminder = number % 2;
                number /= 2;
                result = reminder + result;
            }
            while (number > 0);

            _writer.WriteLine(result);

            CloseReaderAndWriter();
        }
    }
}
