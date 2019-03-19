using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckLineForRightBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string textWithBrackets = null;
            while(true)
            {
                Console.Write("Введите строку, состояющую из различных скобок для анализа на правильность: ");
                textWithBrackets = Console.ReadLine();
                if (IsBracketsOnly(textWithBrackets))
                    break;
            }
            Console.WriteLine(IsCorrectString(textWithBrackets) ? "Строка правильная!" : "Строка неправильная!");
            Console.ReadKey();
        }

        public static bool IsBracketsOnly(string textWithBrackets)
        {
            foreach (char symbol in textWithBrackets)
                if (!(symbol.Equals('[') || symbol.Equals('{') || symbol.Equals('(')
                    || symbol.Equals(']') || symbol.Equals('}') || symbol.Equals(')')))
                    return false;
            return true;
        }

        public static bool IsCorrectString(string textWithBrackets)
        {
            if(textWithBrackets.Length % 2 == 0)
            {
                Stack<char> brackets = new Stack<char>(textWithBrackets.Length);
                for (int bracketIndex = 0; bracketIndex < textWithBrackets.Length; bracketIndex++)
                {
                    switch (textWithBrackets[bracketIndex])
                    {
                        case '(':
                            {
                                brackets.Push(textWithBrackets[bracketIndex]);
                                break;
                            }
                        case '[':
                            {
                                brackets.Push(textWithBrackets[bracketIndex]);
                                break;
                            }
                        case '{':
                            {
                                brackets.Push(textWithBrackets[bracketIndex]);
                                break;
                            }
                        case ')':
                            {
                                DeleteFromStackIfNeed(brackets, '(');
                                break;
                            }
                        case ']':
                            {
                                DeleteFromStackIfNeed(brackets, '[');
                                break;
                            }
                        case '}':
                            {
                                DeleteFromStackIfNeed(brackets, '{');
                                break;
                            }
                    }
                }
                if (brackets.Count == 0)
                    return true;
            }
            return false;
        }

        public static void DeleteFromStackIfNeed(Stack<char> brackets, char bracket)
        {
            if (brackets.Count != 0 && bracket == brackets.Peek())
                brackets.Pop();
        }
    }
}
