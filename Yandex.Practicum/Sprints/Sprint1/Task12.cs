using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class Task12 : BaseClass
    {
        public static void MainTask12()
        {
            InitReaderAndWriter();

            string originalStr = Common.ReadString(_reader);
            string damagedStr = Common.ReadString(_reader);
            damagedStr = string.Concat(damagedStr.OrderBy(i => i));

            string result = string.Empty;
            int i = 0, j = 0;
            while (j >= 0)
            {
                if (i > originalStr.Length - 1 || originalStr[i] != damagedStr[j])
                {
                    result += damagedStr[j];
                    break;
                }

                i++;
                j++;
            }

            _writer.WriteLine(result);

            CloseReaderAndWriter();
        }
    }
}
