using System;

namespace Yandex.Practicum.Sprints.Sprint2
{
    /// <summary>
    /// Рекурсивные числа Фибоначчи
    /// </summary>
    public class TaskK : BaseClass
    {
        public static void Execute()
        {
            InitReaderAndWriter();
            
            int trainee = Common.ReadInt(_reader);

            var commits = ComputeTraineeCommits(trainee);

            _writer.WriteLine(commits);

            CloseReaderAndWriter();
        }

        static int ComputeTraineeCommits(int trainee)
        {
            // 1 1 2 3 5 8 13 21 33 45
            // F1 = 1;
            // F2 = 2;
            // Fn = Fn-1 + Fn-2;

            if (trainee == 0 || trainee == 1)
                return 1;

            return ComputeTraineeCommits(trainee - 1) + ComputeTraineeCommits(trainee - 2);
        }
    }
}