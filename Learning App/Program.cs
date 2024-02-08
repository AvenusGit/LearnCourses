using Learning_App;
using Learning_App.One;
using Learning_App.YandexPracticum.AlgoritmsAndDataStructure;
using System.Runtime.CompilerServices;

namespace Learning_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Selector();
        }
        public void Selector(ICourse? course = null)
        {
            ICourse? selectedCourse = course;
            selectedCourse = SelectCourse();
            if (selectedCourse is null)
            {
                Selector(selectedCourse);
            };
            selectedCourse!.Selector();
        }

        private ICourse? SelectCourse()
        {
            Console.Clear();
            ShowAppHeader();
            List<ICourse> courses = new List<ICourse>() {
        new YandexADCourse(this)
    };
            Console.WriteLine("Выберите курс:");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"   {courses[i].Number}:{courses[i].Name}");
            }
            Console.WriteLine($"-------------");
            Console.WriteLine($"   exit:Выход из приложения");
            Console.WriteLine($"-------------");
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
