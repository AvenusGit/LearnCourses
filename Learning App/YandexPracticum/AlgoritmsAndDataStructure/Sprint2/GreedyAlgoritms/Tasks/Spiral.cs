using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint2.GreedyAlgoritms.Tasks
{
    public class Spiral : ITask
    {
        public Spiral(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "G";

        public string Name => "Спираль";

        public string Description => "Воспроизвести матрицу по спирали";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while (true)
            {
                int rowCount = TaskHelper.GetIntUserInput("Введите количество строк... Для выхода введите 999");
                if (rowCount == 999)
                    break;
                int colCount = TaskHelper.GetIntUserInput("Введите количество столбцов...");
                int[,] matrix = TaskHelper.InputMatrixRequest(rowCount, colCount);
                TaskHelper.ShowMatrix(matrix, "Исходная матрица...", rowCount, colCount);

                MatrixPrintSpiral(matrix, colCount, rowCount);
            }
            TaskHelper.BackToMenu(Chapter);
        }

        private void MatrixPrintSpiral(int[,] matrix, int colCount, int rowCount)
        {
            int top = -1, right = colCount, bottom = rowCount, left = 0, currentX = -1, currentY = 0;
            Directional directional = Directional.LeftToRight; bool canMove = true;
            List<int> results = new List<int>();
            while (canMove)
            {
                switch (directional)
                {
                    case Directional.LeftToRight:
                        {
                            for (int i = currentX + 1; i < right; i++)
                            {
                                currentX = i;
                                results.Add(matrix[currentY, currentX]);                                
                            }
                            top++;
                            directional = Directional.TopToBottom;
                            if(currentY == bottom - 1)
                                canMove = false;
                            break;
                        }
                    case Directional.RightToLeft:
                        {
                            for (int i = currentX - 1; i > left - 1; i--)
                            {
                                currentX = i;
                                results.Add(matrix[currentY, currentX]);
                               
                            }
                            bottom--;
                            directional = Directional.BottomToTop;
                            if (currentY == top + 1)
                                canMove = false;
                            break;
                        }
                    case Directional.TopToBottom:
                        {
                            for (int i = currentY + 1; i < bottom; i++)
                            {
                                currentY = i;
                                results.Add(matrix[currentY, currentX]);
                                
                            }
                            right--;
                            directional = Directional.RightToLeft;
                            if (currentX == left + 1)
                                canMove = false;
                            break;
                        }
                    case Directional.BottomToTop:
                        {
                            for (int i = currentY - 1; i > top; i--)
                            {
                                currentY = i;
                                results.Add(matrix[currentY, currentX]);                                
                            }
                            left++;
                            directional = Directional.LeftToRight;
                            if (currentX == right - 1)
                                canMove = false;
                            break;
                        }
                }
            }
            Console.WriteLine($"Итогово спиральное сообщение: {new StringBuilder().AppendJoin(' ', results)}");
        }
        /// <summary>
        /// Направление движения
        /// </summary>
        private enum Directional
        {
            LeftToRight,
            TopToBottom,
            RightToLeft,
            BottomToTop,
        }
    }
}
