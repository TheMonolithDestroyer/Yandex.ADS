using System;
using System.Numerics;

namespace Yandex.Practicum.Sprints.Sprint2
{
    #region Examples
    // x mod 10^k = x % 10^k
    // 1) 3(3) 1 - 3
    // 2) 10(89) 1 - 9
    // 3) 8(34) 5 - 34
    // 4) 20(10946) 2 - 46
    // 5) 21(17711) 4 - 7711
    // 6) 100(573147844013817200000) 6 - 200000
    // 7) 50(20365011074) 8 - 65011074
    // 8) 30(1346269) 7 - 1346269
    // 9) 1(1) 5 - 1
    // 10) 0(1) 2 - 1 
    #endregion
    public class TaskL : BaseClass
    {
        /// <summary>
        /// Фибоначчи по модулю
        /// </summary>
        public static void Execute()
        {
            InitReaderAndWriter();

            int[] inputs = Common.ReadArray(_reader);

            int mod = 1;
            while (inputs[1] != 0)
            {
                mod *= 10;
                inputs[1]--;
            }

            var result = GetFibonacci(inputs[0], mod);

            _writer.WriteLine(result % mod);

            CloseReaderAndWriter();
        }

        static int GetFibonacci(int trainess, int mod)
        {
            int result = 1;
            if (trainess == 0 || trainess == 1)
            {
                return result;
            }

            int a = 1;
            int b = 1;
            int count = 2;
            while (count <= trainess)
            {
                result = (a + b) % mod;
                a = b % mod;
                b = result;

                count++;
            }

            return result;
        }
    }
}