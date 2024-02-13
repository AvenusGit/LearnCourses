using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Learning_App.YandexPracticum.Classes
{
    /// <summary>
    /// Собственная реализация дека на массиве. Попытка реализовать динамический массив внутри дека.
    /// </summary>
    /// <typeparam name="T">Тип значений дека</typeparam>
    public class DequeueS<T> : IStackOrQueue<T> where T : IComparable<T>
    {
        public DequeueS(T[] array) 
        {
            Rebuild(array);
        }
        /// <summary>
        /// Массив всех значений
        /// </summary>
        private T[] values;
        /// <summary>
        /// Стартовый индекс дека
        /// </summary>
        private int startIndex;
        /// <summary>
        /// Конечный индек дека
        /// </summary>
        private int endIndex;        
        /// <summary>
        /// Метод пересоздания массива, при нехватке в нем мест в обе стороны
        /// </summary>
        /// <param name="array">Массив значений без пустот по краям</param>
        public void Rebuild(T[] array)
        {
            // Реализуем динамический массив
            values = new T[3 * array.Length];
            startIndex = array.Length;
            endIndex = startIndex;
            for (int i = 0; i < array.Length; i++)
            {
                values[endIndex] = array[i];
                endIndex++;
            }
        }

        public int GetSize()
        {
            return endIndex - startIndex;
        }

        public bool IsEmpty()
        {
           return startIndex == endIndex;
        }

        public T? Pop()
        {
            if (IsEmpty())
                return default(T);
            T result = values[startIndex];
            values[startIndex] = default(T);
            startIndex++;
            return result;
        }
        /// <summary>
        /// Метод удаляет элемент из конца дека и возвращает его
        /// </summary>
        /// <returns>Удаленный элемент</returns>
        public T? PopBack()
        {
            if (IsEmpty())
                return default(T);
            endIndex--;
            T result = values[endIndex];
            values[endIndex] = default(T);           
            return result;
        }

        public void Print()
        {
            Console.WriteLine($"Стартовый индекс дека:{startIndex}");
            Console.WriteLine($"Конечный индекс дека:{endIndex}");
            Console.WriteLine($"Длинна массива:{values.Length}");
            Console.WriteLine($"---Элементы дека---------------------------");
            for ( int i = startIndex;i < endIndex;i++)
            {
                Console.WriteLine($"   {i}:{values[i]}");
            }
            Console.WriteLine($"-------------------------------------------");
        }

        public void Push(T item, bool print = false)
        {
            if(startIndex == 0)
            {
                T[] array = new T[endIndex];
                for (int i = 0;i < endIndex; i++)
                {
                    array[i] = values[i];
                }
                Rebuild(array);
                Push(item, print);
                return;
            }
            startIndex--;
            values[startIndex] = item;
            if(print)
                Print();
        }
        /// <summary>
        /// Метод выполняет добавление с хвоста дека
        /// </summary>
        /// <param name="item">Элемент для добавления</param>
        /// <param name="print">Показать ли содержимое после добавления</param>
        public void PushBack(T item, bool print = false)
        {
            if (endIndex == values.Length)
            {
                T[]? array = new T[endIndex];
                Rebuild(array);
                PushBack(item, print);
                return;
            }
            values[endIndex] = item;
            endIndex++;
            if(print)
                Print();
        }

        public T? Top()
        {
            if (!IsEmpty())
                return values[startIndex];
            else return default;
        }

        public T? TopBack()
        {
            if (!IsEmpty())
                return values[endIndex-1];
            else return default;
        }
        /// <summary>
        /// Возвращает массив дека без пустых значений
        /// </summary>
        /// <returns></returns>
        public T[]? GetClearArray()
        {
            if(IsEmpty())
                return null;
            T[] array = new T[GetSize()];
            for (int i = startIndex, j = 0; i < endIndex; i++, j++)
            {
                array[j] = values[i];
            }
            return array;
        }
    }
}
