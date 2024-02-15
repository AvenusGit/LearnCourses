using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    public class Anagramms : ITask
    {
        public Anagramms(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "G";

        public string Name => "Анаграммы";

        public string Description => "Реализовать функцию, определяющею анаграммой ли является введенное слово";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                string? target = null;
                while (target is null)
                {
                    Console.WriteLine("Введите слово, для выхода введите <exit>");
                    target = Console.ReadLine();
                }

                if (target == "exit")
                    break;

                    string? pattern = null;
                while (pattern is null)
                {
                    Console.WriteLine("Введите шаблон");
                    pattern = Console.ReadLine();
                }

                Console.WriteLine($"Слово '{pattern}'{(TaskHelper.IsAnagramm(target, pattern) ? "" : " не")} является анаграммой слову '{target}'");
            }
            TaskHelper.BackToMenu(Chapter);           
        }
    }
}
