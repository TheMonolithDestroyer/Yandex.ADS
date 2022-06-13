using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class Task3 : BaseClass
    {
        public static void MainTask3()
        {
            InitReaderAndWriter();

            var row = Common.ReadInt(_reader);
            var col = Common.ReadInt(_reader);
            var matrix = InitArray(row, col);
            var rowIndex = Common.ReadInt(_reader);
            var colIndex = Common.ReadInt(_reader);
            var neighbours = GetNeighbours(matrix, rowIndex, colIndex, row, col);

            _writer.WriteLine(neighbours);

            CloseReaderAndWriter();
        }

        private static int[,] InitArray(int row, int col)
        {
            var martix = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                var rowValue = Common.ReadArray(_reader);
                for (int j = 0; j < col; j++)
                {
                    martix[i, j] = rowValue[j];
                }
            }

            return martix;
        }

        private static string GetNeighbours(int[,] matrix, int rowIndex, int colIndex, int row, int col)
        {
            row--;
            col--;

            List<int> result = new();
            if (rowIndex - 1 >= 0)
                result.Add(matrix[rowIndex - 1, colIndex]);
            
            if (colIndex - 1 >= 0)
                result.Add(matrix[rowIndex, colIndex - 1]);

            if (rowIndex + 1 <= row)
                result.Add(matrix[rowIndex + 1, colIndex]);

            if (colIndex + 1 <= col)
                result.Add(matrix[rowIndex, colIndex + 1]);

            return string.Join(' ', result.OrderBy(i => i));
        }
    }
}
