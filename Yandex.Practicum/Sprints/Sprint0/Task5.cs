using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint0
{
    public class Task5 : BaseClass
    {
        public static void MainTask5()
        {
            InitReaderAndWriter();

            int chipsLength = Common.ReadInt(_reader);
            int[] chips = Common.ReadArray(_reader);
            int x = Common.ReadInt(_reader);

            var result = TwoSumWithSort(chipsLength, chips, x);

            if (result == null)
            {
                _writer.WriteLine("None");
            }
            else
            {
                _writer.WriteLine(string.Join(" ", result));
            }

            CloseReaderAndWriter();
        }

        private static int[] TwoSumWithSort(int chipsLength, int[] chips, int x)
        {
            Array.Sort(chips);

            int left = 0;
            int right = chipsLength - 1;
            while (left < right)
            {
                int currentSum = chips[left] + chips[right];

                if (currentSum == x)
                {
                    return new int[2] { chips[left], chips[right] };
                }

                if (currentSum < x)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return null;
        }
    }
}
