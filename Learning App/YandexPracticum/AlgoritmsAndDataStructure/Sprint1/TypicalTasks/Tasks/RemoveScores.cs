using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    internal class RemoveScores : ITask
    {
        public RemoveScores(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "D";

        public string Name => "Убрать очки";

        public string Description => "Напечатать массив без нулей. Память больше О(1) использовать нельзя.";

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            int[]? values = null;

            while (values is null)
                values = TaskHelper.GetIntArray("Введите числа очков игрока через пробел");

            Console.WriteLine("Итоговые значения:");
            // если просто делать по условию то так
            //foreach (int value in values)
            //{
            //    if(value != 0)
            //        Console.WriteLine(value);
            //}

            // если под удалением считать вынос значений с 0 на край массива (левый или правый то так)
            int arrayEndIndex = 0;
            int currentValue = 0;

            while (currentValue <= values.Length - 1)
            {
                if (values[currentValue] != 0)
                {
                    int tmp = values[currentValue];
                    values[currentValue] = values[arrayEndIndex];
                    values[arrayEndIndex] = tmp;
                    arrayEndIndex++;
                    currentValue++;
                }
                else
                {
                    currentValue++;
                }
            }
            foreach (int value in values)
            {
                if (value == 0)
                    break;
                Console.WriteLine($"   {value}");
            }

            TaskHelper.BackToMenu(Chapter);
        }
    }
}
