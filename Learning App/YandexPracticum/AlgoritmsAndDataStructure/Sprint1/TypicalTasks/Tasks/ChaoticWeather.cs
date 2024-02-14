using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    public class ChaoticWeather : ITask
    {
        public ChaoticWeather(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "C";

        public string Name => "Хаотичность погоды";

        public string Description => "Определить количество элементов массива, которые строго больше соседей, если они есть";

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            int[]? values = null;
            while(values is null)
            {
                values = TaskHelper.GetIntArray("Введите числа для поиска хаотичности через пробел");
            }
            int chaoticCount = 0;
            for(int i = 0; i < values.Length; i++)
            {
                bool isChaotic = true;                    
                isChaotic = i == 0 || values[i - 1] < values[i];
                isChaotic = isChaotic && (i == values.Length - 1 || values[i + 1] < values[i]);
                if(isChaotic) chaoticCount++;
            }
            Console.WriteLine($"Количество хаотичных дней: {chaoticCount}");
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
