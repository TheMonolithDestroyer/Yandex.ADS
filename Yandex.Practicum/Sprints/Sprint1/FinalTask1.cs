using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class FinalTask1 : BaseClass
    {
		// 1) [0, 1, 4, 9, 0] = [0, 1, 2, 1, 0]
		// 2) [0, 7, 9, 4, 8, 20] = [0, 1, 2, 3, 4, 5]
		// 3) [0] = [0]
		// 4) [0, 1] = [0, 1]
		// 5) [0, 0, 0, 0, 0] = [0, 0, 0, 0, 0]
		// 6) [0, 0, 1, 0, 0] = [0, 0, 1, 0, 0]
		// 7) [1, 3, 5, 7, 0, 2, 4, 6, 8, 9] = [4, 3, 2, 1, 0, 1, 2, 3, 4, 5]
		// 8) [1, 0, 10^4, 0, 10^9, 10^7, 2, 5, 0] = [1, 0, 1, 0, 1, 2, 2, 1, 0]
		// 9) [999, 888, 454, 19, 2, 64, 72, 0] = [7, 6, 5, 4, 3, 2, 1, 0]
		// 10) [0, 1, 0, 5, 0, 10, 0, 91] = [0, 1, 0, 1, 0, 1, 0, 1]

		public static void Execute()
		{
			InitReaderAndWriter();

			int streetLength = Common.ReadInt(_reader);
			int[] blocks = Common.ReadArray(_reader);

			int distance = 1000000001;
			int[] result = new int[streetLength];
			for (int i = 0; i < streetLength; i++)
            {
				if (blocks[i] == 0)
                {
					distance = 0;
					break;
				}
				else
                {
					if (distance == 1000000001)
                    {
						result[i] = distance;
                    }
                    else
                    {
						distance += 1;
						result[i] = distance;
					}
				}
            }

            for (int i = streetLength - 1; i >= 0; i--)
            {
				if (result[i] == 0)
                {
					distance = 0;
                }
                else
                {
					distance += 1;
					if (distance < result[i])
                    {
						result[i] = distance;
                    }
                }
			}

			_writer.WriteLine(string.Join(' ', result));
			CloseReaderAndWriter();
		}
	}
}
