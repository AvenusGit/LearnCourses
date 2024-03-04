using Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2
{
    public class Sprint2 : ISprint
    {
        public Sprint2(YandexADCourse course) { 
            Course = course;
        }
        public ICourse Course { get; set; }

        public int Number => 2;

        public List<IChapter> Chapters => new List<IChapter>() { 
            new GreedyAlgoritmsChapter(this),
        };
    }
}
