using Learning_App.YandexPracticum.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks
{
    internal class StackMaxEffictive : ITask
    {
        public StackMaxEffictive(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "J";

        public string Name => "Стек - Эффективный максимум";

        public string Description => "Найти максимум за О(1)";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);

            StackM<int>? stack = null;
            while (stack is null)
                stack = TaskHelper.GetPositiveIntegerStackM();

            stack.Print();
            while (true)
            {
                string? answer = TaskHelper.InputCommandStackM(stack);
                if (answer is null) break;
            }
            Console.WriteLine($"Максимальное значение в стеке: {stack.GetMax()}");
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
