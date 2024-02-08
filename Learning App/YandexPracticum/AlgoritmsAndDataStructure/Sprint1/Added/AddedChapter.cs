using Learning_App.One;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.Added
{
    internal class AddedChapter : IChapter
    {
        public AddedChapter(ISprint sprint) { 
            Sprint = sprint;
        }
        public ISprint Sprint { get; set; }

        public string Name => "Разбор задач в теории";
        public List<ITask> Tasks => new List<ITask>() { 
            new Decoder(this),
            new Revertor(this),
        };
    }
}
