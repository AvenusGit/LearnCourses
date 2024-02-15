using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    public class Frequency : ITask
    {
        public Frequency(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "M";

        public string Name => "Частоты";

        public string Description => "Отсортировать строку сначала по частоте встречания символов, после по алфавиту";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                string? value = null;
                while(String.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Введите исходную строку, для выхода введите <exit>");
                    value = Console.ReadLine();
                }

                if(value == "exit")
                    break;

                Console.WriteLine($"Отсортированная строка: {FrequencySort(value)}");
            }
            TaskHelper.BackToMenu(Chapter);
        }
        /// <summary>
        /// Выполняет сортировку сначала по количеству вхождений в строку, а если равное по алфовиту
        /// </summary>
        /// <param name="target">Целевая строка</param>
        /// <returns>Отсортированаая строка</returns>
        private string FrequencySort(string target)
        {
            // собираем статистику по символам
            SortedDictionary<char, int> frequencyDict = new SortedDictionary<char, int>();
            foreach (char ch in target)
            {
                int value;
                if (frequencyDict.TryGetValue(ch, out value))
                {
                    frequencyDict[ch] = value + 1;
                }
                else frequencyDict.Add(ch, 1);
            }

            string result = "";
            foreach (KeyValuePair<char, int> pair in frequencyDict.OrderByDescending(x => x.Value))
            {
                for (int i = 0; i < pair.Value; i++)
                {
                    result += pair.Key;
                }
            }
            return result;
        }
    }
}
