using System;
using System.ComponentModel;

namespace HomeWorkPartTwo
{
    class Program
    {
        private const int _countNumbersAfterComma = 3;
        public enum Figures
        {
            Circle = 1,
            Triangle = 2,
            Rectangle = 3
        }
        static void Main(string[] args)
        {
            try
            {
                Figures figure = InputValue("Введите тип фигуры (" + GetAllFiguresInOneString(Enum.GetNames(typeof(Figures))) + "): ");
                GetAreaAndPerimeterOfFigure(figure, "Площадь поверхности ", "Длина периметра ");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Введеный Вами аргумент неправильный! Программа завершает работу");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Введеное Вами значение очень большое! Программа завершает работу");
            }
            Console.ReadKey();
        }
        public static Figures InputValue(string message)
        {
            Console.WriteLine(message);
            return (Figures)Enum.Parse(typeof(Figures), Console.ReadLine());
        }
        public static void GetAreaAndPerimeterOfFigure(Figures figure, string messageArea, string messagePerimeter)
        {
            switch (figure.ToString())
            {

                case "Circle":
                    {
                        try
                        {
                            MessageForUser(figure.ToString(), false);
                            Circle circle = new Circle(double.Parse(Console.ReadLine()));
                            Console.WriteLine(messageArea + " " + (TranslateEnglishToRussian(figure.ToString()) + "а").ToLower() + ": " + circle.CircleArea(_countNumbersAfterComma).ToString());
                            Console.WriteLine(messagePerimeter + " " + (TranslateEnglishToRussian(figure.ToString()) + "а").ToLower() + ": " + circle.CirclePerimeter(_countNumbersAfterComma).ToString());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Ошибка! Введено не числовое значение!");
                        }
                        break;
                    }
                case "Triangle":
                    {
                        try
                        {
                            MessageForUser(figure.ToString(), false);
                            Triangle trinagle = new Triangle(double.Parse(Console.ReadLine()));
                            Console.WriteLine(messageArea + (TranslateEnglishToRussian(figure.ToString()) + "а").ToLower() + ": " + trinagle.TrinagleArea(_countNumbersAfterComma).ToString());
                            Console.WriteLine(messagePerimeter + (TranslateEnglishToRussian(figure.ToString()) + "а").ToLower() + ": " + trinagle.TrianglePerimeter(_countNumbersAfterComma).ToString());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Ошибка! Введено не числовое значение!");
                        }
                        break;
                    }
                case "Rectangle":
                    {
                        try
                        {
                            MessageForUser(figure.ToString(), true);
                            double height = double.Parse(Console.ReadLine());
                            MessageForUser(figure.ToString(), false);
                            double width = double.Parse(Console.ReadLine());
                            Rectangle rectangle = new Rectangle(height, width);
                            Console.WriteLine(messageArea + (TranslateEnglishToRussian(figure.ToString()) + "а").ToLower() + ": " + rectangle.RectangleArea(_countNumbersAfterComma).ToString());
                            Console.WriteLine(messagePerimeter + " " + (TranslateEnglishToRussian(figure.ToString()) + "а").ToLower() + ": " + rectangle.RectanglePerimeter(_countNumbersAfterComma).ToString());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Ошибка! Введено не числовое значение!");
                        }
                        break;
                    }
            }
        }
        public static string TranslateEnglishToRussian(string figure)
        {
            if (figure == "Circle")
                return "Круг";
            if (figure == "Triangle")
                return "Треугольник";
            return "Прямоугольник";
        }
        public static void MessageForUser(string figureType, bool isRect)
        {
            switch (figureType)
            {
                case "Circle":
                    {
                        Console.WriteLine("Введите диаметр круга: ");
                        break;
                    }
                case "Triangle":
                    {
                        Console.WriteLine("Введите сторону треугольника: ");
                        break;
                    }
                case "Rectangle":
                    {
                        if (isRect)
                            Console.WriteLine("Введите высоту прямоугольника: ");
                        else
                            Console.WriteLine("Введите ширину прямоугольника: ");
                        break;
                    }
            }
        }
        public static string GetAllFiguresInOneString(string[] allFigures)
        {
            for (int i = 0; i < allFigures.Length; i++)
                allFigures[i] = (i + 1).ToString() + " - " + TranslateEnglishToRussian(allFigures[i]) + ", ";
            return string.Concat(allFigures).Substring(0, string.Concat(allFigures).Length - 2);
        }
    }
}
