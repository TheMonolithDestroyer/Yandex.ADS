using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class Task10 : BaseClass
    {
        public static void MainTask10()
        {
            InitReaderAndWriter();

            int number = Common.ReadInt(_reader);

            var result = GetPrimes(number).OrderBy(i => i).ToList();

            _writer.WriteLine(string.Join(' ', result));

            CloseReaderAndWriter();
        }

        private static int GetLowestPrimeFactor(int number)
        {
            if (number % 2 == 0)
            {
                return 2;
            }

            for (int i = 3; i <= number; i += 2)
            {
                if (number % i == 0)
                    return i;
            }

            return number;
        }

        private static List<int> GetPrimes(int number)
        {
            var factors = new List<int>();

            while (number > 1)
            {
                var lowest = GetLowestPrimeFactor(number);

                number /= lowest;
                factors.Add(lowest);
            }

            return factors;
        }
    }
}
