using Learning_App.YandexPracticum.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks
{
    public class LimitedQueue : ITask
    {
        public LimitedQueue(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "N";

        public string Name => "Ограниченная очередь";

        public string Description => "Реализовать очередь с ограничением по размеру";

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);

            QueueLimitedS<int>? queue = null;
            while (queue is null)
                queue = TaskHelper.GetPositiveIntegerLimitedQueue();

            queue.Print();
            while (true)
            {
                string? answer = TaskHelper.InputCommand(queue);
                if (answer is null) break;
            }
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
