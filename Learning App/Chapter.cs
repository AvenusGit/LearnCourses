using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App
{
    /// <summary>
    /// Глава в спринте
    /// </summary>
    public interface IChapter
    {
        /// <summary>
        /// Ссылка на спринт
        /// </summary>
        public ISprint Sprint { get; }
        /// <summary>
        /// Название главы
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Номер главы (для меню)
        /// </summary>
        public int Number { get; }
        /// <summary>
        /// Список задач в главе
        /// </summary>
        public List<ITask> Tasks { get; }

        public void Selector(ITask? task = null)
        {
            ITask? selectedTask = task;
            selectedTask = SelectTask();
            if (selectedTask is null)
            {
                Selector();
            };
            selectedTask!.DoTask();
        }

        /// <summary>
        /// Метод выбора задания
        /// </summary>
        public ITask? SelectTask()
        {
            Console.Clear();
            ShowChapterHeader();
            Console.WriteLine("Выберите задание:");
            for (int i = 0; i < Tasks.Count; i++)
            {
                Console.WriteLine($"   {Tasks[i].Number}:{Tasks[i].Name}");
            }
            Console.WriteLine($"-------------");
            Console.WriteLine($"   back:Назад");
            Console.WriteLine($"   exit:Выход из приложения");
            Console.WriteLine($"-------------");
            string? userInput = Console.ReadLine();
            if (userInput != null)
            {
                if(userInput == "exit")
                    Environment.Exit(0);
                if (userInput == "back")
                    Sprint.Selector();
                return Tasks.Where(sprint => sprint.Number == userInput).FirstOrDefault();
            }

            else return null;
        }

        private void ShowChapterHeader()
        {
            Console.WriteLine("***************************************************************************************");
            Console.WriteLine($"Раздел {Name}");
            Console.WriteLine("***************************************************************************************");
        }
    }
}
