using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.Classes
{
    /// <summary>
    /// Предмет с массой и стоимостью
    /// </summary>
    public struct Item
    {
        public Item(string name, int weight, int cost)
        {
            Name = name;
            Weight = weight;
            Cost = cost;
        }
        /// <summary>
        /// Название предмета
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Вес в граммах
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public int Cost { get; set; }
        /// <summary>
        /// Отношение стоимости к массе
        /// </summary>
        public int Worth
        {
            get
            {
                return Cost / Weight;
            }
        }


        public static Item? Parse(string value)
        {
            if(String.IsNullOrWhiteSpace(value))
                return null;

            string[] values = value.Split(':');

            if (values.Length != 3)
                return null;


            int weight;
            if (!Int32.TryParse(values[1], out weight))
            {
                Console.WriteLine("Не удалось определить число");
                return null;
            }

            int cost;
            if (!Int32.TryParse(values[2], out cost))
            {
                Console.WriteLine("Не удалось определить число");
                return null;
            }

            return new Item(values[0], weight, cost);
        }
        public override string ToString()
        {
            return $"{Name}({Weight}g/{Cost}$)";
        }
    }
}
