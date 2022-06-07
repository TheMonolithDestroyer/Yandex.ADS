using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Iterations.Iteration1
{
    public class Task1 : BaseClass
    {
        public Task1()
        {
            InitReaderAndWriter();

            int a = ReadInt();
            int b = ReadInt();

            _writer.WriteLine(a + b);

            CloseReaderAndWriter();
        }

        private int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }
    }
}
