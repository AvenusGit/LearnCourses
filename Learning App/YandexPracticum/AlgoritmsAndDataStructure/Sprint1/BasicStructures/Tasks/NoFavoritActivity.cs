using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning_App.YandexPracticum.Classes;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks
{
    public class NoFavoritActivity : ITask
    {
        public NoFavoritActivity(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "F";

        public string Name => "Нелюбимое дело";

        public string Description => "Написать метод который принимает голову односвязного списка," +
            " удалит элемент самодельного связанного списка по номеру N и снова вернет голову списка";

        public void BackToMenu()
        {
            Console.WriteLine("Нажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            Chapter.Selector();
        }

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            int? deleteIndex = null;
            LinkedListS<string>? head = null;
            while (head is null)
            {
                head = TaskHelper.GetNodeHeader();
            }
            while (deleteIndex is null)
            {
                deleteIndex = TaskHelper.GetCount("Укажите индекс удаляемого элемента коллекции");
            }
            Solution(head,deleteIndex.Value);
            BackToMenu();
        }

        private void Solution(LinkedListS<string> list, int deletedIndex)
        {            
            try
            {
                list.RemoveAt(deletedIndex);
                list.Print("Список поле удаления элемента:");
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }
    }
}
