using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint0
{
    public class Task4 : BaseClass
    {
        public static void MainTask4()
        {
            InitReaderAndWriter();

            int chipsLength = Common.ReadInt(_reader);
            int[] chips = Common.ReadArray(_reader);
            int x = Common.ReadInt(_reader);

            var result = GetTwoChips(chipsLength, chips, x);

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

        private static int[] GetTwoChips(int chipsLength, int[] chips, int x)
        {
            for (int i = 0; i < chipsLength; i++)
            {
                for (int j = i + 1; j < chipsLength; j++)
                {
                    if (chips[i] + chips[j] != x)
                    {
                        continue;
                    }

                    return new int[2] { chips[i], chips[j] };
                }
            }

            return null;
        }
    }
}
