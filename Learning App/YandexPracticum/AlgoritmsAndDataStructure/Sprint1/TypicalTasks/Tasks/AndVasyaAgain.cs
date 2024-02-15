using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    public class AndVasyaAgain : ITask
    {
        public AndVasyaAgain(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "O";

        public string Name => "И снова Вася";

        public string Description => "Условий задачи не найдено";

        public TaskStatus Status => TaskStatus.NotFound;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            Console.WriteLine("Задача есть в списке, но нет в файлах");
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
