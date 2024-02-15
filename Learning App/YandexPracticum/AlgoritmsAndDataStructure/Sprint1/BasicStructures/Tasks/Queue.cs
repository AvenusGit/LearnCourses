using Learning_App.YandexPracticum.Classes;


namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks
{
    public class Queue : ITask
    {
        public Queue(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "M";

        public string Name => "Очередь";

        public string Description => "Реализовать очередь со всеми ее методами";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);

            QueueS<int>? queue = null;
            while (queue is null)
                queue = TaskHelper.GetPositiveIntegerQueue();

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
