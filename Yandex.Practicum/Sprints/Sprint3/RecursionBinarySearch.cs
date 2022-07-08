using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint3
{
    public class RecursionBinarySearch : BaseClass
    {
        public static void Execute()
        {
            InitReaderAndWriter();

            int[] arr = Common.ReadArray(_reader);
            int item = Common.ReadInt(_reader);

            Array.Sort(arr);

            var re = FindItem(arr, item, 0, arr.Length - 1);

            _writer.WriteLine(re);
            _writer.Close();

            CloseReaderAndWriter();
        }

        private static int FindItem(int[] arr, int item, int left, int right)
        {
            if (right <= left)
                return arr[right] == item ? right : -1;

            int mid = (left + right) / 2;

            if (item == arr[mid])
                return mid;
            else if (item < arr[mid])
                return FindItem(arr, item, left, mid);
            else
                return FindItem(arr, item, mid + 1, right);
        }
    }
}
