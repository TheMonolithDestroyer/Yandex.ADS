using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class HappyTicket : BaseClass
    {
        public static void MainHappyTicket()
        {
            InitReaderAndWriter();

            var number = Common.ReadInt(_reader);

            var result = IsTicketHappy(number);
            _writer.WriteLine(result);

            CloseReaderAndWriter();
        }

        private static bool IsTicketHappy(int number)
        {
            int digitCount = (int)Math.Floor(Math.Log10(number) + 1);
            int evenSum = 0;
            int oddSum = 0;

            while (number > 0)
            {
                var lastDigit = number % 10;
                if (digitCount % 2 == 0)
                {
                    evenSum += lastDigit;
                }
                else
                {
                    oddSum += lastDigit;
                }
                number /= 10;
                digitCount--;
            }
            
            return evenSum == oddSum;
        }
    }
}
