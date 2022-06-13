using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class Task5 : BaseClass
    {
        public static void MainTask5()
        {
            InitReaderAndWriter();

            var textLength = Common.ReadInt(_reader);
            var text = Common.ReadStringArray(_reader);

            int maxSubStrLength = 0;
            string mostLongSubStr = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                if (maxSubStrLength < text[i].Length)
                {
                    maxSubStrLength = text[i].Length;
                    mostLongSubStr = text[i];
                }
            }

            _writer.WriteLine(mostLongSubStr);
            _writer.WriteLine(maxSubStrLength);

            CloseReaderAndWriter();
        }
    }
}
