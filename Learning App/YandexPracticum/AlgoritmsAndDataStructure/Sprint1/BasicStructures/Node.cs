using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures
{
    /// <summary>
    /// Описание класса ноды из задания
    /// </summary>
    /// <typeparam name="T">Тип, который можно привести к строке</typeparam>
    public class Node<T>
    {
        public T Value;
        public Node<T>? NextNode;

        public Node(T value, Node<T>? nextValue)
        {
            Value = value;
            NextNode = nextValue;
        }
    }
}
