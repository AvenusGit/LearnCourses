using Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks;
using Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures
{
    internal class TypicalTasksChapter : IChapter
    {
        public TypicalTasksChapter(ISprint sprint) { 
            Sprint = sprint;
        }
        public ISprint Sprint { get; set; }

        public string Name => "Типичные задания с собеседований";
        public int Number => 1;
        public List<ITask> Tasks => new List<ITask>() {
            new FunctionValue(this),
            new EvenOdd(this),
            new ChaoticWeather(this),
            new RemoveScores(this),
            new HomeWork(this),
            new DataBase(this),
            new Anagramms(this),
            new Palindrom(this),
            new BinarySystem(this),
            new Dinners(this),
            new OneNumbers(this),
            new ExtraLetter(this),
            new Frequency(this),
            new IsDegree(this),
        };
    }
}
