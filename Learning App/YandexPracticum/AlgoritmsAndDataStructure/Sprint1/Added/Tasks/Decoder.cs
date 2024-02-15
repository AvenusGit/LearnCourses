using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.Added
{
    /// <summary>
    /// Задача получить декодированную строку. Строка приходит от пользователя в формате n[abc]. n - количество повторений строки abc.
    /// Пример вводной строки: 4[tst]2[afk]3[e]
    /// </summary>
    public class Decoder : ITask
    {
        public Decoder(IChapter chapter) 
        { 
            Chapter = chapter;
        }
        public IChapter Chapter { get; set; }

        public string Number => "2";

        public string Name => "Дополнительная задача спринта 1 блока 2 из разбора";

        public string Description => "Задача получить декодированную строку. Строка приходит от пользователя в формате n[abc]. n - количество повторений строки abc.";

        public TaskStatus Status => TaskStatus.Completed;

        string Target { get; set; }

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name);
            Target = GetUserInput();
            Console.WriteLine($"Результат декодирования: {DecodeV1(Target)}");
            BackToMenu();
        }
        private string GetUserInput()
        {
            Console.WriteLine("Введите закодированную строку вида n[abc]");
            return Console.ReadLine() ?? "";
        }

        private string DecodeV1(string code)
        {
            bool valueMode = false;
            List<char> digits = new List<char>();
            List<char> value = new List<char>();
            StringBuilder sb = new StringBuilder();
            foreach (char c in code)
            {
                if (c == '[')
                {
                    valueMode = true;
                    continue;
                }
                if (c == ']')
                {
                    int multiplier;
                    if (int.TryParse(new string(digits.ToArray()), out multiplier))
                    {
                        for (int i = 0; i < multiplier; i++)
                        {
                            sb.Append(new string(value.ToArray()));
                        }
                    }
                    digits.Clear();
                    value.Clear();
                    valueMode = false;
                    continue;
                }

                if (valueMode)
                    value.Add(c);
                else
                    digits.Add(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Метод возврата в меню
        /// </summary>
        public void BackToMenu()
        {
            Console.WriteLine("Нажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            Chapter.Selector();
        }
    }
}
