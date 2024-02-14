using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    public class HomeWork : ITask
    {
        public HomeWork(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "E";

        public string Name => "Работа из дома";

        public string Description => "Реализовать метод превращения десятичного числа в двоичное";

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            bool exit = false;
            while (!exit)
            {
                int? value = null;
                while (value is null)
                    value = TaskHelper.GetCount("Введите десятичное число, для выхода введите 999");

                if (value == 999)
                {
                    exit = true;
                    break;
                }
                Console.WriteLine($"Число {value} в двоичной форме это {TaskHelper.IntToBinaryString(value.Value)}");
            }
            
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
