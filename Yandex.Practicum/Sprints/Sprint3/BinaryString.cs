using System;

namespace Yandex.Practicum.Sprints.Sprint3
{
    public class BinaryString : BaseClass
    {
        public static void Execute()
        {
            var a = Sum(5);
        }

        private static string BinaryToDecimalWithRecursion(int number)
        {
            if (number < 0)
                return "-" + BinaryToDecimalWithRecursion(- number);

            if (number == 0 || number == 1)
                return number.ToString();

            return BinaryToDecimalWithRecursion(number / 2) + (number % 2).ToString();
        }

        private static int Sum(int number, int s = 0)
        {
            if (number == 0)
                return s;
            
            return Sum(number - 1, s + number);
        }
    }
}