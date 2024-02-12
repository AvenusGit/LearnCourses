using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.Classes
{
    /// <summary>
    /// Собственная реализация двухсвязного списка
    /// </summary>
    /// <typeparam name="T">Тип двухсвязного списка</typeparam>
    public  class DoubleLinkedListS<T>
    {
        public DoubleLinkedListS(DoubleNode<T> header) { Header = header; }
        /// <summary>
        /// Ссылка на первый элемент
        /// </summary>
        public DoubleNode<T>? Header { get; set; }

        /// <summary>
        /// Печать в консоли элементов двухсвязного списка по одному на строку
        /// </summary>
        /// <param name="description">Описание того что мы печатаем</param>
        public void Print(string? description = null)
        {
            if (description is not null)
                Console.WriteLine(description);

            DoubleNode<T>? current = Header;
            while (current is not null)
            {
                Console.WriteLine(current.Value);
                current = current.NextNode;
            }
        }
        /// <summary>
        /// Переворачивает двойной связанный список
        /// </summary>
        public void Revert()
        {
            if (Header is null || Header.NextNode is null)
                return;

            DoubleNode<T>? temp = null, current = Header;
            while (current is not null) 
            {
                temp = current.PreviousNode;
                current.PreviousNode = current.NextNode;
                current.NextNode = temp;
                Header = current;
                current = current.PreviousNode;                
            }
        }
    }
}
