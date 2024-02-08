using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks
{
    public class Circles : ITask
    {
        public Circles(IChapter chapter) { Chapter = chapter; }
        public IChapter Chapter { get; set; }

        public string Number => "A";

        public string Name => "Кружки";

        public string Description => "Задача с минимальными усилиями вывести уникальный список из массива с повторяющимися значениями";

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            string[]? values = null;
            while(values is null)
            {
                values = GetStringArray();
            }
            PrintUnique(values);
            BackToMenu();
        }
        /// <summary>
        /// Запросить у пользвателя исходный массив строк
        /// </summary>
        /// <returns>Массив строк</returns>
        private string[]? GetStringArray()
        {
            Console.WriteLine("Введите через пробел строки исходного массива...");
            string? target = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(target))
            {
                Console.WriteLine("Строка пуста, попробуйте еще раз");
                return null;
            }                
            return target.Split(' ');
        }
        /// <summary>
        /// Метод пишет в консоли уникальные строки исходного массива
        /// </summary>
        /// <param name="array">Оригинальный массив</param>
        private void PrintUnique(string[] array)
        {
            Console.WriteLine("Уникальные слова в этом массиве:");
            HashSet<string> set = new HashSet<string>();
            foreach (string value in array) 
            {
                set.Add(value);
            }
            foreach (string value in set) 
            {
                Console.WriteLine($"   {value}");
            }
        }

        public void BackToMenu()
        {
            Console.WriteLine("Нажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            Chapter.Selector();
        }
    }
}
