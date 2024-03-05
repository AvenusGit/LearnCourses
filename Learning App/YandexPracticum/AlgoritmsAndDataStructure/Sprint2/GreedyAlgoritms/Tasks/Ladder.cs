using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms.Tasks
{
    public class Ladder : ITask
    {
        public Ladder(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "L";

        public string Name => "Лестница";

        public string Description => "Определить, можно ли добраться до верха лестницы";

        public TaskStatus Status => TaskStatus.PartiallyCompleted;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                int[]? values = null;
                while (values is null || values.Length == 0)
                {
                    values = TaskHelper.GetIntArray("Введите ступени через пробел" +
                        ", для выхода введите <999>");
                }

                if (values[0] == 999)
                    break;

                /* не работает с 8 30 2 0 0 0 0 0 0 0 0 0 10 - как вариант решать деревом
                 * 1 3 0 1 2
                 */
                List<int> usedIndexes = new List<int>();
                bool result = Jump(0, values, usedIndexes);
                
                Console.WriteLine($"Добраться до верхней ступеньки{(result ? "" : " не")} возможно");
                Console.WriteLine($"Использованы индексы: {new StringBuilder().AppendJoin(',', usedIndexes)}");
            }
        }

        private bool Jump(int currentIndex, int[] array, List<int> usedList)
        {
            // Если это последняя ступенька выходим
            if (currentIndex == array.Length - 1)
                return true;
            // Узнаем на какую длину можем прыгнуть
            int jumpLenght = array[currentIndex];
            // если длина прыжка больше размера массива - выходим
            if(array.Length - 1 < currentIndex + jumpLenght)
            {
                usedList.Add(currentIndex);
                return true;
            }

            // если мы прыжком целимся в 0, уменьшаем длину прыжка, пока это возможно
            while (array[currentIndex + jumpLenght] == 0 && jumpLenght > 0)
                jumpLenght--;
            // если все длины прыжка целятся в 0 - выходим
            if (jumpLenght == 0)
                return false;
            else
            {
                // добавляем индекс в путевой лист
                usedList.Add(currentIndex);
                // прыгаем 
                return Jump(currentIndex + jumpLenght, array, usedList);
            }
                
        }
    }
}
