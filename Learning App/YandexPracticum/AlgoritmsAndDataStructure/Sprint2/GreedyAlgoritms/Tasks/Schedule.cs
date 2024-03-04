using Learning_App.YandexPracticum.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms.Tasks
{
    public class Schedule : ITask
    {
        public Schedule(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "A";

        public string Name => "Расписание";

        public string Description => "Определить наибольшее количество не пересекающихся периодов";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            TimeRange[]? values = null;
            while (values is null)
            {
                values = TaskHelper.GetTimeRangeArray("Введите диапазоны чисел.");
            }
            // пример:::  Физика:9:10 Алгебра:9,1:9,5 Химия:10,25:10,45 Физкультура:10,4:11,25 Биология:11,1:12

            // сортируем по времени окончания
            List<TimeRange> result = new List<TimeRange>();
            values = values.OrderBy(x => x.To).ToArray();
            result.Add(values[0]);
            foreach (TimeRange range in values)
            {
                if(!TimeRange.IsInterSection(result.Last(), range))
                    result.Add(range);
            }

            TaskHelper.PrintTimeRangeArray(result.ToArray());
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
