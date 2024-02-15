using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    public class EvenOdd : ITask
    {
        public EvenOdd(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "B";

        public string Name => "Четные-Нечетные";

        public string Description => "Реализовать игру. Выдавать 3 случайных числа. Если они все одной четности - игрок победил.";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            Random random = new Random();
            bool end = false;
            while (!end)
            {
                int a = random.Next(100), b = random.Next(100), c = random.Next(100);
                Console.WriteLine($"Числа:{a},{b},{c}");
                if (AllEvenOrOdd([a, b, c]))
                    Console.WriteLine("WIN");
                else
                    Console.WriteLine("FAIL");
                Console.WriteLine("Нажмите Escape для выхода или любую кнопку для повтора...");
                ConsoleKeyInfo pressedKey =  Console.ReadKey();
                if(pressedKey.Key == ConsoleKey.Escape)
                    end = true;
            }
            
            TaskHelper.BackToMenu(Chapter);
        }
        /// <summary>
        /// Метод возвращает true если все числа в массиве четные или нечетные
        /// </summary>
        /// <param name="array">Массив чисел</param>
        /// <returns>Boolean</returns>
        private bool AllEvenOrOdd(int[] array)
        {
            bool allEven = true;
            bool allOdd = true;
            foreach (int item in array)
            {
                if(item%2 == 0)
                    allOdd = false;
                else allEven = false;
            }
            return allOdd || allEven;
        }
    }
}
