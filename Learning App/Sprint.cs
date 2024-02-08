using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Learning_App
{
    /// <summary>
    /// Спринт по определенной теме
    /// </summary>
    public interface ISprint
    {
        /// <summary>
        /// Ссылка на родительский курс
        /// </summary>
        public ICourse Course { get; set; }
        /// <summary>
        /// Номер спринта
        /// </summary>
        public int Number { get;}
        /// <summary>
        /// Набор глав (тем) спринта
        /// </summary>
        public List<IChapter> Chapters { get; }
        /// <summary>
        /// Метод выбора глав спринта
        /// </summary>
        public void Selector(IChapter? chapter = null)
        {
            IChapter? selectedChapter = chapter;
            selectedChapter = SelectChapter();
            if (selectedChapter is null)
            {
                Selector();
            };
            selectedChapter!.Selector();
        }

        /// <summary>
        /// Метод выбора раздела
        /// </summary>
        public IChapter? SelectChapter()
        {
            Console.Clear();
            ShowCourseHeader();
            Console.WriteLine("Выберите раздел:");
            for (int i = 0; i < Chapters.Count; i++)
            {
                Console.WriteLine($"   {Chapters[i].Number}:{Chapters[i].Name}");
            }
            Console.WriteLine($"-------------");
            Console.WriteLine($"   back:Назад");
            Console.WriteLine($"   exit:Выход из приложения");
            Console.WriteLine($"-------------");
            int? userInput = TaskHelper.GetCount("Введите номер раздела...");
            if (userInput != null)
            {
                if (userInput == int.MaxValue)
                    Course.Selector();
                return Chapters.Where(chapter => chapter.Number == userInput.Value).FirstOrDefault();
            }

            else return null;
        }

        private void ShowCourseHeader()
        {
            Console.WriteLine("***************************************************************************************");
            Console.WriteLine($"Спринт {Number}");
            Console.WriteLine("***************************************************************************************");
        }
    }
}
