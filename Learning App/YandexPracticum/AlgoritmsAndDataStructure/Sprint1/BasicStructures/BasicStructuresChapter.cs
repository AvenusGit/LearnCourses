using Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures
{
    internal class BasicStructuresChapter : IChapter
    {
        public BasicStructuresChapter(ISprint sprint) { 
            Sprint = sprint;
        }
        public ISprint Sprint { get; set; }

        public string Name => "Базовые структуры данных";
        public int Number => 2;
        public List<ITask> Tasks => new List<ITask>() {
            new Circles(this),
            new MatrixTransponderTask(this),
            new SubstringTask(this),
            new Neighbours(this),
            new TaskList(this),
            new NoFavoritActivity(this),
            new CarefulMom(this),
            new RevertAll(this),
            new StackMax(this),
            new StackMaxEffictive(this),
            new StackSet(this),
            new Queue(this),
            new LimitedQueue(this),
            new Encryption(this),
        };
    }
}
