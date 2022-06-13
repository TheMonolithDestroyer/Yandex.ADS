using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class PrimeNumbers : BaseClass
    {
        public static void MainPrimeNumbers()
        {
            InitReaderAndWriter();

            var number = Common.ReadInt(_reader);

            var result = IsPrimeEratosphenLinear(number);

            _writer.WriteLine(string.Join(' ', result));
            
            CloseReaderAndWriter();
        }

        private static int[] IsPrimeEratosphenLinear(int number)
        {
            // Если число простое, его наименьший простой делитель — оно само.
            // Если число составное, его наименьший простой делитель pp уже встречался раньше.
            var leastPrimes = new int[number + 1];
            var primes = new List<int>();

            for (int i = 2; i < leastPrimes.Length; i++)
            {
                if (leastPrimes[i] == 0)
                {
                    leastPrimes[i] = i;
                    primes.Add(i);
                }

                foreach (var p in primes)
                {
                    if (p <= leastPrimes[i] && p * i <= number)
                    {
                        leastPrimes[p * i] = p;
                    }
                }
            }

            return primes.ToArray();
        }

        private static Dictionary<int, bool> IsPrimeEratosphen(int number)
        {
            var dict = new Dictionary<int, bool>
            {
                { 0, false },
                { 1, false }
            };

            for (int i = 2; i <= number; i++)
            {
                dict[i] = true;
            }

            for (int i = 2; i < number; i++)
            {
                if (dict[i] == false)
                    continue;

                for (int j = i; j <= dict.Count; j += i)
                {
                    if (i != j)
                    {
                        dict[j] = false;
                    }
                }
            }

            return dict;
        }

        private static bool IsPrime(int number)
        {
            if (number == 1)
                return false;

            int count = 2;
            while(count * count <= number)
            {
                if (number % count == 0)
                    return false;

                count++;
            }

            return true;
        }
    }
}
