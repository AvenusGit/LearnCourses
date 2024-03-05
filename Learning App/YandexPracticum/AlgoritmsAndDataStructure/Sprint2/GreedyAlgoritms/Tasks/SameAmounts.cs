using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms.Tasks
{
    internal class SameAmounts : ITask
    {
        public SameAmounts(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "I";

        public string Name => "Одинаковые суммы";

        public string Description => "Проверка на возможность разбиения массива на 2 части так, чтобы суммы их элементов были одинаковы";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                int[]? values = null;
                while (values is null || values.Length == 0)
                {
                    values = TaskHelper.GetIntArray("Введите массив числе через пробел" +
                        ", для выхода введите <999>");
                }

                if (values[0] == 999)
                    break;

                List<int> left = new List<int>();
                List<int> right = new List<int>();
                int leftSumm = 0, rightSumm = 0;

                /**
                 *  12 6 11 1
                 *  7 4 1 1 1
                 */

                values = values.OrderByDescending(x => x).ToArray();
                foreach (int value in values)
                {
                    if(leftSumm <= rightSumm)
                    {
                        leftSumm += value;
                        left.Add(value);
                    }
                    else
                    {
                        rightSumm += value;
                        right.Add(value);
                    }
                }

                Console.WriteLine($"Разбиение массива на два одинаковых по сумме {(leftSumm == rightSumm ? "" : "не ")}возможно");
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendJoin(',', left);
                Console.WriteLine($"Левый подмассив:{stringBuilder}");
                stringBuilder.Clear();
                stringBuilder.AppendJoin(',', right);
                Console.WriteLine($"Правый подмассив:{stringBuilder}");
            }
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
