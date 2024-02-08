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
        public List<ITask> Tasks => new List<ITask>() { 
            new MatrixTransponderTask(this),
            new SubstringTask(this),
            new Neighbours(this),
        };
    }
}
