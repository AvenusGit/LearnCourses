using Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms.Tasks;
using Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.Recursion.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.Recursion
{
    public class RecursionChapter : IChapter
    {
        public RecursionChapter(ISprint sprint) { 
            Sprint = sprint;
        }
        public ISprint Sprint { get; set; }

        public string Name => "Рекурсия";
        public int Number => 2;
        public List<ITask> Tasks => new List<ITask>() {
            new RecursiveFibonachiNumbers(this),
            new RecursiveFibonachiNumbersMemory(this),
            new RecursiveFibonachiNumbersMemoryEffective(this),
        };
    }
}
