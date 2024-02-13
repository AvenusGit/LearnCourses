using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.Classes
{
    /// <summary>
    /// Собственная реализация стека
    /// </summary>
    public class StackS<T> : IStackOrQueue<T> where T :IComparable<T>
    {
        public StackS(int stackSize) 
        {
            Lenght = 0;
            Values = new T[stackSize];
        }

        public StackS(T[] array)
        {
            Lenght = array.Length;
            Values = array;
        }
        /// <summary>
        /// Текущий размер стека
        /// </summary>
        public int Lenght { get; private set; }
        /// <summary>
        /// Текущие значения стека
        /// </summary>
        private T[] Values { get; set; }

        /// <summary>
        /// Добавляет элемент в стек
        /// </summary>
        public void Push(T item, bool print = false)
        {
            if (Lenght >= Values.Length)
            {
                Console.WriteLine("Стэк уже полон!");
                return;
            }
            Values[Lenght++] = item;
            if (print)
                Print();
        }
        /// <summary>
        /// Команда удаляет верхний элемент из стека и возвращает его
        /// </summary>
        /// <returns>Удаленный верхний элемент из стека</returns>
        public T? Pop()
        {
            T? result = Values[Lenght - 1];
            Values[--Lenght] = default(T);
            return result;

        }
        /// <summary>
        /// Команда возвращает самый большой элемент стека
        /// </summary>
        /// <returns></returns>
        public T? GetMax()
        {
            T? max = default(T);
            foreach(T item in Values)
            {
                if(item.CompareTo(max) > 0)
                    max = item;
            }
            return max;
        }
        public void Print()
        {
            Console.WriteLine("Значения стека:");
            for (int i = 0; i < Lenght; i++)
            {
                Console.WriteLine($"   {Values[i].ToString()}");
            }
        }

        public int GetSize()
        {
            return Lenght - 1;
        }

        public T Top()
        {
            return Values[Lenght - 1];
        }

        public bool IsEmpty()
        {
            return Lenght == 0;
        }
    }
}
