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
    public class StackS<T> where T :IComparable<T>
    {
        public StackS(int stackSize) 
        {
            Lenght = 0;
            Values = new T[stackSize];
        }

        public StackS(T[] array)
        {
            Lenght = 0;
            Values = array;
        }
        /// <summary>
        /// Текущий размер стека
        /// </summary>
        public int Lenght { get; private set; }
        /// <summary>
        /// Текущие значения стека
        /// </summary>
        T[] Values { get; set; }

        /// <summary>
        /// Добавляет элемент в стек
        /// </summary>
        public void Push(T item)
        {
            if(Lenght >= Values.Length)
            {
                Console.WriteLine("Stack is full");
                return;
            }
            Values[++Lenght] = item;
        }
        /// <summary>
        /// Команда удаляет верхний элемент из стека и возвращает его
        /// </summary>
        /// <returns>Удаленный верхний элемент из стека</returns>
        public T? Pop()
        {
            T? result = Values[Lenght];
            Values[Lenght--] = default(T);
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
        /// <summary>
        /// Печатает в консоли значения стека
        /// </summary>
        /// <param name="printHeader"></param>
        public void Print(bool printHeader = true)
        {
            if(printHeader)
                Console.WriteLine("Значения стека:");

            foreach(T item in Values)
            {
                Console.WriteLine($"   {item.ToString()}");
            }
        }
    }
}
