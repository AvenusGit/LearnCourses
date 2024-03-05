using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms.Tasks
{
    public class Mortgage : ITask
    {
        public Mortgage(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "K";

        public string Name => "Ипотека";

        public string Description => "Определить максимальное число домов, которое по стоимости меньше указанной суммы";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                int[]? values = null;
                while (values is null)
                    values = TaskHelper.GetIntArray("Введите стоимости домов", false);

                int? summ = null;
                while (summ is null)
                    summ = TaskHelper.GetCount("Введите ограничение по общей стоимости. Для выхода введите 999");

                if (summ == 999) break;

                int maxCount = 0, currentSumm = 0;
                values = values.OrderBy(house => house).ToArray();
                for (int i = 0; i < values.Length; i++)
                {
                    if (currentSumm + values[i] > summ)
                        break;
                    else 
                    {
                        maxCount++;
                        currentSumm += values[i];
                    }                    
                }

                Console.WriteLine($"Максимальное количество домов, которое можно купить: {maxCount}");
            }
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
