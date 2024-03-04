using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.Classes
{
    /// <summary>
    /// Очередь состоящая из стеков (по заданию)
    /// </summary>
    public class QueueStacky<T> : IStackOrQueue<T> where T : IComparable<T>
    {
        public QueueStacky(T[] array) 
        {
            foreach (T item in array)
            {
                InputStack.Push(item);
            }
        }
        /// <summary>
        /// Входной стек
        /// </summary>
        private Stack<T> InputStack { get; set; } = new Stack<T>();
        /// <summary>
        /// Выходной стек
        /// </summary>
        private Stack<T> OutputStack { get; set; } = new Stack<T>();

        public int GetSize()
        {
            return InputStack.Count + OutputStack.Count;
        }

        public bool IsEmpty()
        {
            return GetSize() == 0;
        }

        public T? Pop()
        {
            PressOut();
            return InputStack.Pop();
        }

        public void Print()
        {
            if (InputStack.Count > 0)
            {
                PressOut();
                PressIn();
            }
            foreach (T item in OutputStack)
                Console.WriteLine(item);
        }

        public void Push(T item, bool print = false)
        {;
            InputStack.Push(item);
        }

        public T? Top()
        {
            PressOut();
            T value = InputStack.Peek();
            return value;
        }
        /// <summary>
        /// Метод перекачки из входного стека в выходной
        /// </summary>
        private void PressIn()
        {
            while (InputStack.Count > 0)
                OutputStack.Push(InputStack.Pop());
        }
        /// <summary>
        /// Метод перекачки из выходного стека в входной
        /// </summary>
        private void PressOut()
        {
            while (OutputStack.Count > 0)
                InputStack.Push(OutputStack.Pop());
        }
    }
}
