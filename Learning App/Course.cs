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

        public void Selector(bool clearUI = true)
        {
            if(clearUI)
                Console.Clear();
            ShowCourseHeader();
            ISprint? selectedSprint = null;
            while (selectedSprint is null)
            {
                selectedSprint = SelectSprint();
            };
            selectedSprint.SelectChapter();
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
            Console.WriteLine($"   back:Назад");
            Console.WriteLine($"   exit:Выход из приложения");
            int? userInput = TaskHelper.GetCount("Введите номер спринта...");
            if (userInput != null)
            {
                return Sprints.Where(sprint => sprint.Number == userInput.Value).FirstOrDefault();
            }
                
            else return null;
        }

        void ShowCourseHeader()
        {
            Console.WriteLine("***************************************************************************************");
            Console.WriteLine($"Курс {Name}");
            Console.WriteLine("***************************************************************************************");
        }
    }
}
