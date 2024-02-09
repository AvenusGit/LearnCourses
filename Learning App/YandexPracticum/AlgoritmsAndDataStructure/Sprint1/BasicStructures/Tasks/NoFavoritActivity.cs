using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Node<string>? head = null;
            while (head is null)
            {
                head = TaskHelper.GetNodeHeader();
            }
            while (deleteIndex is null)
            {
                deleteIndex = TaskHelper.GetCount("Укажите индекс удаляемого элемента коллекции");
            }
            Solution(head,deleteIndex.Value);
            //Console.WriteLine("Эта задача не требует ввода, смотри код");
            BackToMenu();
        }

        private void Solution(Node<string> head, int deletedIndex)
        {
            if (deletedIndex == 0)
            {
                if (head.NextNode is not null)
                {
                    TaskHelper.PrintNode(head.NextNode, "Список с удаленным элементом:");
                    return;
                }
                else
                {
                    Console.WriteLine("Удален единственный элемент");
                    return;
                }
            }
            else
            {
                Node<string>? selectedNode = null;
                Node<string>? currentNode = head;
                for (int i = 1; i < deletedIndex + 2; i++)
                {
                    currentNode = currentNode.NextNode;
                    if(currentNode is null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Индекс удаляемого элемента больше длинны списка");
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }
                    if (i == deletedIndex - 1)
                    {                        
                        selectedNode = currentNode;
                    }                        
                    if (i == deletedIndex + 1)
                    {
                        selectedNode!.NextNode = currentNode;
                        TaskHelper.PrintNode(head, "Список с удаленным элементом:");
                        return;
                    }
                }
            }            
        }
    }
}
