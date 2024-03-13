using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.Recursion.Tasks
{
    internal class CycledFactorial : ITask
    {
        public CycledFactorial( IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "F";

        public string Name => "Циклический факториал";

        public string Description => "Вывести значение факториала через цикл";

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

                    if (index == 999)
                        break;

                    if (index > 20)
                    {
                        Console.WriteLine("Число не может быть больше 22");
                        index = null;
                    }
                }

                if (index == 999)
                    break;

                Console.WriteLine($"{index}! = {CalculateFactorial(index.Value)}");
            }
            TaskHelper.BackToMenu(Chapter);
        }
        private int CalculateFactorial(int n)
        {
            if(n == 0 || n == 1) return 1;
            int result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;           
            return result;
        }
    }
}
