using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = GetStringFromUser("Введите не пустую строчку: ");
            Console.WriteLine(ReverseString(text));
            Console.WriteLine(ReverseStringWithArray(text));
            Console.ReadLine();
        }

        public static string ReverseStringWithArray(string text)
        {
            char[] lettersInText = text.ToCharArray();
            Array.Reverse(lettersInText);
            return new string(lettersInText);
        }

        public static string ReverseString(string text)
        {
            int iterator = 0;
            char[] words = text.ToCharArray(), reverseWords = new char[words.Length];
            for (int i = words.Length - 1; i >= 0; i--)
            {
                reverseWords[iterator] = words[i];
                iterator++;
            }
            return new string(reverseWords);
        }

        public static string GetStringFromUser(string message)
        {
            string result = null;
            while (true)
            {
                Console.WriteLine(message);
                result = Console.ReadLine();
                if (result.Length != 0 && !string.IsNullOrWhiteSpace(result))
                    break;
                else
                    Console.WriteLine("Вы ввели пустую строку :( Попробуйте ещё раз:");
            }
            return result;
        }
    }
}
