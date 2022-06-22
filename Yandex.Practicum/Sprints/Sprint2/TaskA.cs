using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint2
{
    public class TaskA : BaseClass
    {
		// «входные данные» — «ожидаемый результат»
		// 4, 3
		// 1 2 3, 0 2 6, 7 4 1, 2 7 0 
		// 1 0 7 2, 2 2 4 7, 3 6 1 0

		// 9, 5
		// -7 -1 0 -4 -9, 5 -1 2 2 9, 3 1 -8 -1 -7, 9 0 8 -8 -1, 2 4 5 2 8, -7 10 0 -4 -8, -3 10 -7 10 3, 1 6 -7 -5 9, -1 9 9 1 9
		// -7 -1 3 9 2 -7 -3 1 -1, -1 -1 1 0 4 10 10 6 9, -0 2 -8 8 5 0 -7 -7 9, -4 2 -1 -8 2 -4 10 -5 1, -9 9 -7 -1 8 -8 3 9 9

		// 4, 4
		// 1 2 3 4, 4 5 6 7, 7 8 9 0, 0 1 2 3
		// 1 4 7 0, 2 5 8 1, 3 6 9 2, 4 7 0 3

		// 1, 6
		// -1 0 10 100 -14 -156
		// 1, 0, 10, 100, -14, -156

		// 7, 1
		// 0, -5, -15, -100, 4, 86, 123
		// 0 -5 -15 -100 4 86 123

		// 1, 1
		// 40 
		// 40

		// 0, 0
		// empty, empty

		// -3, -4
		// empty, empty
		public static void MainTaskA()
		{
			InitReaderAndWriter();

			int rowCount = Common.ReadInt(_reader);
			int colCount = Common.ReadInt(_reader);

			if (rowCount <= 0 || colCount <= 0)
			{
				_writer.Write("");
				CloseReaderAndWriter();
				return;
			}

			int[,] result = new int[colCount, rowCount];
			for (int row = 0; row < rowCount; row++)
			{
				int[] rowValues = Common.ReadArray(_reader);
				for (int col = 0; col < colCount; col++)
				{
					result[col, row] = rowValues[col];
				}
			}

			for (int i = 0; i < colCount; i++)
			{
				for (int j = 0; j < rowCount; j++)
				{
					if (j < rowCount - 1)
						_writer.Write(result[i, j] + " ");
					else
						_writer.Write(result[i, j]);
				}

				_writer.WriteLine();
			}

			CloseReaderAndWriter();
		}
	}
}
