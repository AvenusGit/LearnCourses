using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    public class ExtraLetter : ITask
    {
        public ExtraLetter(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "L";

        public string Name => "Лишнаяя буква";

        public string Description => "Даны 2 строки. Во второй есть лишняя буква. Найти эту букву.";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                string? withoutExtra = null;
                while(withoutExtra is null)
                {
                    Console.WriteLine("Введите строку без лишнего символа, для выхода введите <exit>");
                    withoutExtra = Console.ReadLine();
                }
                if (withoutExtra == "exit")
                    break;
                string? withExtra = null;
                while (withExtra is null)
                {
                    Console.WriteLine("Введите строку с лишним символом в любом месте");
                    withExtra = Console.ReadLine();
                }
                char? extra = GetExtraChar(withoutExtra, withExtra);
                if(extra is not null)
                {
                    Console.WriteLine($"Во вторую строку был добавлен символ '{extra}'");
                }
                else Console.WriteLine($"Не удалось определить добавленый символ, он там точно есть?");
            }
            TaskHelper.BackToMenu(Chapter);
        }
        /// <summary>
        /// Метод возвращает первый символ в строке, который не присутствует в оригинальной строке
        /// </summary>
        /// <param name="withoutExtra">Строка без добавлений</param>
        /// <param name="withExtra">Строка с добавлением</param>
        /// <returns>Первый отличающийся символ</returns>
        private char? GetExtraChar(string withoutExtra, string withExtra)
        {
            for (int i = 0; i < withExtra.Length - 1; i++)
            {
                if (i < withoutExtra.Length - 1)
                {
                    if (withoutExtra[i] != withExtra[i])
                        return withExtra[i];
                }
                else return withExtra[i];
            }
            return null;
        }
    }
}
