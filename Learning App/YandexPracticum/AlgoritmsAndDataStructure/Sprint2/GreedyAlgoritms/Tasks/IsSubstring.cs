using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms.Tasks
{
    public class IsSubstring : ITask
    {
        public IsSubstring(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "C";

        public string Name => "Подпоследовательность";

        public string Description => "Проверить, является ли одна строка подстрокой для другой";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                string? fullString = null;                
                while(fullString is null)
                {
                    Console.WriteLine("Введите строку в которой будем искать, для выхода введите <exit>");
                    fullString = Console.ReadLine();
                }

                if (fullString == "exit")
                    break;

                string? subString = null;
                while (subString is null)
                {
                    Console.WriteLine("Введите строку, которую будем искать");
                    subString = Console.ReadLine();
                }              

                Console.WriteLine($"Строка <{subString}>{(TaskHelper.IsUnderSubstring(subString,fullString) ? "" : " не")} " +
                    $"является подпоследовательностью строки <{fullString}> ");
            }
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
