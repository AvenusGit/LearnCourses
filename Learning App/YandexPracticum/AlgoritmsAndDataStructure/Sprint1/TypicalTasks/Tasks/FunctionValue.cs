using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    public class FunctionValue : ITask
    {
        public FunctionValue(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "A";

        public string Name => "Значения функции";

        public string Description => "Реализовать функцию, возвращающую результат y=ax^2+bx+c";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            Console.WriteLine("Для выполнения задачи ожидается ввод переменных a,b,c,x");
            int? a = null;
            while (a is null) 
            {
                a = TaskHelper.GetIntUserInput("Введите а:");
            }
            int? b = null;
            while (b is null)
            {
                b = TaskHelper.GetIntUserInput("Введите b:");
            }
            int? c = null;
            while (c is null)
            {
                c = TaskHelper.GetIntUserInput("Введите c:");
            }
            int? x = null;
            while (x is null)
            {
                x = TaskHelper.GetIntUserInput("Введите x:");
            }
            Console.WriteLine($"Результат функции:{(a * (x * x)) + (b * x) + c}");
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
