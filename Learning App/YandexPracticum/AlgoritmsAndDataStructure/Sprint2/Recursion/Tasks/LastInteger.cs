using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.Recursion.Tasks
{
    internal class LastInteger : ITask
    {
        public LastInteger(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "D";

        public string Name => "Последняя цифра";

        public string Description => "Вывести последнюю цифру n числа Фибоначчи";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                int? index = null;
                while (index is null)
                {
                    index = TaskHelper.GetCount("Введите индекс в последовательности Фибонначи, для выхода введите 999");
                    if (index < 0)
                    {
                        Console.WriteLine("Индекс не может быть отрицательным");
                        index = null;
                    }
                }

                if (index == 999)
                    break;

                Console.WriteLine($"Последним числом {index} индекса в последовательности Фибоначчи является {FindLastIndex(index.Value)}");
            }
            TaskHelper.BackToMenu(Chapter);
        }

        private int FindLastIndex(int index, int currentIteration = 1, int prePreviousValue = 0, int previousValue = 1)
        {
            if (index == 0) return 1;
            if (index == currentIteration)
                return (previousValue + prePreviousValue) % 10;
            return FindLastIndex(index, currentIteration + 1, previousValue, (prePreviousValue + previousValue) % 10);
        }
    }
}
