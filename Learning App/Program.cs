using Learning_App;
using Learning_App.One;
using Learning_App.YandexPracticum.AlgoritmsAndDataStructure;
using System.Runtime.CompilerServices;

namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            Selector();
        }
        private static void Selector()
        {
            ICourse? selectedCourse = null;
            selectedCourse = SelectCourse();
            while (selectedCourse is null)
            {
                selectedCourse = SelectCourse();
            };
            selectedCourse.Selector();
        }

        private static ICourse? SelectCourse()
        {
            Console.Clear();
            ShowAppHeader();
            List<ICourse> courses = new List<ICourse>() {
        new YandexADCourse()
    };
            Console.WriteLine("Выберите курс:");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"   {courses[i].Number}:{courses[i].Name}");
            }
            Console.WriteLine($"   exit:Выход из приложения");
            int? userInput = TaskHelper.GetCount("Введите номер курса...");
            if (userInput != null)
                return courses.Where(course => course.Number == userInput.Value).FirstOrDefault();
            else return null;
        }

        private static void ShowAppHeader()
        {
            Console.WriteLine("***************************************************************************************");
            Console.WriteLine("Приложение для выполнения и проверки задач с курсов по алгоритмам и структурам данных");
            Console.WriteLine("***************************************************************************************");
        }
    }
}
