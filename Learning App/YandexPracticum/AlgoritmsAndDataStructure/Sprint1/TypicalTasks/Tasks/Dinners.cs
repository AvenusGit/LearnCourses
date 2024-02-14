using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    internal class Dinners : ITask
    {
        public Dinners(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "J";

        public string Name => "Обеды";

        public string Description => "Дан массив чисел, все числа в нем встречаются 2 раза. " +
            "\n   Найти единственный элемент, который встречается один раз.";

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            int[]? values = null;
            while(values is null)
            {
                values = TaskHelper.GetIntArray("Введите числа, помните, что каждое число кроме одного необходимо ввести 2 раза");
            }
            Console.WriteLine($"Число, которое встречается в введенном массиве только один раз: {FindUnique(values)}");
            TaskHelper.BackToMenu(Chapter);
        }

        private int FindUnique(int[] array)
        {
            // вариант решения с хэшмапой
            // O(n) по сложности
            // O(n/2) по памяти
            HashSet<int> pairs = new HashSet<int>();
            foreach (int value in array)
            {
                if(!pairs.Add(value))
                    pairs.Remove(value);
            }
            return pairs.FirstOrDefault();
        }
    }
}
