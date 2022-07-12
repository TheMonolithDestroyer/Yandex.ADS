using System;
using System.Collections.Generic;
using System.Linq;

namespace Yandex.Practicum.Sprints.Sprint3
{
    public class CatalanNumber : BaseClass
    {
        public static void Execute()
        {
            InitReaderAndWriter();

            int n = Common.ReadInt(_reader);
            
            _writer.WriteLine($"Catalan number of {n}: {FindCatalan(n)}");

            CloseReaderAndWriter();
        }

        public static int FindCatalan(int n)
        {
            if (n == 0)
                return 1;

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int> { { 0, 1 } };

            int i = 1;
            while(i <= n)
            {
                int result = 0;
                int j = 0, k = keyValuePairs.Count - 1;
                while (k >= 0 && j < keyValuePairs.Count)
                {
                    result += keyValuePairs[j] * keyValuePairs[k];

                    j++;
                    k--;
                }
                keyValuePairs.Add(i, result);
                
                i++;
            }

            return keyValuePairs.Last().Value;
        }
    }
}
