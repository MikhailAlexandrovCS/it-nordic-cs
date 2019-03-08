using System;

namespace HomeWorkPartOneEnumPractice
{
    class Program
    {
        [Flags]
        public enum Colors
        {
            Black = 1,
            Blue = 2,
            Cyan = 3,
            Grey = 4,
            Green = 5,
            Magenta = 6,
            Red = 7,
            White = 8,
            Yellow = 9
        }
        static void Main(string[] args)
        {
            Colors[] favoriteColors = GetFavoriteColorsFromCollection("Введите 4 избранных цвета: ");
            string[] allColors = Enum.GetNames(typeof(Colors));
            OutputFavoriteColors("Палитра избранных цветов: ", favoriteColors);
            OutputNotFavoriteColors("Оставшиеся цвета: ", favoriteColors, allColors);
            Console.ReadKey();
        }
        public static object GetColorFromUser()
        {
            object color;
            bool isColors;
            do
            {
                isColors = Enum.TryParse(typeof(Colors), Console.ReadLine(), out color);
            }
            while (!isColors);
            return color;
        }
        public static bool IsContains(Colors[] favoriteColors, string color)
        {
            for (int i = 0; i < favoriteColors.Length; i++)
                if (favoriteColors[i].ToString() == color)
                    return false;
            return true;
        }
        public static Colors[] GetFavoriteColorsFromCollection(string message)
        {
            Console.WriteLine(message);
            Colors[] favoriteColors = new Colors[4];
            for (int i = 0; i < favoriteColors.Length; i++)
                favoriteColors[i] = (Colors)GetColorFromUser();
            return favoriteColors;
        }
        public static void OutputFavoriteColors(string message, Colors[] favoriteColors)
        {
            Console.WriteLine(message);
            for (int i = 0; i < favoriteColors.Length; i++)
                Console.WriteLine(favoriteColors[i]);
        }
        public static void OutputNotFavoriteColors(string message, Colors[] favoriteColors, string[] allColors)
        {
            Console.WriteLine(message);
            for (int i = 0; i < allColors.Length; i++)
                if (IsContains(favoriteColors, allColors[i]))
                    Console.WriteLine(allColors[i]);
        }
    }
}
