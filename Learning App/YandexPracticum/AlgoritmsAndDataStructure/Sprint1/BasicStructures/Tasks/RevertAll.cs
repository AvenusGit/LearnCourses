using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning_App.YandexPracticum.Classes;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks
{
    public class RevertAll : ITask
    {
        public RevertAll(IChapter chapter) { Chapter = chapter; }
        public IChapter Chapter { get; set; }

        public string Number => "H";

        public string Name => "Все наоборот";

        public string Description => "Задача получить от пользователя двухсвязный список и вернуть его наоборот";

        public void BackToMenu()
        {
            Console.WriteLine("Нажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            Chapter.Selector();
        }

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            DoubleLinkedListS<string>? list = null;
            while (list is null)
                list = TaskHelper.GetDoubleNodeHeader();
            Solution(list);
            BackToMenu();
        }

        private void Solution(DoubleLinkedListS<string> list)
        {
            list.Revert();
            list.Print("Вывод перевернутого двухсвязнного списка");
        }
    }
}
