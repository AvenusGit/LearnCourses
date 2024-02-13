using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.Classes
{
    public class LinkedQueueS<T> : IStackOrQueue<T> where T : IComparable<T>
    {
        public LinkedQueueS(T[] array)
        {
            List = new LinkedListS<T>();
            foreach (T item in array)
            {
                List.Add(item);
            }
        }

        private LinkedListS<T> List { get; set; }

        public int GetSize()
        {
            return List.Count;
        }

        public bool IsEmpty()
        {
            return List.Count == 0;
        }

        public T? Pop()
        {
            T? result = List.ElementOf(0);
            if(result is not null)
                List.RemoveAt(0);
            return result;
        }

        public void Print()
        {
            List.Print();
        }

        public void Push(T item, bool print = false)
        {
            List.Add(item);
            if(print)
                Print();
        }

        public T? Top()
        {
            return List.ElementOf(0);
        }
    }
}
