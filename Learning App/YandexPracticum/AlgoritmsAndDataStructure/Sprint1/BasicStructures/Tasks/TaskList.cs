﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning_App.YandexPracticum.Classes;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures.Tasks
{
    public class TaskList : ITask
    {
        public TaskList(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "E";

        public string Name => "Список дел";

        public string Description => "Описать функцию, которая пишет список дел. Узел списка описывается как нода связанного списка." +
            " Эта задача не предполагает ввода.";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            LinkedListS<string>? head = null;
            while (head is null)
            {
                head = TaskHelper.GetNodeHeader();
            }
            Console.WriteLine("Ты этого не увидишь в консоли, но тут связанный список:");
            Solution(head);
            TaskHelper.BackToMenu(Chapter);
        }
        /// <summary>
        /// Решение задания
        /// </summary>
        /// <param name="head">Головная нода</param>
        private void Solution(LinkedListS<string> list)
        {
            list.Print();
        }


    }

}
