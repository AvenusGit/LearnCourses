using Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.Added;
using Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures;
using Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1
{
    public class Sprint1 : ISprint
    {
        public Sprint1(YandexADCourse course) { 
            Course = course;
        }
        public ICourse Course { get; set; }

        public int Number => 1;

        public List<IChapter> Chapters => new List<IChapter>() { 
            new AddedChapter(this),
            new BasicStructuresChapter(this),
        };
    }
}
