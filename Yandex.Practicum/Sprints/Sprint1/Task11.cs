using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class Task11 : BaseClass
    {
        public static void MainTask11()
        {
            InitReaderAndWriter();

            int listFormLength = Common.ReadInt(_reader);
            string listForm = Common.ReadString(_reader);
            int kNumber = Common.ReadInt(_reader);

            string concatedListForm = string.Empty;
            for (int i = 0; i < listForm.Length; i++)
            {
                if (listForm[i] != ' ')
                {
                    concatedListForm += listForm[i];
                }
            }
            
            int xNumber = Convert.ToInt32(concatedListForm);
            int numberResult = xNumber + kNumber;

            string result = string.Empty;
            while (numberResult > 0)
            {
                var middleNumber = numberResult % 10;
                numberResult /= 10;

                result = middleNumber.ToString() + ' ' + result;
            }

            _writer.WriteLine(result.TrimEnd());

            CloseReaderAndWriter();
        }
    }
}
