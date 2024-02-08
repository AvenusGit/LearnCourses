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
        /// Список задач в главе
        /// </summary>
        public List<ITask> Tasks { get; }

        public void SelectTask()
        {

        }
    }
}
