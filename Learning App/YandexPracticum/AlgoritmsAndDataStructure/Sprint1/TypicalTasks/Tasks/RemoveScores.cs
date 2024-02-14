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
            foreach (int value in values)
            {
                if(value != 0)
                    Console.WriteLine(value);
            }

            TaskHelper.BackToMenu(Chapter);
        }
    }
}
