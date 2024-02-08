using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.BasicStructures
{
    /// <summary>
    /// Задача "Соседи". На ввод подается матрица, и координаты одного его элемента. 
    /// Выводом должны быть соседи этого элемента (по строке, по столбцу если есть) в порядке возрастания. 
    /// Диагональные соседи не считаются.
    /// </summary>
    public class Neighbours : ITask
    {
        public Neighbours(IChapter chapter) 
        {
            Chapter = chapter;
        }
        public IChapter Chapter { get; set; }

        public string TaskNumber => "D";

        public string Name => "Соседи";

        public string Description => "Задача <Соседи>. На ввод подается матрица, и координаты одного её элемента. " +
            "Выводом должны быть соседи этого элемента (по строке, по столбцу если есть) в порядке возрастания. " +
            "Диагональные соседи не считаются.";

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader("D", "Соседи(Поиск соседей элемента матрицы)");
            int rowCount = TaskHelper.GetIntUserInput("Введите количество строк...");
            int colCount = TaskHelper.GetIntUserInput("Введите количество столбцов...");
            int[,] matrix = TaskHelper.InputMatrixRequest(rowCount, colCount);
            TaskHelper.ShowMatrix(matrix, "Исходная матрица...", rowCount, colCount);
            int targetRow = TaskHelper.GetIntUserInput("В какой строке целевой элемент? (счет идет с нуля)");
            int targetCol = TaskHelper.GetIntUserInput("В каком столбце целевой элемент? (счет идет с нуля)");
            PrintNeighbours(GetNeighbours(matrix, rowCount, colCount, targetRow, targetCol), true);
        }

        /// <summary>
        /// Метод находит соседей указанной цели в матрице и возвращает массив значений этих соседей
        /// </summary>
        /// <param name="matrix">Матрица значений</param>
        /// <param name="matrixRowCount">Количество строк в матрице</param>
        /// <param name="matrixColCount">Количество столбцов в матрице</param>
        /// <param name="targetRow">Строка цели</param>
        /// <param name="targetCol">Столбец цели</param>
        /// <returns>Массив значений соседей цели</returns>
        private List<int> GetNeighbours(int[,] matrix, int matrixRowCount, int matrixColCount, int targetRow, int targetCol)
        {
            List<int> neighbours = new List<int>();
            // слева
            if (targetCol > 0)
                neighbours.Add(matrix[targetRow, targetCol - 1]);
            // сверху
            if (targetRow > 0)
                neighbours.Add(matrix[targetRow - 1, targetCol]);
            // справа
            if (targetCol < matrixColCount)
                neighbours.Add(matrix[targetRow, targetCol + 1]);
            // снизу
            if (targetRow < matrixRowCount)
                neighbours.Add(matrix[targetRow + 1, targetCol]);
            return neighbours;
        }
        /// <summary>
        /// Метод печатает список соседей
        /// </summary>
        /// <param name="neighbours">Список соседей</param>
        /// <param name="sortByAscending">Нужно ли сортировать список</param>
        private void PrintNeighbours(List<int> neighbours, bool sortByAscending = false)
        {
            if (sortByAscending)
                neighbours.Sort();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int neighbour in neighbours)
            {
                stringBuilder.Append($" {neighbour}");
            }
            Console.WriteLine(stringBuilder);
        }
    }
}
