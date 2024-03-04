using Learning_App.YandexPracticum.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms.Tasks
{
    public class BackPack : ITask
    {
        public BackPack(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "D";

        public string Name => "Ценный рюкзак";

        public string Description => "Взять максимальное количество самых ценных предметов";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);     
            
            List<Item>? items = null;
            while(items is null)
                items = TaskHelper.GetItems("Введите предметы в формате <abc:1:2 xyz:3:4 def:5:6>");

            int? maxWeight = null;
            while(maxWeight is null)
                maxWeight = TaskHelper.GetIntUserInput("Введите максимальный вес");

            items = items.OrderByDescending(item => item.Worth).ToList();
            List<Item>? result = new List<Item>();
            int currentWeight = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (currentWeight == maxWeight)
                    break;
                if(currentWeight + items[i].Weight <= maxWeight)
                {
                    currentWeight += items[i].Weight;
                    result.Add(items[i]);
                }
            }
            Console.WriteLine("Выбранные предметы:");
            TaskHelper.PrintItemArray(result.ToArray());
            TaskHelper.BackToMenu(Chapter);
        }
    }
}
