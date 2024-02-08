using Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure
{
    /// <summary>
    /// Яндексовский курс по алгоритмам и структурам данных из практикума
    /// </summary>
    public class YandexADCourse : ICourse
    {
        public YandexADCourse(Program program) { Program = program; }
        public Program Program { get; set; }
        public int Number { get => 1; }
        public string Name
        {
            get
            {
                return "Сборник задач по Яндекс Практикуму - Алгоритмы и структуры данных";
            }
        }
        public List<ISprint> Sprints
        {
            get
            {
                return new List<ISprint>()
                {
                    new Sprint1.Sprint1(this)
                };
            }
        }
    }
}
