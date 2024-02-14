using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    internal class DataBase : ITask
    {
        public DataBase(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "F";

        public string Name => "База данных";

        public string Description => "Нати число в массиве, которое встречается более одного раза";

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                int[]? values = null;
                while (values is null)
                {
                    values = TaskHelper.GetIntArray("Введите числовые значения (одно из чисел должно повторяться). Для выхода введите 999");
                }
                if (values[0] == 999)
                    break;

                int? repeat = null;

                // решение за О(n) требующее О(n) памяти
                //HashSet<int> hashSet = new HashSet<int>();

                //foreach (int value in values)
                //{
                //    if (!hashSet.Add(value))
                //    {
                //        repeat = value;
                //        break;
                //    }
                //}

                // решение за O(n^2) не требующее памяти
                foreach (int value in values)
                {
                    int count = values.Where(val => val == value).Count();
                    if(count > 1)
                    {
                        repeat = value;
                        break;
                    }
                }

                if (repeat is not null)
                    Console.WriteLine($"Повторяющееся число:{repeat}");
                else
                    Console.WriteLine($"Числа, дважды введенного, в этом масиве нет...");
            }

            TaskHelper.BackToMenu(Chapter);
        }


    }
}
