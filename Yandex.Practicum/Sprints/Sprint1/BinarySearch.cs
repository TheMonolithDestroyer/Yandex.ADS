using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class BinarySearch : BaseClass
    {
        public static void MainBinarySearch()
        {
            InitReaderAndWriter();

            var x = Common.ReadInt(_reader);
            var numbers = Common.ReadArray(_reader);
            var left = numbers.GetLowerBound(0);
            var right = numbers.GetUpperBound(0);

            Array.Sort(numbers, left, right + 1);

            var naiveResult = NaiveBinarySearch(x, numbers, left, right);
            _writer.WriteLine(naiveResult);

            CloseReaderAndWriter();
        }

        private static int NaiveBinarySearch(int x, int[] numbers, int left, int right)
        {
            if (x < numbers[left] || x > numbers[right])
                return -1;

            if (right + 1 == 1 && numbers[left] == x)
                return left;

            while (right - left > 1)
            {
                var middle = left + (right - left) / 2;

                if (numbers[middle] == x)
                    return middle;

                if (numbers[middle] > x)
                    right = middle;
                else
                    left = middle;
            }

            if (right - left == 1)
            {
                if (numbers[left] == x)
                    return left;
                else
                    return right;
            }

            return -1;
        }
    }
}
