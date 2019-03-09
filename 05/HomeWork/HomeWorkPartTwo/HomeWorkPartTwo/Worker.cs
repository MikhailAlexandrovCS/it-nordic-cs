using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HomeWorkPartTwo
{
    class FigureWorker
    {
        private string _messageArea = "Площадь поверхности ";
        private string _messagePerimeter = "Длина периметра ";

        private const int _countNumbersAfterComma = 3;

        public FigureWorker() { }

        private void MessageForUser(string figureType, bool isRect)
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


        public string TranslateEnglishToRussian(string figure)
        {
            if (figure == "Circle")
                return "Круг";
            if (figure == "Triangle")
                return "Треугольник";
            return "Прямоугольник";
        }

        public void CircleRun(string figure)
        {
            try
            {
                MessageForUser(figure.ToString(), false);
                Circle circle = new Circle(double.Parse(Console.ReadLine()));
                Console.WriteLine(_messageArea + " " + (TranslateEnglishToRussian(figure.ToString()) + "а").ToLower() + ": " + circle.CircleArea(_countNumbersAfterComma).ToString());
                Console.WriteLine(_messagePerimeter + " " + (TranslateEnglishToRussian(figure.ToString()) + "а").ToLower() + ": " + circle.CirclePerimeter(_countNumbersAfterComma).ToString());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ошибка! Введено не числовое значение!");
            }
        }

        public void TrinagleRun(string figure)
        {
            try
            {
                MessageForUser(figure.ToString(), false);
                Triangle trinagle = new Triangle(double.Parse(Console.ReadLine()));
                Console.WriteLine(_messageArea + (TranslateEnglishToRussian(figure.ToString()) + "а").ToLower() + ": " + trinagle.TrinagleArea(_countNumbersAfterComma).ToString());
                Console.WriteLine(_messagePerimeter + (TranslateEnglishToRussian(figure.ToString()) + "а").ToLower() + ": " + trinagle.TrianglePerimeter(_countNumbersAfterComma).ToString());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ошибка! Введено не числовое значение!");
            }
        }

        public void RectangleRun(string figure)
        {
            try
            {
                MessageForUser(figure.ToString(), true);
                double height = double.Parse(Console.ReadLine());
                MessageForUser(figure.ToString(), false);
                double width = double.Parse(Console.ReadLine());
                Rectangle rectangle = new Rectangle(height, width);
                Console.WriteLine(_messageArea + (TranslateEnglishToRussian(figure.ToString()) + "а").ToLower() + ": " + rectangle.RectangleArea(_countNumbersAfterComma).ToString());
                Console.WriteLine(_messagePerimeter + " " + (TranslateEnglishToRussian(figure.ToString()) + "а").ToLower() + ": " + rectangle.RectanglePerimeter(_countNumbersAfterComma).ToString());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ошибка! Введено не числовое значение!");
            }
        }
    }
}
