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

            _writer.WriteLine("");
            _writer.WriteLine("После сортировки");
            _writer.WriteLine(string.Join(' ', numbers));

            _writer.WriteLine("");
            _writer.WriteLine("Результат наивного алгоритма");
            var naiveResult = NaiveBinarySearch(x, numbers, left, right);
            _writer.WriteLine(naiveResult);

            //_writer.WriteLine("");
            //_writer.WriteLine("Результат оптимизированного алгоритма");
            //var optimizedResult = OptimizedBinarySearch(x, numbers, left, right);
            //_writer.WriteLine(optimizedResult);

            CloseReaderAndWriter();
        }

        //private static int OptimizedBinarySearch(int x, int[] numbers, int left, int right)
        //{
        //    if (x < numbers[left] || x > numbers[right])
        //        return -1;

        //    var iterationCount = Math.Log(right + 1, x);
        //    var count = (int)Math.Round(iterationCount, MidpointRounding.AwayFromZero);

        //    for (int i = 0; i < count; i++)
        //    {

        //    }

        //    return -1;
        //}

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
