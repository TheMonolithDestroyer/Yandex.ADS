using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class Task9 : BaseClass
    {
        public static void MainTask9()
        {
            InitReaderAndWriter();

            int number = Common.ReadInt(_reader);

            string result;
            if (number == 1)
                result = "True";

            int multiplier = 1;
            while(multiplier < number)
            {
                multiplier *= 4;
            }

            result = multiplier == number ? "True" : "False";

            _writer.WriteLine(result);
            CloseReaderAndWriter();
        }
    }
}
