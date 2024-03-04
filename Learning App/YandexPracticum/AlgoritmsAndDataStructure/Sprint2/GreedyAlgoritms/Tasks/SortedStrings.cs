using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms.Tasks
{
    internal class SortedStrings : ITask
    {
        public SortedStrings(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "F";

        public string Name => "Отсортированные строки";

        public string Description => "Определить количество столбцов у строк, которые надо удалить, чтобы столбцы были отсортированы по возрастанию";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                string[]? strings = null;
                while(strings is null || strings.Length == 0)
                {
                    strings = TaskHelper.GetStringArray("Введите строки одинаковой длинны. Для выхода введите <exit>");
                    if (!TaskHelper.CheckStringsLenght(strings))
                    {
                        Console.WriteLine("Строки не одинаковой длинны...");
                        strings = null;
                    }                        
                }

                if (strings[0] == "exit")
                    break;

                foreach (string s in strings)
                    Console.WriteLine(s);


                int result = 0;
                for (int i = 0; i < strings[0].Length; i++)
                {
                    if(!ColumnIsSorted(i,strings))
                        result++;
                }
                Console.WriteLine($"Необходимо удалить {result} столбцов для полной сортировки по столбцам");
            }
            TaskHelper.BackToMenu(Chapter);
        }
        /// <summary>
        /// Проверка на сортировку столбцов
        /// </summary>
        /// <param name="column">Номер столбца</param>
        /// <param name="rows">Массив строк</param>
        /// <returns></returns>
        private bool ColumnIsSorted(int column, string[] rows)
        {
            char? current = null;
            for (int row = 0; row < rows.Length; row++) 
            {
                if(current is null)
                {
                    current = rows[row][column];
                    continue;
                }
                if (current > rows[row][column])
                    return false;
            }
            return true;
        }
    }
}
