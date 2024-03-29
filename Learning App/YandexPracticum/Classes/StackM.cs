﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.Classes
{
    public class StackM<T> where T : IComparable<T>
    {

        public StackM(int stackSize)
        {
            Lenght = 0;
            Values = new (T,T)[stackSize];
        }

        public StackM((T,T)[] array)
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
        private (T, T)[] Values { get; set; }

        /// <summary>
        /// Добавляет элемент в стек
        /// </summary>
        public void Push(T item, bool print = false)
        {
            if (Lenght >= Values.Length)
            {
                Console.WriteLine("Стэк полон");
                return;
            }
            Values[Lenght++] = (item, item.CompareTo(GetMax()) > 0 ? item : GetMax());

            if (print) 
                Print();
        }
        /// <summary>
        /// Команда удаляет верхний элемент из стека и возвращает его
        /// </summary>
        /// <returns>Удаленный верхний элемент из стека</returns>
        public (T,T)? Pop()
        {
            (T,T) result = Values[Lenght - 1];
            Values[--Lenght] = default((T,T));
            return result;

        }
        /// <summary>
        /// Команда возвращает самый большой элемент стека
        /// </summary>
        /// <returns></returns>
        public T? GetMax()
        {
            if(Lenght > 0)
                return Values[Lenght - 1].Item2;
            return default(T?);
        }
        /// <summary>
        /// Печатает в консоли значения стека
        /// </summary>
        /// <param name="printHeader"></param>
        public void Print(bool printHeader = true)
        {
            if (printHeader)
                Console.WriteLine("Значения стека:");

            for (int i = 0; i < Lenght; i++)
            {
                Console.WriteLine($"   {Values[i].Item1.ToString()}");
            }
        }
        /// <summary>
        /// Показывает верхнее значение в стеке, но не меняет его
        /// </summary>
        /// <returns>Верхнее знаечние стека</returns>
        public T? Top()
        {
            if(Lenght > 0)
                return Values[Lenght - 1].Item1;
            return default(T?);
        }
        /// <summary>
        /// Размер стека
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return Lenght;
        }
        /// <summary>
        /// Стек пуст
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Lenght == 0;
        }
    }
}
