using Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks;
using Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.FinalTasks.Tasks;
using Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures
{
    internal class FinallTasksChapter : IChapter
    {
        public FinallTasksChapter(ISprint sprint) { 
            Sprint = sprint;
        }
        public ISprint Sprint { get; set; }

        public string Name => "Финальные задания";
        public int Number => 3;
        public List<ITask> Tasks => new List<ITask>() {
            new Calculator(this),
        };
    }
}
