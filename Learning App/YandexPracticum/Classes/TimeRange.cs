using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.Classes
{
    /// <summary>
    /// Упрощенный временной промежуток
    /// </summary>
    public struct TimeRange
    {
        public TimeRange(string description,double from, double to)
        {
            Description = description;
            From = from; 
            To = to;
            if (From > To)
                throw new ArgumentException("Период не может быть создан с такими параметрами, <ПО> раньше чем <C>");
        }
        public string Description { get; set; }
        public double From { get; set; } = 0;
        public double To { get; set; } = 0;
        /// <summary>
        /// Получает диапазон из строки формата "x:y"
        /// </summary>
        /// <param name="value">Целевая строка</param>
        /// <returns></returns>
        public static TimeRange? Parse(string value)
        {
            if(value is null)
                return null;

            string[] values = value.Split(':');

            if(values.Length != 3)
                return null;


            double from;
            if (!Double.TryParse(values[1], out from))
            {
                Console.WriteLine("Не удалось определить число");
                return null;
            }

            double to;
            if (!Double.TryParse(values[2], out to))
            {
                Console.WriteLine("Не удалось определить число");
                return null;
            }

            return new TimeRange(values[0], from, to);
        }

        public override string ToString()
        {
            return $"{Description}:{From}:{To}";
        }
        /// <summary>
        /// Пересекаются ли два диапазона
        /// </summary>
        /// <param name="x">Первый диапазон</param>
        /// <param name="y">Второй диапазон</param>
        /// <returns></returns>
        public static bool IsInterSection(TimeRange x, TimeRange y)
        {
            return x.From > y.From ? y.To > x.From : x.To > y.From;
        }
    }
}
