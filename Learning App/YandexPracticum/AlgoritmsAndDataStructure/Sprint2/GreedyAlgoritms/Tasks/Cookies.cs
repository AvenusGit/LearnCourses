using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms.Tasks
{
    public class Cookies : ITask
    {
        public Cookies(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "E";

        public string Name => "Печеньки";

        public string Description => "Определить максимальное количество довольных печеньем детей. " +
            "Ребенок считается довольным, если нашел незанятое печенье больше или равное минимальным требованиям";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                List<int>? childrens = null;
                while(childrens is null)
                {
                    childrens = TaskHelper.GetIntArray("Введите жадность детей (количество элементов - количество детей) через пробел" +
                        ", для выхода введите <999>")?.ToList();
                }

                if (childrens[0] == 999)
                    break;

                List<int>? cookies = null;
                while (cookies is null)
                {
                    cookies = TaskHelper.GetIntArray("Введите размер печенья (количество элементов - количество печенья) через пробел")
                        ?.ToList();
                }

                int result = 0;
                for (int i = 0; i < childrens.Count; i++)
                {
                    int cookieIndex;
                    if (FindCookieIndex(childrens[i],cookies, out cookieIndex))
                    {
                        result++;
                        cookies.RemoveAt(cookieIndex);
                    }
                }
                Console.WriteLine($"Количество довольных детей:{result}");
            }
            TaskHelper.BackToMenu(Chapter);
        }

        private bool FindCookieIndex(int greed, List<int> cookies, out int index)
        {
            (int, int)? minCookieSizeIndex = null;
            for (int i = 0; i < cookies.Count; i++)
            {                
                if (cookies[i] == greed)
                {
                    index = i;
                    return true;
                }
                if(cookies[i] > greed)
                {
                    if(minCookieSizeIndex is not null)
                    {
                        if (minCookieSizeIndex.Value.Item2 > cookies[i])
                            minCookieSizeIndex = new(i, cookies[i]);
                    }
                    else
                    {
                        minCookieSizeIndex = new(i, cookies[i]);
                    }                    
                }
            }
            if(minCookieSizeIndex is null)
            {
                index = 0;
                return false;
            }
            else
            {
                index = minCookieSizeIndex.Value.Item1;
                return true;
            }            
        }
    }
}
