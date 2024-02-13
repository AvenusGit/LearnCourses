using Learning_App.YandexPracticum.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks
{
    public class LinkedQueue : ITask
    {
        public LinkedQueue(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "P";

        public string Name => "Списочная очередь";

        public string Description => "Реализовать очередь с использованием связанного списка";

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            LinkedQueueS<int>? linkedQueue = null;
            while(linkedQueue is null)
            {
                linkedQueue = TaskHelper.GetPositiveIntegerLinkedQueue();
            }
            while (true)
            {
                string? answer = TaskHelper.InputCommand(linkedQueue);
                if (answer is null) break;
            }
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
