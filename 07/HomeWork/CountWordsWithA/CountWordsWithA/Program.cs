using System;

namespace CountWordsWithA
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = GetWordsFromUser("Введите строку из нескольких слов: ");
            Console.WriteLine("Количество слов, начинающихся на букву 'А': " + CountWordsWithLetterA(words));
            Console.ReadKey();
        }

        public static uint CountWordsWithLetterA(string[] words)
        {
            uint counter = 0;
            for (int i = 0; i < words.Length; i++)
                if (words[i].Contains('а', StringComparison.InvariantCultureIgnoreCase))
                    counter++;
            return counter;
        }

        public static string[] GetWordsFromUser(string message)
        {
            string[] words = null;
            Console.Write(message);
            while (true)
            {
                try
                {
                    words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length >= 2)
                        break;
                    else
                        Console.WriteLine("Слишком мало слов :( Попробуйте ещё раз:");
                }
                catch(NullReferenceException e)
                {
                    continue;
                }
            }
            return words;
        }
    }
}
