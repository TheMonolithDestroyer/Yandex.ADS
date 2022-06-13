using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint1
{
    public class Task4 : BaseClass
    {
        public static void MainTask4()
        {
            InitReaderAndWriter();

            // Температура воздуха = максимальная температура в этот день
            // Хаотичность погоды за n дней = количество дней, в которые температура строго больше, чем в день ДО и в день ПОСЛЕ

            // длина периода измерений в днях 1 <= n <= 10^5
            var periodLength = Common.ReadInt(_reader);

            // Значения температуры t <= 273
            var chaoticTemperatures = Common.ReadArray(_reader);

            int? left = null, right = null;
            int chaoticTemperaturesCount = 0;
            for (int i = 0; i < periodLength; i++)
            { 
                left = i - 1 >= 0 ? chaoticTemperatures[i - 1] : null;
                right = i + 1 <= periodLength - 1 ? chaoticTemperatures[i + 1] : null;

                if (left.HasValue && right.HasValue && chaoticTemperatures[i] > left.Value && chaoticTemperatures[i] > right.Value)
                {
                    chaoticTemperaturesCount++;
                }
                else if (!left.HasValue && right.HasValue && chaoticTemperatures[i] > right)
                {
                    chaoticTemperaturesCount++;
                }
                else if (left.HasValue && !right.HasValue && chaoticTemperatures[i] > left)
                {
                    chaoticTemperaturesCount++;
                }
            }

            _writer.WriteLine(chaoticTemperaturesCount);

            CloseReaderAndWriter();
        }
    }
}
