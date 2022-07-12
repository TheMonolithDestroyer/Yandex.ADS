using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint3
{
    public class TaskA : BaseClass
    {
        public static void Execute()
        {
            InitReaderAndWriter();

            int n = Common.ReadInt(_reader);

            string prefix = string.Empty;
            PrintPsp(prefix, n, n);

            CloseReaderAndWriter();
        }

        static void PrintPsp(string prefix, int n1, int n2)
        {
            if (n1 > n2) return;

            if (n1 == 0 && n2 == 0)
            {
                _writer.WriteLine(prefix + "\n");
                return;
            }

            if (n1 > 0) PrintPsp(prefix + "(", n1 - 1, n2);
            if (n2 > 0) PrintPsp(prefix + ")", n1, n2 - 1);
        }

    }
}
