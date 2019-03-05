using System;
using System.Drawing;
using System.Globalization;

namespace EnumPractice
{
    class Program
    {
        [Flags]
        enum Containers
        {
            oneLiter = 0x1,
            fiveLitres = 0x1 << 1,
            twentyLitres = 0x1 << 2
        }
        public static double GetVolumeOfJuiceFromUser(string message)
        {
            double volume;
            bool isCheck;
            do
            {
                Console.Write(message);
                isCheck = double.TryParse(Console.ReadLine(), out volume);
            }
            while (!isCheck);
            return volume;
        }
        public static (double, Int32) SetSignContainerInValue(double volume, Int32 sign)
        {
            if (volume - 20 >= 0 && sign == 0)
                sign = sign | (byte)Containers.twentyLitres;
            else
            {
                if (volume - 5 >= 0 && sign == 0)
                    sign = sign | (byte)Containers.fiveLitres;
                else
                    if (volume - 1 >= 0 && sign == 0)
                    sign = sign | (byte)Containers.oneLiter;
            }
            return (volume, sign);
        }
        public static (int, int, int, double) GetRecognizedContainer(Int32 sign, double volume, int count1L, int count5L, int count20L)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((sign & (0x1 << i)) == (byte)Containers.oneLiter)
                {
                    count1L++;
                    volume--;
                }
                else
                {
                    if ((sign & (0x1 << i)) == (byte)Containers.fiveLitres)
                    {
                        count5L++;
                        volume -= 5;
                    }
                    else
                    {
                        if ((sign & (0x1 << i)) == (byte)Containers.twentyLitres)
                        {
                            count20L = count20L + 1;
                            volume -= 20;
                        }
                    }

                }
            }
            return (count1L, count5L, count20L, volume);
        }
        public static void Output(int count1L, int count5L, int count20L, string message)
        {
            Console.WriteLine(message);
            var cursorPosition = new Point(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine(count20L == 0 ? string.Empty : "20 л: " + count20L.ToString() + " шт.");
            if (count20L == 0)
                Console.SetCursorPosition(0, 2);
            Console.WriteLine(count5L == 0 ? string.Empty : " 5 л: " + count5L.ToString() + " шт.");
            if (count20L == 0 && count5L == 0)
                Console.SetCursorPosition(0, 2);
            else
            {
                if (count5L == 0)
                    Console.SetCursorPosition(0, 3);
            }
            Console.WriteLine(count1L == 0 ? string.Empty : " 1 л: " + count1L.ToString() + " шт.");
        }
        static void Main(string[] args)
        {
            Int32 sign = 0;
            int count1L = 0, count5L = 0, count20L = 0;
            double volume = Math.Ceiling(GetVolumeOfJuiceFromUser("Введите объем сока в литрах: "));
            while (volume != 0)
            {
                var signerValues = SetSignContainerInValue(volume, sign);
                var containerValues = GetRecognizedContainer(signerValues.Item2, signerValues.Item1, count1L, count5L, count20L);
                count1L = containerValues.Item1;
                count5L = containerValues.Item2;
                count20L = containerValues.Item3;
                volume = containerValues.Item4;
                sign = 0;
            }
            Output(count1L, count5L, count20L, "Вам потребуются следующие контейнеры: ");
            Console.ReadKey();
        }
    }
}
