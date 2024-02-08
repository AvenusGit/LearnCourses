using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures
{
    /// <summary>
    /// Задача получить от пользователя матрицу и транспонировать ее (повернуть на 90 градусов)
    /// </summary>
    public class MatrixTransponderTask : ITask
    {

        public MatrixTransponderTask(IChapter chapter) 
        { 
            Chapter = chapter; 
        }
        public IChapter Chapter { get; set; }
        public string Number => "B";
        public string Name => "Мониторинг";

        public string Description => "Задача получить от пользователя матрицу и транспонировать ее (повернуть на 90 градусов)";

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name);
            int rowCount = TaskHelper.GetIntUserInput("Введите количество строк...");
            int colCount = TaskHelper.GetIntUserInput("Введите количество столбцов...");
            int[,] matrix = TaskHelper.InputMatrixRequest(rowCount, colCount);
            TaskHelper.ShowMatrix(matrix, "Исходная матрица...", rowCount, colCount);
            TaskHelper.ShowMatrix(TransformMatrix(matrix, rowCount, colCount), "Пребразованная матрица", rowCount, colCount);
            BackToMenu();
        }

        /// <summary>
        /// Метод транспонирования матрицы
        /// </summary>
        /// <param name="matrix">Целевая матрица</param>
        /// <param name="rowCount">Количество строк</param>
        /// <param name="colCount">Количество столбцов</param>
        /// <returns></returns>
        private int[,] TransformMatrix(int[,] matrix, int rowCount, int colCount)
        {
            int[,] result = new int[rowCount, colCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }
            return result;
        }
        /// <summary>
        /// Метод возврата в меню
        /// </summary>
        public void BackToMenu()
        {
            Console.WriteLine("Нажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            Chapter.Selector();
        }
    }
}
