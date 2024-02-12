using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.Classes
{
    /// <summary>
    /// Двухсвязный список
    /// </summary>
    /// <typeparam name="T">Тип списка</typeparam>
    public class DoubleNode<T>
    {
        public T? Value;
        public DoubleNode<T>? NextNode;
        public DoubleNode<T>? PreviousNode;

        public DoubleNode(T? value, DoubleNode<T>? nextValue = null, DoubleNode<T>? previousValue = null)
        {
            Value = value;
            NextNode = nextValue;
            PreviousNode = previousValue;
        }
    }
}
