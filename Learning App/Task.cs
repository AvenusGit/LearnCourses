using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App
{
    public interface ITask
    {
        /// <summary>
        /// Ссылка на главу, в которой эта задача
        /// </summary>
        public IChapter Chapter { get; set; }
        /// <summary>
        /// Буква номера задачи
        /// </summary>
        string Number { get; }
        /// <summary>
        /// Название задачи
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Описание задачи
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Метод начала выполнения задачи
        /// </summary>
        public void DoTask();
    }
}
