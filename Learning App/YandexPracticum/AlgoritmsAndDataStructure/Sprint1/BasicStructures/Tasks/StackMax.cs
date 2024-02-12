using Learning_App.YandexPracticum.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks
{
    public class StackMax : ITask
    {
        public StackMax(IChapter chapter) { Chapter = chapter; }
        public IChapter Chapter { get; set; }

        public string Number => "I";

        public string Name => "Стек - Макс";

        public string Description => "Задача реализовать стек и метод в нем на вычисление максимального значения";

        public void BackToMenu()
        {
            Console.WriteLine("Нажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            Chapter.Selector();
        }

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);

            StackS<int>? stack = null;
            while (stack is null)
                stack = TaskHelper.GetPositiveIntegerStack();

            stack.Print();
            Console.WriteLine($"Максимальное значение в стеке: {stack.GetMax()}");
            BackToMenu();
        }
    }
}
