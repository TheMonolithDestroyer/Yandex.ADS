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

			//List<int> emptyBlocks = new List<int>();
			//for (int i = 0; i < streetLength; i++)
			//	if (blocks[i] == 0)
			//		emptyBlocks.Add(i);

			int? emptyBlock = null;
			int[] result = new int[streetLength];
			for (int i = 0; i < streetLength; i++)
			{
				if (blocks[i] == 0)
				{
					result[i] = 0;
					emptyBlock = i;
					continue;
				}

				int? nextEmptyBlock = null;
				for (int j = i; j < blocks.Length; j++)
				{
					if (blocks[j] != 0)
						continue;

					nextEmptyBlock = blocks[j];
				}

				int distance = 0;
				if (emptyBlock != null && nextEmptyBlock == null)
                {
					distance = i - emptyBlock.Value;
                }
				else if (emptyBlock == null && nextEmptyBlock != null)
                {
					distance = nextEmptyBlock.Value - i;
                }
                else
                {
					int leftDistance = i - emptyBlock.Value;
					int rightDistance = nextEmptyBlock.Value - i;
					distance = leftDistance > rightDistance ? rightDistance : leftDistance;
                }

				result[i] = distance;
				//int? distance = null;
				//foreach (var j in emptyBlocks)
				//{
				//	var nextDistance = i - j;
				//	if (nextDistance < 0)
				//		nextDistance *= -1;

				//	if (!distance.HasValue || (distance.HasValue && distance > nextDistance))
				//	{
				//		distance = nextDistance;
				//	}
				//}

				//result[i] = distance.Value;
			}

			_writer.WriteLine(string.Join(' ', result));

			CloseReaderAndWriter();
		}
	}
}
