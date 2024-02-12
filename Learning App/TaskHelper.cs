using Learning_App.YandexPracticum.Classes;
using System.Text;

namespace Learning_App
{
    public static class TaskHelper
    {
        /// <summary>
        /// Просто печатает название задачи
        /// </summary>
        /// <param name="taskNumber">Номер задачи</param>
        /// <param name="taskName">Название задачи</param>
        public static void ShowTaskHeader(string taskNumber, string taskName, string? description = null)
        {
            Console.Clear();
            Console.WriteLine("*******************************************************************");
            Console.WriteLine($"Задача {taskNumber}: {taskName}");
            if (String.IsNullOrEmpty(description))
                Console.WriteLine(description);
            Console.WriteLine("*******************************************************************");
        }

        /// <summary>
        /// Запрос у пользователя числа
        /// </summary>
        /// <param name="request">Строка - описание запроса</param>
        /// <returns></returns>
        public static int? GetCount(string request)
        {
            Console.WriteLine(request);
            int rowCount;
            string input = Console.ReadLine();
            if (int.TryParse(input, out rowCount))
                return rowCount;
            else
            {
                if(input == "exit")
                    Environment.Exit(0);
                if (input == "back")
                    return int.MaxValue;
                Console.WriteLine("Введенное значение не удалось привести к числу, попробуйте еще раз...");
                return null;
            }
        }
        /// <summary>
        /// Запрос от пользователя числа
        /// </summary>
        /// <param name="description">Описание того что мы хотим получить от пользователя</param>
        /// <returns></returns>
        public static int GetIntUserInput(string description)
        {
            int rowCount = -1;
            while (rowCount <= 0)
            {
                int? usersInput = GetCount(description);
                if (usersInput is not null && usersInput > 0)
                    rowCount = usersInput ?? -1;
                else Console.WriteLine("Это значение не подходит...");
            }
            Console.Clear();
            return rowCount;
        }
        /// <summary>
        /// Запрос у пользователя строки матрицы
        /// </summary>
        /// <param name="rowIndex">Номер строки</param>
        /// <param name="colCount">Количество столбцов</param>
        /// <returns>Массив строк</returns>
        public static int[]? GetIntArray(int rowIndex, int colCount)
        {
            Console.WriteLine($"Введите {rowIndex + 1} строку матрицы...");
            string? input = Console.ReadLine();
            if (input is null)
                return null;

            string[] values = input.Split(' ');
            if (values.Count() != colCount)
            {
                Console.WriteLine("Количество элементов не соответствует количеству ранее указаных столбцов");
                return null;
            }

            int[] rowValues = new int[colCount];
            for (int i = 0; i < values.Length; i++)
            {
                int rowValue;
                if (int.TryParse(values[i], out rowValue))
                {
                    rowValues[i] = rowValue;
                }
                else
                {
                    Console.WriteLine("Одно из значений не удоалось привести к числу, попробуйте еще раз...");
                    return null;
                }
            }
            return rowValues;
        }

        /// <summary>
        /// Ввод пользователем матрицы
        /// </summary>
        /// <param name="rowCount">Количество строк</param>
        /// <param name="colCount">Количество столбцов</param>
        /// <returns>Матрица</returns>
        public static int[,] InputMatrixRequest(int rowCount, int colCount)
        {
            int[,] matrix = new int[rowCount, colCount];
            for (int i = 0; i < rowCount; i++)
            {
                int[]? rowInput = GetIntArray(i, colCount);
                while (rowInput is null)
                {
                    rowInput = GetIntArray(i, colCount);
                }
                for (int j = 0; j < rowInput.Length; j++)
                {
                    matrix[i, j] = rowInput[j];
                }
            }
            return matrix;
        }

        /// <summary>
        /// Метод показа матрицы пользователю
        /// </summary>
        /// <param name="matrix">Матрица для показа</param>
        /// <param name="description">Описание матрицы</param>
        /// <param name="rowCount">Количество строк</param>
        /// <param name="colCount">Количество столбцов</param>
        public static void ShowMatrix(int[,] matrix, string? description, int rowCount, int colCount)
        {
            Console.WriteLine("");
            if (description is not null)
                Console.WriteLine(description);

            for (int i = 0; i < rowCount; i++)
            {
                StringBuilder builder = new StringBuilder();
                for (int j = 0; j < colCount; j++)
                {
                    builder.Append(" " + matrix[i, j]);
                }
                Console.WriteLine(builder);
            }
        }
        /// <summary>
        /// Просит пользователя ввести строки и превращаяет их в связанный список, необходимую для некоторых заданий
        /// </summary>
        /// <returns></returns>
        public static LinkedListS<string>? GetNodeHeader()
        {
            Console.WriteLine("Введите слова для значений нод через пробел...");
            string? input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input))
                return null;
            string[] values = input.Split(' ');
            Node<string>? previousNode = null;
            for (int i = values.Length -1 ; i > -1; i--)
            {
                Node<string> node = new Node<string>(values[i],previousNode);
                previousNode = node;
                if(i == 0)
                    return new LinkedListS<string>(node);
            }
            throw new Exception("Ошибка в алгоритме");
        }

        /// <summary>
        /// Просит пользователя ввести строки и превращаяет их в двухсвязный список, необходимую для некоторых заданий
        /// </summary>
        /// <returns></returns>
        public static DoubleLinkedListS<string>? GetDoubleNodeHeader()
        {
            Console.WriteLine("Введите слова для значений нод через пробел...");
            string? input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input))
                return null;
            string[] values = input.Split(' ');
            DoubleNode<string>? header = null;
            DoubleNode<string>? nextNode = null;
            DoubleNode<string>? previousNode = null;
            for (int i = 0; i < values.Length; i++)
            {
                DoubleNode<string> doubleNode = new DoubleNode<string>(values[i], nextNode, previousNode);
                if(doubleNode.PreviousNode is not null)
                    doubleNode.PreviousNode.NextNode = doubleNode;
                previousNode = doubleNode;
                if (i == 0)
                    header = doubleNode;
                if (i == values.Length - 1)
                    return new DoubleLinkedListS<string>(header!);
            }
            throw new Exception("Ошибка в алгоритме");
        }
        /// <summary>
        /// Просит пользователя ввести числа и превращаяет их в стэк, необходимый для некоторых заданий
        /// </summary>
        /// <returns></returns>
        public static StackS<int>? GetIntegerStack()
        {
            Console.WriteLine("Введите числа для значений стека через пробел...");
            string? input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input))
                return null;
            string[] values = input.Split(' ');
            List<int> stackValues = new List<int>();
            foreach (string str in values)
            {
                int parsedInt;
                if(Int32.TryParse(str, out parsedInt))
                    stackValues.Add(parsedInt);
                else
                {
                    Console.WriteLine("Не удалось определить одно из знаечний как число");
                    return null;
                }
            }
            return new StackS<int>(stackValues.ToArray());
        }
    }
}
