using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.Classes
{
    public class StackH<T>: IStackOrQueue<T> where T : IComparable<T>
    {
        public StackH() { Values = new HashSet<T>(); }
        public StackH(T[] array) { Values = new HashSet<T>(array); }
        private HashSet<T> Values { get; set; }

        public T Pop()
        {
            T result = Top();
            Values.Remove(Top());
            return result;
        }

        public T Top()
        {
            return Values.Last();
        }

        public void Push(T item, bool print = false)
        {
            if (!Values.Add(item))
                Console.WriteLine("Элемент с таким значением уже находится в стеке");
            if(print)
                Print();
        }
        public int GetSize()
        {
            return Values.Count;
        }

        public void Print()
        {
            Console.WriteLine("Значения стека:");
            foreach (T item in Values)
            {
                Console.WriteLine($"   {item.ToString()}");
            }
        }

        public bool IsEmpty()
        {
            return !Values.Any();
        }
    }
}
