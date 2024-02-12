using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Learning_App.YandexPracticum.Classes;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks
{
    internal class CarefulMom : ITask
    {
        public CarefulMom(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "G";

        public string Name => "Заботливая мама";

        public string Description => "Задача реализовать метод,который возвращает первое вхождение из связанного списка";

        public void BackToMenu()
        {
            Console.WriteLine("Нажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            Chapter.Selector();
        }

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            LinkedListS<string>? list = null;
            while (list is null)
            {
                list = TaskHelper.GetNodeHeader();
            }
            string? request = null;
            while (request is null)
            {
                Console.WriteLine("Введите искомую строку:");
                request = Console.ReadLine(); ;
            }
            int? result = list.IndexOf(request);
            if (result is null)
                Console.WriteLine($"Искомая строка не найдена в списке");
            else
                Console.WriteLine($"Искомая строка найдена под индексом {result}");
            BackToMenu();
        }
    }
}
