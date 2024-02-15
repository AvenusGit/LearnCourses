using Learning_App.YandexPracticum.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks
{
    public class Dequeu : ITask
    {
        public Dequeu(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "Q";

        public string Name => "Дек";

        public string Description => "Создать структура данных - дек, не используя при этом связанный список";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name,Description);
            int[]? values = null;
            while(values is null)
            {
                values = TaskHelper.GetIntArray("Введите через пробел числа для заполнения дека");
            }
            DequeueS<int> dequeu = new DequeueS<int>(values);
            while (true)
            {
                string? answer = TaskHelper.InputCommandDequeu(dequeu);
                if (answer is null) break;
            }
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
