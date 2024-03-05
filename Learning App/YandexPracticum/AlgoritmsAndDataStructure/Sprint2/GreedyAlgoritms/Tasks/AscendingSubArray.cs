using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms.Tasks
{
    public class AscendingSubArray : ITask
    {
        public AscendingSubArray(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "H";

        public string Name => "Возврастающий подмассив";

        public string Description => "Вернуть наибольшего количества позрастающих значений в массиве подряд";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                int[]? values = null;
                while (values is null || values.Length == 0)
                {
                    values = TaskHelper.GetIntArray("Введите значения массива. Для выхода введите <999>");
                }

                if (values[0] == 999)
                    break;

                /** 0
                 *  l
                 *  1 2 1 2
                 *  r
                 *  O(n)/O(1)
                 */
                int globalMaximum = 0;
                for (int left = 0; left < values.Length; left++)
                {
                    int localMaximum = 0;
                    for (int right = left; right < values.Length; right++)
                    {

                        if (left == right)
                            continue;
                        if (values[right - 1] < values[right])
                            localMaximum++;
                        else
                        {
                            if(localMaximum > globalMaximum)
                                globalMaximum = localMaximum;
                            left = right - 1;
                            break;
                        }
                    }
                    if (localMaximum > globalMaximum)
                        globalMaximum = localMaximum;
                }
                Console.WriteLine($"Максимальная длинна возрастающего подмассива:{globalMaximum + 1}");

            }
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
