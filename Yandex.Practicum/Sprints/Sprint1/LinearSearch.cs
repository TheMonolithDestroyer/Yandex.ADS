using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class LinearSearch : BaseClass
    {
        public static void MainLinearSearch()
        {
            InitReaderAndWriter();

            var x = Common.ReadInt(_reader);
            var numbers = Common.ReadArray(_reader);

            _writer.WriteLine(GetResult());

            int GetResult()
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == x)
                    {
                        return i;
                    }
                }

                return -1;
            }

            CloseReaderAndWriter();
        }
    }
}
