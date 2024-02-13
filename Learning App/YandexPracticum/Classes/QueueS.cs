using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.Classes
{
    /// <summary>
    /// Собственная реализация очереди
    /// </summary>
    /// <typeparam name="T">Тип значений очереди</typeparam>
    public class QueueS<T> : IStackOrQueue<T> where T : IComparable<T>
    { 
        public QueueS(T[] array) { Values = new List<T>(array); }
        /// <summary>
        /// Массив значений очереди
        /// </summary>
        private List<T> Values { get; set; }

        public int GetSize()
        {
            return Values.Count;
        }

        public T? Pop()
        {
            if (Values.Any())
            {
                T result = Values.First();
                Values.Remove(result);
                return result;
            }
            return default(T);
        }

        public void Push(T item, bool print = false)
        {
            Values.Add(item);
            if (print)
                Print();
        }

        public T Top()
        {
            return Values.First();
        }

        public bool IsEmpty()
        {
            return !Values.Any();
        }

        public void Print()
        {
            Console.WriteLine("Значения очереди:");
            foreach (T item in Values)
            {
                Console.WriteLine($"   {item.ToString()}");
            }
        }
    }
}
