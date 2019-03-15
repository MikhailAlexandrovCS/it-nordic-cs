using System;
using System.Text;

namespace IndependentWork
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "   lorem    ipsum    dolor      sit   amet  ";
            Console.WriteLine(text);
            Console.WriteLine("Результат работы 1-го метода: " + FirstVersion(text.Trim()));
            Console.WriteLine("Результат работы 2-го метода: " + SecondVersion(text.Trim()));
            Console.ReadKey();
        }

        public static string SecondVersion(string text)
        {
            DateTime start = DateTime.Now;
            string[] temp = GetArrayOfStringWords(text);
            temp[1] = temp[1].ToUpper();
            for (int i = 0; i < temp.Length; i++)
                temp[i] = new StringBuilder(temp[i]).Append(" ").ToString();
            DateTime end = DateTime.Now;
            Console.WriteLine("Время работы 2-го метода: " + (end - start).TotalMilliseconds + "мс");
            return string.Concat(temp);
        }

        public static string[] GetArrayOfStringWords(string text)
        {
            return text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        public static string FirstVersion(string text)
        {
            DateTime start = DateTime.Now;
            string[] temp = GetArrayOfStringWords(text);
            temp[1] = temp[1].ToUpper();
            text = string.Empty;
            foreach (string str in temp)
                text += str + " ";
            DateTime end = DateTime.Now;
            Console.WriteLine("Время работы 1-го метода: " + (end - start).TotalMilliseconds + "мс");
            return text;
        }

    }
}
