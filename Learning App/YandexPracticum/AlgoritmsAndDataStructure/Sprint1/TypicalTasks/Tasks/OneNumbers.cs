using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    public class OneNumbers : ITask
    {
        public OneNumbers(IChapter chapter)
        {
            this.Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "K";

        public string Name => "Единицы";

        public string Description => "Вывести количество единиц в двоичном выражении введенного числа";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                int? value = null;
                while (value is null)
                    value = TaskHelper.GetCount("Введите положительное число в десятичной системе счисления. Для выхода введите 999.");

                if (value == 999)
                    break;

                string binary = TaskHelper.IntToBinaryString(value.Value);
                Console.WriteLine($"В двоичном виде числа {value}({binary}) число 1 встречается {TaskHelper.GetCharCount(binary, '1')} раз(a)");
            }
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
