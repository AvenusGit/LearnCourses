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
            if (!String.IsNullOrEmpty(description))
                Console.WriteLine($"   {description}");
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
        public static int[]? GetRowIntArray(int rowIndex, int colCount)
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
                int[]? rowInput = GetRowIntArray(i, colCount);
                while (rowInput is null)
                {
                    rowInput = GetRowIntArray(i, colCount);
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
        /// Запрашивает у пользователя строку и возвращает массив строк из нее разбитый по пробелам
        /// </summary>
        /// <returns></returns>
        public static string[]? GetStringArray(string? description = null)
        {
            if(description is not null) { 
                Console.WriteLine(description);
            }
            string? input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input))
                return null;
            return input.Split(' ');
        }
        /// <summary>
        /// Запрашивает у пользователя строку из чисел разделенных пробелом. Если все введено верно возвращает массив чисел.
        /// </summary>
        /// <param name="description">Описание запроса пользователю</param>
        /// <returns></returns>
        public static int[]? GetIntArray(string? description = null, bool onlyPositive = true)
        {
            if (description is not null)
            {
                Console.WriteLine(description);
            }
            string[]? strings = GetStringArray();
            if (strings is not null)
            {
                List<int> values = new List<int>();
                foreach (string str in strings)
                {
                    int parsedInt;
                    if (Int32.TryParse(str, out parsedInt))
                    {
                        if (onlyPositive)
                        {
                            if (parsedInt >= 0)
                                values.Add(parsedInt);
                            else
                            {
                                Console.WriteLine("Числа должны быть положительными");
                                return null;
                            }
                        }
                        else
                        {
                            values.Add(parsedInt);
                        }                        
                    }                        
                    else
                    {
                        Console.WriteLine("Не удалось определить одно из значений как число");
                        return null;
                    }
                }
                return values.ToArray();
            }
            else return null;
        }

        /// <summary>
        /// Просит пользователя ввести строки и превращаяет их в связанный список, необходимую для некоторых заданий
        /// </summary>
        /// <returns></returns>
        public static LinkedListS<string>? GetNodeHeader(string? description = null)
        {
            string[]? values = GetStringArray(description ?? "Введите слова для значений нод через пробел...");
            if (values is not null)
            {
                Node<string>? previousNode = null;
                for (int i = values.Length - 1; i > -1; i--)
                {
                    Node<string> node = new Node<string>(values[i], previousNode);
                    previousNode = node;
                    if (i == 0)
                        return new LinkedListS<string>(node);
                }
                throw new Exception("Ошибка в алгоритме");
            }
            else return null;
        }

        /// <summary>
        /// Просит пользователя ввести строки и превращаяет их в двухсвязный список, необходимую для некоторых заданий
        /// </summary>
        /// <returns></returns>
        public static DoubleLinkedListS<string>? GetDoubleNodeHeader()
        {
            string[]? values = GetStringArray("Введите слова для значений нод через пробел...");
            if (values is not null)
            {
                DoubleNode<string>? header = null;
                DoubleNode<string>? nextNode = null;
                DoubleNode<string>? previousNode = null;
                for (int i = 0; i < values.Length; i++)
                {
                    DoubleNode<string> doubleNode = new DoubleNode<string>(values[i], nextNode, previousNode);
                    if (doubleNode.PreviousNode is not null)
                        doubleNode.PreviousNode.NextNode = doubleNode;
                    previousNode = doubleNode;
                    if (i == 0)
                        header = doubleNode;
                    if (i == values.Length - 1)
                        return new DoubleLinkedListS<string>(header!);
                }
                throw new Exception("Ошибка в алгоритме");
            }
            else return null;            
        }
        /// <summary>
        /// Просит пользователя ввести числа и превращаяет их в стэк(S), необходимый для некоторых заданий
        /// </summary>
        /// <returns></returns>
        public static StackS<int>? GetPositiveIntegerStackS()
        {
            int[]? values = GetIntArray("Введите положительные целые числа для значений стека через пробел...");
            if (values is not null)
                return new StackS<int>(values);
            else return null;
        }
        /// <summary>
        /// Просит пользователя ввести числа и превращаяет их в стэк(M), необходимый для некоторых заданий
        /// </summary>
        /// <returns></returns>
        public static StackM<int>? GetPositiveIntegerStackM()
        {
            int[]? values = GetIntArray("Введите положительные целые числа для значений стека через пробел...");
            if(values is not null)
            {
                int maxValue = 0;
                List<(int, int)> stackArray = new List<(int, int)>();
                foreach (int val in values)
                {
                    if (val > maxValue)
                        maxValue = val;
                    stackArray.Add((val, maxValue));
                }
                return new StackM<int>(stackArray.ToArray());
            }
            else return null;            
        }

        /// <summary>
        /// Просит пользователя ввести числа и превращаяет их в стэк(H), необходимый для некоторых заданий
        /// </summary>
        /// <returns></returns>
        public static StackH<int>? GetPositiveIntegerStackH()
        {
            int[]? values = GetIntArray("Введите положительные целые числа для значений стека через пробел...");
            if(values is not null)
                return new StackH<int>(values);
            else return null;
        }

        /// <summary>
        /// Просит пользователя ввести числа и превращаяет их в очередь, необходимый для некоторых заданий
        /// </summary>
        /// <returns></returns>
        public static QueueS<int>? GetPositiveIntegerQueue()
        {
            int[]? values = GetIntArray("Введите положительные целые числа для значений очереди через пробел...");
            if (values is not null)
                return new QueueS<int>(values);
            else return null;
        }

        /// <summary>
        /// Просит пользователя ввести числа и превращаяет их в ограниченную очередь, необходимый для некоторых заданий
        /// </summary>
        /// <returns></returns>
        public static QueueLimitedS<int>? GetPositiveIntegerLimitedQueue()
        {
            int[]? values = GetIntArray("Введите положительные целые числа для значений  ограниченной очереди через пробел...");
            if (values is not null)
            {
                int? limit = null;
                while (limit is null)
                {
                    limit = GetCount("Введите числовой размер ограничения очереди");                   
                }
                return new QueueLimitedS<int>(limit.Value, values);
            }
            else return null;           
        }
        /// <summary>
        /// Запрашивает у пользователя значения и возвращает экземпляр ссылочной очереди
        /// </summary>
        /// <returns></returns>
        public static LinkedQueueS<int>? GetPositiveIntegerLinkedQueue()
        {
            int[]? values = GetIntArray("Введите положительные целые числа для значений списочной очереди через пробел...");
            if (values is not null)
                return new LinkedQueueS<int>(values);
            else return null;
        }

        public static void BackToMenu(IChapter chapter)
        {
            Console.WriteLine("Нажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            chapter.Selector();
        }
        /// <summary>
        /// Просит пользователя ввести команду и выполняет ее
        /// </summary>
        /// <param name="element">Коллекция, для которой требуется выполнить команду</param>
        public static string? InputCommand(IStackOrQueue<int> element)
        {
            Console.WriteLine("Ожидание команды:[push x, pop, top, size, print, isEmpty], для продолжения введите <continue>");
            string? answer = Console.ReadLine();
            if (answer == null)
            {
                Console.WriteLine("Пустой ввод");
                return "";
            }
            switch (answer)
            {
                case "continue":
                    return null;
                case string when answer.StartsWith("push"):
                    string[] commandParts = answer.Split(' ');
                    if (commandParts.Count() != 2)
                    {
                        Console.WriteLine("Неверный синтаксис, используй <push x>");
                        return answer;
                    }
                    int value;
                    if (Int32.TryParse(commandParts[1], out value))
                        element.Push(value, true);
                    else
                    {
                        Console.WriteLine("Число в команде не распознано...");
                        return answer;
                    }
                    return answer;
                case "pop":
                    Console.WriteLine(element.Pop());
                    return answer;
                case "top":
                    Console.WriteLine(element.Top());
                    return answer;
                case "size":
                    Console.WriteLine(element.GetSize());
                    return answer;
                case "print":
                    element.Print();
                    return answer;
                case "isEmpty":
                    Console.WriteLine(element.IsEmpty() ? "Пусто" : "Не пусто");
                    return answer;
                default:
                    {
                        Console.WriteLine("Неизвестная команда");
                        return answer;
                    }
            }

        }

        /// <summary>
        /// Просит пользователя ввести команду и выполняет ее
        /// </summary>
        /// <param name="element">Коллекция, для которой требуется выполнить команду</param>
        public static string? InputCommandStackM(StackM<int> element)
        {
            Console.WriteLine("Ожидание команды:[push x, pop, top, size, print, isEmpty], для продолжения введите <continue>");
            string? answer = Console.ReadLine();
            if (answer == null)
            {
                Console.WriteLine("Пустой ввод");
                return "";
            }
            switch (answer)
            {
                case "continue":
                    return null;
                case string when answer.StartsWith("push"):
                    string[] commandParts = answer.Split(' ');
                    if (commandParts.Count() != 2)
                    {
                        Console.WriteLine("Неверный синтаксис, используй <push x>");
                        return answer;
                    }
                    int value;
                    if (Int32.TryParse(commandParts[1], out value))
                        element.Push(value, true);
                    else
                    {
                        Console.WriteLine("Число в команде не распознано...");
                        return answer;
                    }
                    return answer;
                case "pop":
                    Console.WriteLine(element.Pop());
                    return answer;
                case "top":
                    Console.WriteLine(element.Top());
                    return answer;
                case "size":
                    Console.WriteLine(element.GetSize());
                    return answer;
                case "print":
                    element.Print();
                    return answer;
                case "isEmpty":
                    Console.WriteLine(element.IsEmpty() ? "Пусто" : "Не пусто");
                    return answer;
                default:
                    {
                        Console.WriteLine("Неизвестная команда");
                        return answer;
                    }
                }
            }

            /// <summary>
            /// Просит пользователя ввести команду и выполняет ее
            /// </summary>
            /// <param name="element">Коллекция, для которой требуется выполнить команду</param>
            public static string? InputCommandDequeu(DequeueS<int> element)
            {
                Console.WriteLine("Ожидание команды:[push x, pushBack x, pop, popBack, top, topBack, size, print, isEmpty, rebuild], ");
            Console.WriteLine("Для окончания ввода введите <continue>");
                string ? answer = Console.ReadLine();
                if (answer == null)
                {
                    Console.WriteLine("Пустой ввод");
                    return "";
                }
                switch (answer)
                {
                    case "continue":
                        return null;
                    case string when answer.StartsWith("push "):
                        string[] commandParts = answer.Split(' ');
                        if (commandParts.Count() != 2)
                        {
                            Console.WriteLine("Неверный синтаксис, используй <push x>");
                            return answer;
                        }
                        int value;
                        if (Int32.TryParse(commandParts[1], out value))
                            element.Push(value, true);
                        else
                        {
                            Console.WriteLine("Число в команде не распознано...");
                            return answer;
                        }
                        return answer;
                case string when answer.StartsWith("pushBack"):
                    commandParts = answer.Split(' ');
                    if (commandParts.Count() != 2)
                    {
                        Console.WriteLine("Неверный синтаксис, используй <pushBack x>");
                        return answer;
                    }
                    if (Int32.TryParse(commandParts[1], out value))
                        element.PushBack(value, true);
                    else
                    {
                        Console.WriteLine("Число в команде не распознано...");
                        return answer;
                    }
                    return answer;
                    case "pop":
                            Console.WriteLine(element.Pop());
                            return answer;
                    case "popBack":
                        Console.WriteLine(element.PopBack());
                        return answer;
                    case "top":
                            Console.WriteLine(element.Top());
                            return answer;
                    case "topBack":
                        Console.WriteLine(element.TopBack());
                        return answer;
                    case "size":
                        Console.WriteLine(element.GetSize());
                        return answer;
                    case "print":
                        element.Print();
                        return answer;
                    case "isEmpty":
                        Console.WriteLine(element.IsEmpty() ? "Пусто" : "Не пусто");
                        return answer;
                    case "rebuild":
                        if(!element.IsEmpty())
                            element.Rebuild(element.GetClearArray()!);                   
                        return answer;
                    case "cls":
                        Console.Clear();
                        return answer;
                    default:
                        {
                            Console.WriteLine("Неизвестная команда");
                            return answer;
                        }
                }

            }

        /// <summary>
        /// Метод определяет, является ли слово анаграммой шаблону
        /// </summary>
        /// <param name="target">Целевое слово</param>
        /// <param name="pattern">Шаблон</param>
        /// <returns>True - если да, False, если нет</returns>
        public static bool IsAnagramm(string target, string pattern)
        {
            if (target.Length != pattern.Length)
            {
                Console.WriteLine("Длины слова и паттерна не равны");
                return false;
            }
            // O(n^2)
            //foreach (char ch in target)
            //    if (!pattern.Contains(ch))
            //        return false;
            //return true;

            // O(3n)
            int[] charCount = new int[255]; // размер так то должен зависеть от кодировки
            foreach (char ch in target)
            {
                charCount[ch] += 1;
            }
            foreach (char ch in pattern)
            {
                if (charCount[ch] > 0)
                    charCount[ch] -= 1;
                else return false;
            }
            foreach (int count in charCount)
            {
                if(count != 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Метод определяет, является ли слово палиндромом шаблону
        /// </summary>
        /// <param name="target">Целевое слово</param>
        /// <param name="pattern">Шаблон</param>
        /// <returns>True - если да, False, если нет</returns>
        public static bool IsPalindrom (string target)
        {
            for (int i = 0, j = target.Length - 1; i < target.Length - 1; i++)
            {
                // отматываем до следующего действительного символа
                while (!Char.IsLetterOrDigit(target[i]))
                {
                    if (i == target.Length - 1)
                        return true;
                    else i++;
                }
                    
                while (!Char.IsLetterOrDigit(target[j]))
                {
                    if (j == 0)
                        return true;
                    else j--;
                }                    

                if (Char.ToLower(target[i]) == Char.ToLower(target[j]))
                {
                    j--;
                    continue;
                }                    
                else return false;
            }
            return true;
        }
        /// <summary>
        /// Определяет записано ли в строке бинарное число или нет
        /// </summary>
        /// <param name="target">Целевая строка</param>
        /// <returns></returns>
        public static bool IsBinaryIntString(string? target)
        {
            if(String.IsNullOrWhiteSpace(target) || target.First() != '1')
                return false;
            foreach (char ch in target)
            {
                if(ch != '0' && ch != '1')
                    return false;               
            }
            return true;
        }
        /// <summary>
        /// Принимает у пользователя строку с двоичным числом
        /// </summary>
        /// <param name="description">Описание запроса пользователю</param>
        /// <returns></returns>
        public static string GetBinaryStringInput(string? description = null)
        {
            string? result = null;
            while (result is null)
            {
                if(description is not null)
                    Console.WriteLine(description);
                result = Console.ReadLine();
                if (TaskHelper.IsBinaryIntString(result))
                    break;
                else
                {
                    Console.WriteLine("Это не двоичное число");
                    result = null;
                }
            }
            return result!;
        }
        /// <summary>
        /// Превращает десятичное число в строку с двоичным числом
        /// </summary>
        /// <param name="value">Число в 10 СС</param>
        /// <returns></returns>
        public static string IntToBinaryString(int value)
        {
            int n = value;
            string result = String.Empty;
            do
            {
                result = n % 2 + result;
                n = n / 2;
            } while (n > 0);
            return result;
        }
        /// <summary>
        /// Возвращает количество раз, которое символ встречается в строке
        /// </summary>
        /// <param name="target">Строка</param>
        /// <param name="targetChar">Символ</param>
        /// <returns></returns>
        public static int GetCharCount(string target, char targetChar)
        {
            int result = 0;
            foreach (char ch in target)
            {
                if(ch == targetChar)
                    result++;
            }
            return result;
        }
        /// <summary>
        /// Просит у пользователя строку записанную в польской нотации
        /// </summary>
        /// <param name="description">Как описать запрос пользователю</param>
        /// <returns></returns>
        public static string[]? GetPolishNotationString(string? description = null)
        {
            if(description is not null)
                Console.WriteLine($"{description}");

            string? input = Console.ReadLine();

            if(String.IsNullOrWhiteSpace(input)) return null;

            string[] values = input.Split(' ');
            foreach (string value in values)
            {
                if (value == "+" || value == "-" || value == "*" || value == "/")
                    continue;

                int digit;
                if(Int32.TryParse(value, out digit))
                    continue;
                return null;
            }
            return values;
        }
        /// <summary>
        /// Запрашивает у пользователя массив и возвращает стековую очередь из этого массива
        /// </summary>
        /// <param name="description">Описание запроса</param>
        /// <returns></returns>
        public static QueueStacky<int> GetQueueStacky(string? description = null)
        {
            int[]? values = GetIntArray(description ?? "Введите числа для значений очереди через пробел...");
            if(values is not null)
                return new QueueStacky<int>(values);
            else
                throw new Exception("Ошибка при создании очереди, массив пуст");
        }

        public static TimeRange[]? GetTimeRangeArray(string? description = null)
        {
            string[]? values = GetStringArray(description ?? "Введите диапазоны через пробел (например <abc:2:3 xyz:4.2:4.5 def:3:8>)");
            if(values is null)
            {
                Console.WriteLine("Не удалось распознать строки");
                return null;
            }
                
            List<TimeRange> result = new List<TimeRange>();
            foreach (string range in values)
            {
                TimeRange? newRange = TimeRange.Parse(range);
                if (newRange is not null)
                    result.Add(newRange.Value);
            }
            return result.ToArray();
        }
        /// <summary>
        /// Печатает массив диапазонов
        /// </summary>
        /// <param name="array">Целевой массив диапазонов</param>
        /// <returns></returns>
        public static void PrintTimeRangeArray(TimeRange[] array)
        {
            if(array is null || array.Length == 0)
            {
                Console.WriteLine("Массив пуст");
                return;
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendJoin(',', array);
            Console.WriteLine(stringBuilder.ToString());
        }
        /// <summary>
        /// Запрашивает у пользователя нецелое число
        /// </summary>
        /// <param name="description">Строка описания запроса</param>
        /// <returns></returns>
        public static double? GetDouble(string? description = null)
        {
            Console.WriteLine(description ?? "Введите не целое число ");
            string? value = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Не удалось определить число");
                return null;
            }
                

            double result;
            if(Double.TryParse(value, out result)){
                return result;
            }
            else
            {
                Console.WriteLine("Не удалось определить число");
                return null;
            }
        }
        /// <summary>
        /// Является ли строка Х подпоследовательностью строки y
        /// </summary>
        /// <param name="x">Строка которую ищем</param>
        /// <param name="y">Строка в которой ищем</param>
        /// <returns></returns>
        public static bool IsUnderSubstring(string x, string y)
        {
            // подпоследовательность - крч если символы есть в другой строке, в том же порядке, но не обязательно друг за другом
            int? fxIndex = 0;
            for (int i = 0; i < x.Length; i++)
            {
                fxIndex = FindCharInString(x[i], y, fxIndex);
                if (fxIndex is null)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Под каким индексом символ находится в строке
        /// </summary>
        /// <param name="ch">Искомый символ</param>
        /// <param name="target">Целевая строка</param>
        /// <param name="startIndex">С какого индекса искать</param>
        /// <returns>Индекс символа</returns>
        public static int? FindCharInString(char ch, string target, int? startIndex = 0)
        {
            for (int i = startIndex!.Value; i < target.Length; i++) 
            {
                if (target[i].Equals(ch))
                    return i;
            }
            return null;
        }
    }
}
