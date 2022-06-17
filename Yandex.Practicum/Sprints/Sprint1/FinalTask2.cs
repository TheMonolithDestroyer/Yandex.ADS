using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
	public class FinalTask2 : BaseClass
	{
		public static void Execute()
		{
			InitReaderAndWriter();

			int keyCountToPress = Common.ReadInt(_reader);

            var keyCounts = new int[10];
			for (int i = 0; i < 4; i++)
			{
				var row = Common.ReadString(_reader);
				for (int j = 0; j < 4; j++)
                {
                    if (row[j] != '.')
                    {
                        keyCounts[row[j] - '0']++;
                    }
                }
			}

            int points = 0;
            for (int i = 1; i <= 9; i++)
            {
                var keyCount = keyCounts[i];
                if (keyCount > 0 && keyCount <= keyCountToPress * 2)
                {
                    points++;
                }
            }

            _writer.WriteLine(points);
            CloseReaderAndWriter();
		}
	}
}
