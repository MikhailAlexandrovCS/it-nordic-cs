using System;

namespace CountEvenDigitsInNumber
{
    class Program
    {
        private const int _maxValue = 2_000_000_000;

        static void Main(string[] args)
        {
            int number = GetNumberFromUserByKeyBoard("Введите положительное натуральное число не более 2 миллиардов: ");
            int result = CountEvenDigit(number);
            Console.WriteLine("В числе " + number.ToString() + " содержится следующее значение четных цифр: " + result.ToString());
            Console.ReadKey();
        }

        public static int CountEvenDigit(int result)
        {
            int countDigits = 0;

            while(true)
            {
                if (result == 0)
                    break;
                int residue;
                result = Math.DivRem(result, 10, out residue);
                Math.DivRem(residue, 2, out residue);
                if (residue == 0)
                    countDigits++;
            }

            return countDigits;
        }

        public static int GetNumberFromUserByKeyBoard(string message)
        {
            int result = -1;

            while(true)
            {
                try
                {
                    Console.Write(message);
                    result = int.Parse(Console.ReadLine());
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Ошибка " + e.GetType().ToString() + "! Попробуйте ещё раз:");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ошибка " + e.GetType().ToString() + "! Попробуйте ещё раз:");
                }
                if (result <= _maxValue && result != - 1)
                    break;
                else
                    Console.WriteLine("Число превышет максимальное значение, которое задано в условии " 
                        + _maxValue.ToString() + " . Повторите попытку: ");  
            }

            return result;
        }
    }
}
