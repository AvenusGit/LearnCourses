using Learning_App.YandexPracticum.AlgoritmsAndDataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App
{
    /// <summary>
    /// Обучающий курс
    /// </summary>
    public interface ICourse
    {
        public Program Program { get; set; }
        /// <summary>
        /// Номер курса (для быстрого ввода пользователем)
        /// </summary>
        public int Number { get; }
        /// <summary>
        /// Название курса
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// Спринты этого курса
        /// </summary>
        public List<ISprint> Sprints { get; }

        public void Selector(ISprint? sprint = null)
        {
            ISprint? selectedSprint = sprint;
            selectedSprint = SelectSprint();
            if (selectedSprint is null)
            {
                Selector();
            };
            selectedSprint!.Selector();
        }

        /// <summary>
        /// Метод выбора курса
        /// </summary>
        public ISprint? SelectSprint()
        {
            Console.Clear();
            ShowCourseHeader();
            Console.WriteLine("Выберите спринт:");
            for (int i = 0; i < Sprints.Count; i++)
            {
                Console.WriteLine($"   {Sprints[i].Number}:Спринт {Sprints[i].Number}");
            }
            Console.WriteLine($"-------------");
            Console.WriteLine($"   back:Назад");
            Console.WriteLine($"   exit:Выход из приложения");
            Console.WriteLine($"-------------");
            int? userInput = TaskHelper.GetCount("Введите номер спринта...");
            if (userInput != null)
            {
                if (userInput == int.MaxValue)
                    Program.Selector();
                return Sprints.Where(sprint => sprint.Number == userInput.Value).FirstOrDefault();
            }
                
            else return null;
        }

        private void ShowCourseHeader()
        {
            Console.WriteLine("***************************************************************************************");
            Console.WriteLine($"Курс {Name}");
            Console.WriteLine("***************************************************************************************");
        }
    }
}
