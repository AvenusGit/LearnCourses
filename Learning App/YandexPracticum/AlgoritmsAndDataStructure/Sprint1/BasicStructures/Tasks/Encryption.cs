using Learning_App.YandexPracticum.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks
{
    public class Encryption : ITask
    {
        public Encryption(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "O";

        public string Name => "Шифрование";

        public string Description => "Задача на поиск количества анаграмм в строке";

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            string? target = null;
            string? pattern = null;
            while (target != "exit" || pattern != "exit")
            {
                target = null;
                pattern = null;
                while (target is null)
                {
                    Console.WriteLine("Введите строку, в которой необходимо провести поиск, для выхода введите <exit>");
                    target = Console.ReadLine();
                }
                if (target == "exit")
                    break;
                while (pattern is null)
                {
                    Console.WriteLine("Введите строку, в которой необходимо провести поиск , для выхода введите <exit>");
                    pattern = Console.ReadLine();
                }
                ShowAnagrammCount(target, pattern);
            }
            TaskHelper.BackToMenu(Chapter);
        }
        /// <summary>
        /// Метод печатает в консоли количество анаграмм в целевой строке
        /// </summary>
        /// <param name="target">Целевая строка</param>
        /// <param name="pattern">Шаблон</param>
        private void ShowAnagrammCount(string target, string pattern)
        {
            if(String.IsNullOrEmpty(target) || String.IsNullOrEmpty(pattern))
            {
                Console.WriteLine("Шаблон или целевая строка пусты");
                return;
            }
            if(pattern.Length > target.Length)
            {
                Console.WriteLine("Шаблон больше целевой строки");
                return;
            }
            int anagrammCount = 0;
            for (int startIndex = 0; startIndex < target.Length - pattern.Length + 1; startIndex++)
            {
                string word = target.Substring(startIndex, pattern.Length);
                if(IsAnagramm(word, pattern))
                    anagrammCount++;
            }
            Console.WriteLine($"Количество анаграмм в слове {target} - {anagrammCount}");
        }
        /// <summary>
        /// Метод определяет, является ли слово анаграммой шаблону
        /// </summary>
        /// <param name="target">Целевое слово</param>
        /// <param name="pattern">Шаблон</param>
        /// <returns>True - если да, False, если нет</returns>
        private bool IsAnagramm(string target, string pattern)
        {
            if (target.Length != pattern.Length)
                throw new Exception("Длины слова и паттерна не равны");

            foreach (char ch in target)
                if (!pattern.Contains(ch))
                    return false;
            return true;
        }
    }
}
