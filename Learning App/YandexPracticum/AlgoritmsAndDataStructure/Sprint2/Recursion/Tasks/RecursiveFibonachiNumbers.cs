using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.Recursion.Tasks
{
    public class RecursiveFibonachiNumbers : ITask
    {
        public RecursiveFibonachiNumbers( IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "A";

        public string Name => "Рекурсивные числа Фибоначчи";

        public string Description => "Рассчитать n индекс в полседовательности Фибоначчи";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                int? index = null;
                while(index is null)
                {
                    index = TaskHelper.GetCount("Введите индекс в последовательности Фибонначи, для выхода введите 999");
                    if(index < 0)
                    {
                        Console.WriteLine("Индекс не может быть отрицательным");
                        index = null;
                    }
                    if (index > 30)
                    {
                        Console.WriteLine("Индекс слишком велик для Int32");
                        index = null;
                    }
                }

                if (index == 999)
                    break;

                Console.WriteLine($"{index} индексом в последовательности Фибоначчи является {FindIndex(index.Value)}");
            }
            TaskHelper.BackToMenu(Chapter);
        }

        private int FindIndex(int index, int currentIteration = 1, int prePreviousValue = 0 , int previousValue = 1)
        {
            if(index == 0) return 1;
            if (index == currentIteration)
                return previousValue + prePreviousValue;
            return FindIndex(index, currentIteration + 1, previousValue, prePreviousValue + previousValue);
        }
    }
}
