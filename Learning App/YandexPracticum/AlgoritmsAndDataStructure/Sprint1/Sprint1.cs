using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
        };

        public void SelectChapter()
        {

        }
    }
}
