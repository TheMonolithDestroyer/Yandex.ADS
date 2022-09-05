using System;

namespace Yandex.Practicum.Sprints.Sprint3
{
    public class TaskL : BaseClass
    {
        #region Examples
        // 1) 6, 1 2 4 4 6 8, 3 = 3 5
        // 2) 6, 1 2 4 4 4 4, 3 = 3 -1
        // 3) 6, 1 2 3 4 4 5, 10 = -1 -1
        // 4) 7, 0 2 4 6 8 10 12, 12 = 7 -1
        // 5) 8, 2 3 4 7 9 10 13 14, 100 = -1 -1
        // 6) 5, 1 2 3 4 5, 1 = 1 2
        // 7) 5, 1 2 3 4 8, 4 = 4 5
        // 8) 5, 5 5 5 5 5, 3 = 1 -1
        // 9) 5, 1 2 6 6 10, 5 = 3 5
        // 10) 1, 10, 11 = -1 -1
        // 11) 1, 10, 5 = 1 1
        // 12) 2, 1 6, 2 = 2 2
        // 13) 2, 1 6, 4 = 2 -1
        // 14) 2, 1 6, 8 = -1 -1
        #endregion
        public static void Execute()
        {
            InitReaderAndWriter();

            int days = Common.ReadInt(_reader);
            int[] piggyBank = Common.ReadArray(_reader);
            int bykeCost = Common.ReadInt(_reader);

            int oneByke = FindPossibleIndex(piggyBank, bykeCost, 0, days - 1);
            int twoByke = FindPossibleIndex(piggyBank, bykeCost * 2, 0, days - 1);

            _writer.WriteLine(oneByke + " " + twoByke);

            CloseReaderAndWriter();
        }

        private static int FindPossibleIndex(int[] arr, int item, int left, int right)
        {
            if (right <= left)
                return arr[right] >= item ? right + 1 : -1;

            int mid = (left + right) / 2;
            if (item <= arr[mid])
            {
                return FindPossibleIndex(arr, item, left, mid);
            }
            else
            {
                return FindPossibleIndex(arr, item, mid + 1, right);
            }
        }
    }
}
