using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint0
{
    public class Task2 : BaseClass
    {
        public static void MainTask2()
        {
            InitReaderAndWriter();

            var n = Common.ReadInt(_reader);
            var arr1 = Common.ReadList(_reader);
            var arr2 = Common.ReadList(_reader);

            int position = 0;
            int[] result = new int[2 * n];
            for (int i = 0; i < n; i++)
            {
                result[position] = arr1[i];
                result[position + 1] = arr2[i];

                position += 2;
            }

            _writer.WriteLine(string.Join(" ", result));

            CloseReaderAndWriter();
        }

        private void MovingAverageMethod(int k, int[] timeseries)
        {
            var length = timeseries.Length - k;
            var result = new List<decimal>();

            var endIndex = 0;
            for (int beginIndex = 0; beginIndex <= length; beginIndex++)
            {
                endIndex = beginIndex + k;

                decimal currentSum = 0;
                for (int v = beginIndex; v < endIndex; v++)
                {
                    currentSum += timeseries[v];
                }

                decimal currentAvg = currentSum / k;
                result.Add(currentAvg);
            }
        }
    }
}
