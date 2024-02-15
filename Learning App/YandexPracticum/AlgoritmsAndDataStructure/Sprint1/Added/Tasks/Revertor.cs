using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.One
{
    /// <summary>
    ///  Задача получить от пользователя набор чисел, после чего каждую пару из них поменять местами и вернуть получившийся массив
    /// </summary>
    public  class Revertor : ITask
    {
        public Revertor(IChapter chapter) 
        {
            Chapter = chapter;
        }
        public IChapter Chapter { get; set; }

        public string Number => "1";

        public string Name => "Дополнительная задача спринта 1 блока 2 из разбора";

        public string Description => "Задача получить от пользователя набор чисел, после чего каждую пару" +
            " из них поменять местами и вернуть получившийся массив";

        public TaskStatus Status => TaskStatus.Completed;

        int[] TargetArray { get; set; }


        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number,Name, Description);
            TargetArray = GetValues();
            PrintArray(TargetArray, "Выбранный массив:");
            RevertArrayIntPair(TargetArray);
            BackToMenu();
        }
        /// <summary>
        /// Запрос у пользователя массива чисел
        /// </summary>
        /// <returns></returns>
        private int[] GetValues()
        {           
            int[]? result = null;
            while (result == null)
            {
                Console.WriteLine("Введите числа через пробел...");
                result = ConverStringToIntArray(Console.ReadLine());
                if(result is not null)
                    return result;
            }
            return null;
        }
        /// <summary>
        /// Пытается превратить введенную строку в массив чисел, разделяее введеные числа по пробелу. Если не получается возвращает null
        /// </summary>
        /// <param name="target">Строка</param>
        /// <returns></returns>
        private int[]? ConverStringToIntArray(string? target)
        {
            if (String.IsNullOrWhiteSpace(target))
                return null;
            string[] strings = target.Split(' ');
            int[] result = new int[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                int res;
                if (Int32.TryParse(strings[i], out res))
                {
                    result[i] = res;
                }
                else
                {
                    Console.WriteLine($"Значение <{strings[i]}> не смогло быть преобразовано в число...");
                    return null;
                }
            }
            return result;
        }

        private void PrintArray(int[] target, string description)
        {
            Console.WriteLine(" ");
            Console.WriteLine(description);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int i in target)
            {
                stringBuilder.Append($" {i.ToString()}");
            }
            Console.WriteLine(stringBuilder);
        }

        private void RevertArrayIntPair(int[] targetArray)
        {
            if (targetArray is null)
            {
                Console.WriteLine("Целевой массив пуст");
                return;
            }
            for (int i = 0;i < targetArray.Length;i+=2)
            {
                int temporary = targetArray[i];
                targetArray[i] = targetArray[i+1];
                targetArray[i+1] = temporary;
            }
            PrintArray(targetArray, "Инвертированный массив:");
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
