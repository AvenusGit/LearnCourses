using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.FinalTasks.Tasks
{
    public class Calculator : ITask
    {
        public Calculator(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "A";

        public string Name => "Калькулятор";

        public string Description => "Реализовать метод вычисления итогового знаечния польской нотации";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                string[]? values = null;
                while(values is null)
                {
                    values = TaskHelper.GetPolishNotationString("Введите число в польской нотации. Для выхода введите 999");
                }

                if (values[0] == "999")
                    break;
                int? result = PolishCalculator(values);
                if (result is not null)
                    Console.WriteLine($"Результатом вычисления введенного выражения является '{result}'");
                else Console.WriteLine("Oшибка вычисления...");
            }
            TaskHelper.BackToMenu(Chapter);
        }
        /// <summary>
        /// Вычисляет итоговое значение польской нотации
        /// </summary>
        /// <param name="polishNotation">Массив значений</param>
        /// <returns></returns>
        private int? PolishCalculator(string[] polishNotation)
        {
            try
            {
                Stack<int> stack = new Stack<int>();
                foreach (string value in polishNotation)
                {
                    switch (value)
                    {
                        case "+":
                            int x = stack.Pop();
                            int y = stack.Pop();
                            stack.Push(x + y);
                            break;
                        case "-":
                            x = stack.Pop();
                            y = stack.Pop();
                            stack.Push(x - y);
                            break;
                        case "*":
                            x = stack.Pop();
                            y = stack.Pop();
                            stack.Push(x * y);
                            break;
                        case "/":
                            x = stack.Pop();
                            y = stack.Pop();
                            stack.Push(x / y);
                            break;
                        default:
                            int result;
                            if (Int32.TryParse(value, out result))
                                stack.Push(result);
                            else return null;
                            break;                            
                    }                    
                }
                return stack.Peek();
            }
            catch
            {
                return null;
            }            
        }
    }
}
