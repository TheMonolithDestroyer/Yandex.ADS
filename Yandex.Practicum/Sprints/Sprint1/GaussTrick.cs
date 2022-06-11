using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class GaussTrick : BaseClass
    {
        public static void MainGaussTrick()
        {
            InitReaderAndWriter();

            var numbers = Common.ReadArray(_reader);

            Array.Sort(numbers);

            var result = GetSumOfAllItems(numbers);

            _writer.WriteLine(result);

            CloseReaderAndWriter();
        }


        private static int GetSumOfAllItems(int[] numbers)
        {
            var lastNumber = numbers[^1];
            var left = numbers.GetLowerBound(0);
            var right = numbers.GetUpperBound(0);

            if (right == 1)
                return lastNumber;

            var sum = 0;
            while(left <= right)
            {
                if (left == right)
                {
                    sum += numbers[left];
                    break;
                }

                sum += numbers[left] + numbers[right];

                left++;
                right--;
            }

            return sum;
        }
    }
}
