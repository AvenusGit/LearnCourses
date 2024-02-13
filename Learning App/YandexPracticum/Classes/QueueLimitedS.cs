using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.Classes
{
    /// <summary>
    /// Собственная реализация ограниченной по размеру очереди
    /// </summary>
    /// <typeparam name="T">Тип очереди</typeparam>
    public class QueueLimitedS<T> : QueueS<T> where T : IComparable<T>
    {
        /// <summary>
        /// Конструктор ограниченной по размеру очереди
        /// </summary>
        /// <param name="size">Ограничение по размеру</param>
        /// <param name="array"></param>
        public QueueLimitedS(int size,T[]? array = null) : base(array)
        {
            Size = size;
            Values = new List<T>(array);
        }
        /// <summary>
        /// Ограничение очереди по размеру
        /// </summary>
        public int Size { get; private set; }
        /// <summary>
        /// Переопределенный метод для добавленияв очередь. Добавлена проверка на ограничение размера очереди.
        /// </summary>
        /// <param name="item">Добавляемый элемент</param>
        /// <param name="print">Печатать ли содержимое после добавления</param>
        public override void Push(T item, bool print = false)
        {
            if(Values.Count >= Size)
            {
                Console.WriteLine("Очередь полна. Очистите как минимум один элемент перед добавлением.");
                return;
            }
            Values.Add(item);
            if (print)
                Print();
        }
    }
}
