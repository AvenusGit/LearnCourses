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
                Console.ForegroundColor = GetConsoleColorByStatus(Tasks[i].Status);
                Console.WriteLine($"   {Tasks[i].Number}:{Tasks[i].Name}");
                Console.ForegroundColor = ConsoleColor.White;
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

        /// <summary>
        /// Возвращает цвет консоли, которым нужно пометить задачу в списке
        /// </summary>
        /// <param name="status">Статус решения задачи</param>
        /// <returns>Цвет консоли</returns>
        public static ConsoleColor GetConsoleColorByStatus(TaskStatus status)
        {
            switch (status)
            {
                case TaskStatus.InProgress: return ConsoleColor.DarkMagenta;
                case TaskStatus.Completed: return ConsoleColor.White;
                case TaskStatus.PartiallyCompleted: return ConsoleColor.Yellow;
                case TaskStatus.NoCompleted: return ConsoleColor.DarkYellow;
                case TaskStatus.NotRealized: return ConsoleColor.Red;
                case TaskStatus.NotFound: return ConsoleColor.DarkRed;
                default: return ConsoleColor.Cyan;
            }
        }
    }

    /// <summary>
    /// Статусы задачи
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// Задача в процессе реализации
        /// </summary>
        InProgress,
        /// <summary>
        /// Задача реализована и выполнена
        /// </summary>
        Completed,
        /// <summary>
        /// Задача частично выполнена (не все усливая соблюдены)
        /// </summary>
        PartiallyCompleted,
        /// <summary>
        /// Задача реализована, но не выполнена
        /// </summary>
        NoCompleted,
        /// <summary>
        /// Задача существует, известна, но не реализована
        /// </summary>
        NotRealized,
        /// <summary>
        /// Известно что такая задача есть, но ее условий найти не удалось
        /// Найдешь, сделай pull request плиз
        /// </summary>
        NotFound
    }
}
