using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class MostActivePassenger : BaseClass
    {
        public static void MainMostActivePassenger()
        {
            InitReaderAndWriter();

            // Массив номеров каждого пассажира
            var passenger = Common.ReadArray(_reader);
            var entriesByVisitor = new Dictionary<int, int>();
            var bestPassenger = 0;

            // Создаем словарь, где ключ - номер пассажира и значение - число поездок
            for (int i = 0; i < passenger.Length; i++)
            {
                if (!entriesByVisitor.ContainsKey(passenger[i]))
                {
                    entriesByVisitor.Add(passenger[i], 0);
                }
            }

            for (int i = 0; i < passenger.Length; i++)
            {
                entriesByVisitor[passenger[i]]++;
                if (entriesByVisitor[passenger[i]] > entriesByVisitor[bestPassenger])
                {
                    bestPassenger = passenger[i];
                }
            }


            _writer.WriteLine(bestPassenger);

            CloseReaderAndWriter();
        }
    }
}
