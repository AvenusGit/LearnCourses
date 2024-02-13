using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.Classes
{
    public interface IStackOrQueue<T> where T : IComparable<T>
    {
        /// <summary>
        /// Удалить первый элемент и вернуть этот элемент
        /// </summary>
        /// <returns></returns>
        public T? Pop();
        /// <summary>
        /// Добавить элемент в стек
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item, bool print = false);
        /// <summary>
        /// Вернуть размер стека
        /// </summary>
        /// <returns></returns>
        public int GetSize();
        /// <summary>
        /// Напечатать содержимое коллекции в консоли
        /// </summary>
        public void Print();
        /// <summary>
        /// Вернуть верхний элемент
        /// </summary>
        /// <returns></returns>
        public T Top();
        /// <summary>
        /// Пуста ли очередь
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty();
    }
}
