using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_App.YandexPracticum.AlgoritmsAndDataStructure.Sprint1.TypicalTasks.Tasks
{
    public class Combination : ITask
    {
        public Combination(IChapter chapter)
        {
            Chapter = chapter;
        }

        public IChapter Chapter { get; set; }

        public string Number => "P";

        public string Name => "Комбинации";

        public string Description => "Выдать все комбинации набранного текста старого мобильного телефона, основываясь на цифрах клавиш";

        public TaskStatus Status => TaskStatus.Completed;

        public void DoTask()
        {
            TaskHelper.ShowTaskHeader(Number, Name, Description);
            while(true)
            {
                string? input = null;
                while(input is null)
                {
                    Console.WriteLine("Введите строку из чисел от 2 до 9, для выхода введите 999");
                    input = Console.ReadLine();
                    if (!CheckUserInput(input))
                    {
                        Console.WriteLine("Эта строка не подходит, попробуйте еще раз");
                        input = null;
                        continue;
                    }
                    //if(input.Length > 5)
                    //{
                    //    Console.WriteLine("Эта строка очень длинная, вычислять будем долго) Давай строку поменьше?");
                    //    input = null;
                    //}
                }

                if (input == "999")
                    break;

                TreeS tree = new TreeS(input);

                Console.WriteLine($"Все возможные варианты набора:");
                Console.WriteLine($"------------------------------");
                foreach (string variant in tree.GetUniqueBranches())
                {
                    Console.Write($" {variant}");
                }
                Console.Write(Environment.NewLine);
                Console.WriteLine($"------------------------------");
            }
            TaskHelper.BackToMenu(Chapter);
        }

        /// <summary>
        /// Проверяет ввод пользователя. Если введена строка из цифр, где нет 1 - ок
        /// </summary>
        /// <param name="input">Строка ввода пользователя</param>
        /// <returns></returns>
        private bool CheckUserInput(string? input)
        {
            if(String.IsNullOrWhiteSpace(input))
                return false;
            foreach(char ch in input)
            {
                if (!Char.IsDigit(ch) || ch == '1')
                    return false;
            }
            return true;
        }

        

        private static class CombinationHelper
        {
            /// <summary>
            /// Возвращает массив вариантов букв, которые могли быть напечатаны кнопкой
            /// </summary>
            /// <param name="digit">Цифра, соответствующая кнопке</param>
            /// <returns></returns>
            public static char[] GetCharArray(char digit)
            {
                char[]? keyVariants;
                if (PhoneButtons.TryGetValue(digit, out keyVariants))
                {
                    return keyVariants;
                }
                else throw new Exception("Ошибка алгоритма, неизвестный символ");
            }

            public static string StringWithoutFirstSymbol(string target)
            {
                return target.Substring(1, target.Length - 1);
            }

            private static Dictionary<char, char[]> PhoneButtons = new Dictionary<char, char[]>()
            {
                {'2',['a','b','c'] },
                {'3',['d','e','f'] },
                {'4',['g','h','i'] },
                {'5',['j','k','l'] },
                {'6',['m','n','o'] },
                {'7',['p','q','r', 's'] },
                {'8',['t','u','v'] },
                {'9',['w','x','y', 'z'] },
            };
        }

        private class TreeNodeS
        {
            public TreeNodeS? Parent { get; set; }
            public List<TreeNodeS> Childrens { get; set; }
            public char? Char { get; set; }
            public TreeNodeS(TreeNodeS? parent, char? symbol, string nextString) 
            {
                Parent = parent;
                Char = symbol;
                Childrens = new List<TreeNodeS>();
                if(!String.IsNullOrWhiteSpace(nextString))
                    foreach (char ch in CombinationHelper.GetCharArray(nextString[0]))
                    {
                        Childrens.Add(new TreeNodeS(this, ch, CombinationHelper.StringWithoutFirstSymbol(nextString)));
                    }   
            }
            /// <summary>
            /// Возвращает ветки ноды
            /// </summary>
            /// <returns></returns>
            public List<string> GetBranches(string previous)
            {
                if (Childrens.Any())
                {
                    List<string> childrensBranches = new List<string>();
                    foreach (TreeNodeS node in Childrens)
                        childrensBranches = childrensBranches.Concat(node.GetBranches(previous + Char)).ToList();
                    return childrensBranches;
                }
                else
                {
                    List<string> result = new List<string>();
                    if (Char is not null)
                        result.Add(previous + Char.ToString()!);
                    return result;
                }
            }
        }

        private class TreeS
        {
            public TreeNodeS Header { get; private set; }
            public TreeS(string input)
            {
                if (String.IsNullOrWhiteSpace(input))
                    throw new Exception("Input error");
                Header = new TreeNodeS(null, null, input);
            }
            /// <summary>
            /// Возвращает все ветки дерева
            /// </summary>
            /// <returns></returns>
            public string[] GetBranches()
            {
                return Header.GetBranches("").ToArray();
            }
            /// <summary>
            /// Возвращает все уникальные ветки дерева
            /// </summary>
            /// <returns></returns>
            public string[] GetUniqueBranches()
            {
                HashSet<string> uniqueBranches = [.. GetBranches()];
                return uniqueBranches.ToArray();
            }
        }
    }
}
