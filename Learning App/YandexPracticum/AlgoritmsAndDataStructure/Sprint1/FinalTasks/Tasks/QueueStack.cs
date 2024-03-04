using Learning_App.YandexPracticum.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.FinalTasks.Tasks
{
    internal class QueueStack : ITask
    {
        public QueueStack(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "C";

        public string Name => "Стековая очередь";

        public string Description => "Реализовать очередь полностью на стеках";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);

            QueueStacky<int>? stack = null;
            while (stack is null)
                stack = TaskHelper.GetQueueStacky();

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
