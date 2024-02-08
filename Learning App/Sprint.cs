using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void SelectChapter();
    }
}
