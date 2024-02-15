using Learning_App.YandexPracticum.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.FinalTasks.Tasks
{
    internal class Cycles : ITask
    {
        public Cycles(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "B";

        public string Name => "Циклы";

        public string Description => "Написать метод, который определяет закциклен ли связанный список";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                LinkedListS<string>? linkedList = null;
                while(linkedList is null)
                {
                    linkedList = TaskHelper.GetNodeHeader("Введите слова для значений нод через пробел. Для выхода введите <exit>");
                }

                if(linkedList.Header!.Value == "exit")
                    break;

                if(linkedList.Header.NextNode is null)
                {
                    Console.WriteLine("Связанный список из одного элемента не может быть зациклен");
                    continue;
                }

                // сделаем так, чтобы если значения головы и хвоста совпадают - список зацикливался
                Node<string> current = linkedList.Header;
                while(current.NextNode is not null)
                {
                    current = current.NextNode;
                    if(current.NextNode is null && current.Value == linkedList.Header.Value)
                    {
                        current.NextNode = linkedList.Header;
                        break;
                    }                        
                }
                

                Console.WriteLine($"Этот связанный список{(linkedList.IsCycled() ? "" : " не")} зациклен");
            }
            TaskHelper.BackToMenu(Chapter);
        }

    }
}
