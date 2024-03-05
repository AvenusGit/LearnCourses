using Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms
{
    public class GreedyAlgoritmsChapter : IChapter
    {
        public GreedyAlgoritmsChapter(ISprint sprint) { 
            Sprint = sprint;
        }
        public ISprint Sprint { get; set; }

        public string Name => "Жадные алгоритмы";
        public int Number => 1;
        public List<ITask> Tasks => new List<ITask>() {
            new Schedule(this),
            new StockExchange(this),
            new IsSubstring(this),
            new BackPack(this),
            new Cookies(this),
            new SortedStrings(this),
            new Spiral(this),
            new AscendingSubArray(this),
            new SameAmounts(this),
            new LastWord(this),
            new Mortgage(this),
            new Ladder(this),
        };
    }
}
