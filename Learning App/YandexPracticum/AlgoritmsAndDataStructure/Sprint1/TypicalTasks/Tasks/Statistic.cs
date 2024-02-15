using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    internal class Statistic : ITask
    {
        public Statistic(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "Q";

        public string Name => "Статистика";

        public string Description => "Среди троек введенных чисел, где сумма равна нулю, а произведение положительное " +
            "\r    необхожимо найти максимальное произведение";

        public TaskStatus Status => TaskStatus.InProgress;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                int[]? values = null;
                while(values is null)
                    values = TaskHelper.GetIntArray("Введите числа, для выхода введите 999", false);

                if (values[0] == 999)
                    break;

                Console.WriteLine($"Искомое значение: {Solution(values)}");
            }
            TaskHelper.BackToMenu(Chapter);
        }

        private int Solution(int[] values)
        {
            int max = -1;
            for (int i = 0, j = 2; j < values.Length; i++, j++)
            {
                int summ = values[i] + values[i + 1] + values[j];
                int mult = values[i] * values[i + 1] * values[j];
                if ( summ == 0 && mult > 0)
                {
                    if(mult > max)
                        max = mult;
                }
            }
            return max;
        }
    }
}
