using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    public class BinarySystem : ITask
    {
        public BinarySystem(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "I";

        public string Name => "Двоичная система";

        public string Description => "Реализовать функцию сложения двоичных чисел. Встроенную функцию C# использовать нельзя.";

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                string binaryOne = TaskHelper.GetBinaryStringInput("Введите первое двоичное число, для выхода введите 111000");
                if (binaryOne == "111000")
                    break;
                string binaryTwo = TaskHelper.GetBinaryStringInput("Введите второе двоичное число");
                Console.WriteLine($"Результат сложения чисел {binaryOne} и {binaryTwo}: {SumBinaryStrings(binaryOne, binaryTwo)}");
            }
            TaskHelper.BackToMenu(Chapter);
        }
        /// <summary>
        /// Суммирует бинарные строки и возвращает строку суммы
        /// </summary>
        /// <param name="one">Бинарная строка 1</param>
        /// <param name="two">Бинарная строка 2</param>
        /// <returns>Бинарная строка - сумма</returns>
        private string SumBinaryStrings(string one, string two)
        {
            bool inc = false;
            string result = "";
            // выравнивание длин строк если требуется
            if(one.Length != two.Length)
            {
                if (one.Length > two.Length)
                    while (one.Length != two.Length)
                        two = '0' + two;
                else 
                    while (one.Length != two.Length)
                        one = "0" + one;
            }
            // цикл в обратную сторону от последних символов
            for (int i = one.Length - 1; i >= 0; i--)
            {
                if (one[i] == '0' && two[i] == '0')
                    if (inc)
                    {
                        result = '1' + result;
                        inc = false;
                    }                        
                    else result = '0' + result;
                else if (one[i] == '1' && two[i] == '0' || one[i] == '0' && two[i] == '1')
                    if (inc)
                    {
                        result = '0' + result;
                        inc = true;
                    }
                    else
                        result = '1' + result;
                else if (one[i] == '1' && two[i] == '1')
                    if (inc)
                    {
                        result = '1' + result;
                        inc = true;
                    }
                    else
                    {
                        result = '0' + result;
                        inc = true;
                    }
            }
            if (inc) result = '1' + result;
            return result;
        }
    }
}
