using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.Recursion.Tasks
{
    internal class KondratysEncryptionSystem : ITask
    {
        public KondratysEncryptionSystem(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "E";

        public string Name => "Кондратиева система шифрования";

        public string Description => "Вывести факториал числа";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                int? index = null;
                while (index is null)
                {
                    index = TaskHelper.GetCount("Введите число для рассчета факториала, для выхода введите 999");
                    if (index < 0)
                    {
                        Console.WriteLine("Число не может быть отрицательным");
                        index = null;
                    }
                    if (index > 20)
                    {
                        Console.WriteLine("Число не может быть больше 20");
                        index = null;
                    }
                }

                if (index == 999)
                    break;

                Console.WriteLine($"{index}! = {CalculateFactorial(index.Value)}");
            }
            TaskHelper.BackToMenu(Chapter);
        }

        private int CalculateFactorial(int n, int currentIteration = 1, int summ = 1)
        {
            if(n == 0 || n == 1) return 1;
            if(currentIteration - 1 == n) return summ;
            return CalculateFactorial(n, currentIteration + 1, summ * currentIteration);
        }
    }
}
