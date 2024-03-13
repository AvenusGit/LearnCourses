using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.Recursion.Tasks
{
    internal class UnderAlphabet : ITask
    {
        public UnderAlphabet(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "G";

        public string Name => "Недоалфавит";

        public string Description => "Рекурсивно вывести алфавит до заданной буквы включительно";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                char? letter = null;
                while (letter is null || letter == '!')
                {
                    Console.WriteLine("Введите букву английского алфавита, для выхода нажмите Esc");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    Console.WriteLine();
                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        letter = '!';
                        Console.WriteLine();
                        break;
                    }                        
                    letter = keyInfo.KeyChar;
                    if (!Char.IsAsciiLetter(letter.Value))
                    {
                        Console.WriteLine("Это вроде не буква английского алфавита)");
                        letter = null;
                    }                        
                }
                if (letter == '!') break;
                Console.WriteLine($"Буквы алфавита до символа {letter}: {GetUnderAlphabet(letter.Value, new List<char>() {'a'})}");
            }
            TaskHelper.BackToMenu(Chapter);
        }

        private string GetUnderAlphabet(char letter, List<char> result)
        {
            if(result.Count > 0 && result.Last() == letter)
                return new StringBuilder().AppendJoin(' ', result).ToString();

            result.Add((char)(result.Last() + 1));

            return GetUnderAlphabet(letter, result);
        }
    }
}
