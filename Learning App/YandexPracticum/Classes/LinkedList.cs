using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Learning_App.YandexPracticum.Classes
{
    /// <summary>
    /// Собственная реализация связанного списка
    /// </summary>
    /// <typeparam name="T">Тип значений связанного списка</typeparam>
    public class LinkedListS<T> where T : IComparable<T>
    {
        public LinkedListS() { }
        public LinkedListS(Node<T> header) { Header = header; }
        /// <summary>
        /// Ссылка на первый элемент связанного списка
        /// </summary>
        public Node<T>? Header { get; set; }
        /// <summary>
        /// Печать в консоли элементов связанного списка по одному на строку
        /// </summary>
        /// <param name="description">Описание того что мы печатаем</param>
        public void Print(string? description = null)
        {
            if (description is not null)
                Console.WriteLine(description);

            Node<T>? current = Header;
            while (current is not null)
            {
                Console.WriteLine(current.Value);
                current = current.NextNode;
            }
        }
        /// <summary>
        /// Переворачивает связанный список
        /// </summary>
        public void Revert()
        {
            Node<T>? prev = null, current = Header, next = null;
            while (current != null)
            {
                next = current.NextNode;
                current.NextNode = prev;
                prev = current;
                current = next;
            }
            Header = prev;
        }
        /// <summary>
        /// Удаляет элемент по указанному индексу
        /// Если такого элемента нет не удаляет ничего
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if(index < 0)
                throw new ArgumentOutOfRangeException("Индекс удаляемого элемента не может быть отрицательным");
            if (index == 0)
            {
                Header = Header?.NextNode;
                return;
            }
                
            int currentIndex = 0;
            Node<T>? previous = null, current = Header;
            while(currentIndex <= index + 1)
            {                
                if(currentIndex == index - 1)
                    previous = current;
                if(currentIndex == index + 1 && previous is not null)
                {
                    previous.NextNode = current;
                    return;
                }                   
                if(current?.NextNode is null && currentIndex < index)
                    throw new ArgumentOutOfRangeException("Для удаления задан индекс вне границ списка");
                else
                {
                    current = current?.NextNode;
                    currentIndex++;
                }                
            } 
        }
        /// <summary>
        /// Метод ищет в связанном списке указанное значение, если находит возвращает его индекс
        /// Иначе - ull
        /// </summary>
        /// <param name="item">Значение</param>
        /// <returns>Индекс этого знаечния в списке</returns>
        /// <exception cref="Exception"></exception>
        public int? IndexOf(T item)
        {
            int index = 0;
            Node<T>? current = Header;
            while (current != null)
            {
                if(current.Value.CompareTo(item) == 0)
                    return index;
                else
                {
                    if (current.NextNode is not null)
                    {
                        current = current.NextNode;
                        index++;
                    }
                    else return null;                
                }
            }
            throw new Exception("Ошибка алгоритма");
        }
        /// <summary>
        /// Метод возвращает элемент по указанному индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T? ElementOf(int index)
        {
            Node<T>? current = Header;
            for (int i = 0; i < index; i++)
            {
                current = current.NextNode;
            }
            return current is null ? default(T) : current.Value;
        }
        /// <summary>
        /// Метод добавления элемента в конец связанного списка
        /// </summary>
        /// <param name="item">Элемент для добавления</param>
        public void Add(T item)
        {
            if(Header is null)
            {
                Header = new Node<T>(item);
                return;
            }
            Node<T>? currentNode = Header;
            while(currentNode?.NextNode is not null)
            {
                currentNode = currentNode.NextNode;
            }
            currentNode.NextNode = new Node<T>(item);
        }

        /// <summary>
        /// Возвращает количество элементов в связанном списке
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;
                Node<T>? current = Header;
                while (current != null)
                {
                    count++;
                    current = current.NextNode;
                }
                return count;
            }
        }
        /// <summary>
        /// Проверяет наличие цикла в связанном списке
        /// </summary>
        /// <returns></returns>
        public bool IsCycled()
        {
            if (Header is null) return false;

            Node<T>? current = Header;
            while (current.NextNode is not null)
            {
                current = current.NextNode;
                if(current == Header)
                    return true;
            }
            return false;
        }
    }
}
