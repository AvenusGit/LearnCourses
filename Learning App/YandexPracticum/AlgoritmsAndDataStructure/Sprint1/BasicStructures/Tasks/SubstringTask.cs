using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures
{
    /// <summary>
    /// Задача найти и вывести самую длинную (или последнюю из таких) строку в которой символы не повторяются
    /// </summary>
    public class SubstringTask : ITask
    {
        public SubstringTask(IChapter chapter)
        {
            Chapter = chapter;
        }
        public IChapter Chapter { get; set; }

        public string Number => "C";

        public string Name => "Подстроки";

        public string Description => "Задача найти и вывести самую длинную (или последнюю из таких)" +
            " строку в которой символы не повторяются";

        public TaskStatus Status => TaskStatus.Completed;

        /// <summary>
        /// Целевая строка
        /// </summary>
        private string Target { get; set; }
        /// <summary>
        /// Максимальная уникальная строка
        /// </summary>
        private string MaxString { get; set; }
        /// <summary>
        /// Длинна максимальной уникальной строки
        /// </summary>
        private int MaxStringLenght { get { return MaxString.Length; } }

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            Target = InputString();
            CalculateMaxSubstring();
            TaskHelper.BackToMenu(Chapter);
        }
        /// <summary>
        /// Ввод целевой строки
        /// </summary>
        /// <returns></returns>
        private string InputString()
        {
            Console.WriteLine("Введите целевую строку:");
            return Console.ReadLine() ?? "";
        }
        /// <summary>
        /// Расчет самой большой уникальной подстроки
        /// </summary>
        private void CalculateMaxSubstring()
        {
            MaxString = "";
            int leftIndex = 0;
            int rightIndex = 0;
            HashSet<char> chars = new HashSet<char>();
            while (leftIndex < Target.Length && rightIndex < Target.Length)
            {
                if (!chars.Contains(Target[rightIndex]))
                {
                    chars.Add(Target[rightIndex]);
                    rightIndex++;
                    if (MaxStringLenght <= Target.Substring(leftIndex, rightIndex - leftIndex).Length)
                        MaxString = Target.Substring(leftIndex, rightIndex - leftIndex);
                }
                else
                {
                    chars.Remove(Target[rightIndex]);
                    leftIndex++;
                }
            }
            Console.WriteLine($"Целевая строка: {Target}, максимальная уникальная подстрока в ней: {MaxString}, длинной в {MaxStringLenght}");
        }
    }
}
