using System;
using System.ComponentModel;

namespace HomeWorkPartTwo
{
    class Program
    {
        
        public enum Figures
        {
            Circle = 1,
            Triangle = 2,
            Rectangle = 3
        }

        static void Main(string[] args)
        {
            FigureWorker worker = new FigureWorker();
            try
            {
                Figures figure = InputValue("Введите тип фигуры (" + GetAllFiguresInOneString(Enum.GetNames(typeof(Figures)), worker) + "): ");
                GetAreaAndPerimeterOfFigure(figure, worker);
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

        public static void GetAreaAndPerimeterOfFigure(Figures figure, FigureWorker worker)
        {
            switch (figure.ToString())
            {

                case "Circle":
                    {

                        worker.CircleRun(figure.ToString());
                        break;
                    }
                case "Triangle":
                    {
                        worker.TrinagleRun(figure.ToString());
                        break;
                    }
                case "Rectangle":
                    {
                        worker.RectangleRun(figure.ToString());
                        break;
                    }
                default:
                    {
                        throw new InvalidEnumArgumentException();
                    }
            }
        }

        public static string GetAllFiguresInOneString(string[] allFigures, FigureWorker worker)
        {
            for (int i = 0; i < allFigures.Length; i++)
                allFigures[i] = (i + 1).ToString() + " - " + worker.TranslateEnglishToRussian(allFigures[i]) + ", ";
            return string.Concat(allFigures).Substring(0, string.Concat(allFigures).Length - 2);
        }
    }
}
