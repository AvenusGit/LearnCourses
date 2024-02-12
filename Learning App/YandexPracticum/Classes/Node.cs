using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.Classes
{
    /// <summary>
    /// Описание класса ноды из задания
    /// </summary>
    /// <typeparam name="T">Тип, который можно привести к строке</typeparam>
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? NextNode { get; set; }

        public Node(T value, Node<T>? nextValue = null)
        {
            Value = value;
            NextNode = nextValue;
        }

    }
}
