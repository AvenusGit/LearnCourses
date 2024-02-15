using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    public class Palindrom : ITask
    {
        public Palindrom(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "H";

        public string Name => "Палиндром";

        public string Description => "Определить, являются ли слова палиндромом относительно друг друга. " +
            "\n   Учитываются только буквы и цифры, заглавные и строчные считаются одинаковыми. " +
            "\n   Сложность максимум О(n), память не более O(1)";

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

                Console.WriteLine($"Слово '{target}'{(TaskHelper.IsPalindrom(target) ? "" : " не")} является палиндромом");
            }
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
