using System;

namespace CapitalCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            double initialPayment = GetValueFromUser("Введите сумму первоначальнго взноса в реблях: ");
            double dailyPercentage = GetValueFromUser("Введите ежедневный процент дохода в виде десятичной дроби"
                + SetupPercentage(initialPayment) + ": ");
            double accumulationCount = GetValueFromUser("Введите желаемую сумму накопления в рублях: ");
            Console.WriteLine("Необходимое количество дней для накопления желаемой суммы: " 
                + GetDaysToAccumulationCount(initialPayment, dailyPercentage, accumulationCount));
            Console.ReadKey();
        }

        public static int GetDaysToAccumulationCount(double initialPayment, double dailyPercentage, double accumulationCount)
        {
            int days = 0;

            while(true)
            {
                if (initialPayment >= accumulationCount)
                    break;
                initialPayment += initialPayment * dailyPercentage;
                days++;
            }
            return days;
        }

        public static string SetupPercentage(double initialPayment)
        {
            return " (1 % - " + (initialPayment * 0.0001).ToString() + ")";
        }

        public static double GetValueFromUser(string message)
        {
            double result = -1;

            while(true)
            {
                if (result != -1)
                    break;
                try
                {
                    Console.Write(message);
                    result = double.Parse(Console.ReadLine());
                }
                catch(OverflowException e)
                {
                    Console.WriteLine("Ошибка " + e.GetType().ToString() + "! Введите значение еще раз:");
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Ошибка " + e.GetType().ToString() + "! Введите значение еще раз:");
                }
                catch(ArgumentNullException e)
                {
                    Console.WriteLine("Ошибка " + e.GetType().ToString() + "! Введите значение еще раз:");
                }
            }

            return result;

        }
    }
}
