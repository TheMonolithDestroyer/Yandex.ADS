using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint3
{
    public class ZeroOneSequenceGeneration : BaseClass
    {
        public static void Execute()
        {
            InitReaderAndWriter();

            int n = Common.ReadInt(_reader);
            string prefix = string.Empty;

            GenerateZeroOnes(n, prefix);

            CloseReaderAndWriter();
        }

        private static void GenerateZeroOnes(int n, string prefix)
        {
            if (n == 0)
            {
                _writer.Write(prefix.Replace('0', '(').Replace('1', ')'));
                return;
            }
            else
            {
                GenerateZeroOnes(n - 1, prefix + '0');
                GenerateZeroOnes(n - 1, prefix + '1');
            }
        }
    }
}
