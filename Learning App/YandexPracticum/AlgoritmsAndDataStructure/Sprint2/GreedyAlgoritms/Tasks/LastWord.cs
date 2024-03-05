using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms.Tasks
{
    internal class LastWord : ITask
    {
        public LastWord(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "J";

        public string Name => "Последнее слово";

        public string Description => "Вернуть длинну последнего слова в строке";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                string? target = null;
                while (String.IsNullOrWhiteSpace(target)) 
                {
                    Console.WriteLine("Введите строку, разделяя слова пробелами. Для выхода введите <exit>");
                    target = Console.ReadLine();
                }

                if(target == "exit") break;

                int wordLenght = 0;
                for (int i = target.Length - 1; target[i] != ' ' ; i--)
                    wordLenght++;

                Console.WriteLine($"Длинна последнего слова: {wordLenght}");
            }
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
