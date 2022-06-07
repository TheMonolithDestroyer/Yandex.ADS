using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint0
{
    public class Task3 : BaseClass
    {
        public static void MainTask3()
        {
            InitReaderAndWriter();

            int secundsCount = Common.ReadInt(_reader);
            int[] requests = Common.ReadArray(_reader);
            // Окно сглаживания
            int k = Common.ReadInt(_reader);

            var length = requests.Length - k;
            var result = new List<double>();


            double currentSum = 0;
            for (int i = 0; i < k; i++)
            {
                currentSum += requests[i];
            }
            result.Add(currentSum / k);

            var endIndex = 0;
            for (int beginIndex = 1; beginIndex <= length; beginIndex++)
            {
                endIndex = beginIndex + k;
                currentSum -= requests[beginIndex - 1];
                currentSum += requests[endIndex - 1];

                result.Add(currentSum / k);
            }

            _writer.WriteLine(string.Join(" ", result));

            CloseReaderAndWriter();
        }
    }
}
