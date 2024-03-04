using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms.Tasks
{
    internal class StockExchange : ITask
    {
        public StockExchange(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "B";

        public string Name => "Биржа";

        public string Description => "Релизовать алгоритм подсчета прибыли на бирже";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                int[]? values = null;
                while(values is null)
                {
                    values = TaskHelper.GetIntArray("Введите цены на бирже через пробел, для выхода введите 999");
                }

                if (values[0] == 999)
                    break;

                int profit = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    if (i == values.Length - 1)
                        break;
                    if (values[i] < values[i+1])
                        profit += values[i + 1] - values[i];
                }
                Console.WriteLine($"Максимальная прибыль:{profit}");
            }
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
