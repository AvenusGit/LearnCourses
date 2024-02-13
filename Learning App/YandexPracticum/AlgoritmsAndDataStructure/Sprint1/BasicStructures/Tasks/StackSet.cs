using Learning_App.YandexPracticum.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks
{
    public class StackSet : ITask
    {
        public StackSet(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "K";

        public string Name => "Уникальный стек";

        public string Description => "Реализовать стек, который хранит только уникальные элементы. Добавление должно быть за О(1)";


        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);

            StackH<int>? stack = null;
            while (stack is null)
                stack = TaskHelper.GetPositiveIntegerStackH();

            stack.Print();
            while (true)
            {
                string? answer = TaskHelper.InputCommand(stack);
                if (answer is null) break;
            }
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
