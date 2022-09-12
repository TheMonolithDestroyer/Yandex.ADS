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

            int[] arr = new int[12] { 1, 2, 3, 4, 7, 5, 6, 9, 10, 22, 54, 55 };//Common.ReadArray(_reader);
            int item = 55;

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
