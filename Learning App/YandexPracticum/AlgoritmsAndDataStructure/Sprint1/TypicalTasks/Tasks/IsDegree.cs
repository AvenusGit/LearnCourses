using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    public class IsDegree : ITask
    {
        public IsDegree(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "N";

        public string Name => "Степень четырех";

        public string Description => "На вход подаются 2 числа. Необходимо определить является ли второе число одной из степеней первого";

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                int? degree = null;
                while(degree is null)
                {
                    degree = TaskHelper.GetCount("Введите степень. Для выхода введите 999");
                }

                if (degree == 999)
                    break;

                int? value = null;
                while (value is null)
                {
                    value = TaskHelper.GetCount("Введите число");
                }

                if(degree > value)
                {
                    Console.WriteLine("Степень меньше числа? Это не серьезно, попробуй еще раз...");
                    continue;
                }

                Console.WriteLine($"Число {value}{(CheckIsDegree(degree.Value, value.Value) ? "" : " не") } является степенью числа {degree}");
            }
            TaskHelper.BackToMenu(Chapter);
        }
        /// <summary>
        /// Метод определяет является ли одно число степенью другого
        /// </summary>
        /// <param name="degree">Степень</param>
        /// <param name="value">Число</param>
        /// <returns></returns>
        private bool CheckIsDegree(int degree, int value)
        {
            double n = value;
            while(n >= degree)
            {
                n /= degree;
            }
            return n == 1;
        }
    }
}
