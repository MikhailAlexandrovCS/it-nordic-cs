using System;

namespace EnumPractice
{
    class Program
    {
        [Flags]
        public enum Containers
        {
            oneLiter = 0x1,
            fiveLitres = 0x1 << 1,
            twentyLitres = 0x1 << 2
        }
        static void Main(string[] args)
        {
            Int32 sign = 0;
            string[] allContainers = Enum.GetNames(typeof(Containers));
            int[] countLiters = new int[3];
            Array.Reverse(allContainers);
            int[] containersValues = { 20, 5, 1 };
            int volume = (int)Math.Ceiling(GetVolumeOfJuiceFromUser("Введите объем сока в литрах: "));
            for (int i = 0; i < allContainers.Length; i++)
            {
                sign = SetSign(sign, volume, (Containers)Enum.Parse(typeof(Containers), allContainers[i]), containersValues[i]);
                countLiters[i] = CountUsingContainers(volume, containersValues[i]);
                volume = SubtractionVolume(volume, containersValues[i]);
            }
            Output(sign, countLiters);
            Console.ReadKey();
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
            while (!isCheck || volume <= 0);
            return volume;
        }
        public static Int32 SetSign(Int32 sign, int volume, Containers containers, int containerValue)
        {
            if (Math.DivRem(volume, containerValue, out volume) > 0)
                sign = sign | (byte)containers;
            return sign;
        }
        public static int SubtractionVolume(int volume, int containerValue)
        {
            int resVolume;
            Math.DivRem(volume, containerValue, out resVolume);
            return resVolume;
        }
        public static int CountUsingContainers(int volume, int containerValue)
        {
            int tmp;
            int result = Math.DivRem(volume, containerValue, out tmp);
            return result;
        }
        public static void Output(Int32 sign, int[] countLitres)
        {
            if ((sign & (byte)Containers.twentyLitres) == (byte)Containers.twentyLitres)
                Console.WriteLine("20 л: " + countLitres[0] + " шт.");
            if ((sign & (byte)Containers.fiveLitres) == (byte)Containers.fiveLitres)
                Console.WriteLine(" 5 л: " + countLitres[1] + " шт.");
            if ((sign & (byte)Containers.oneLiter) == (byte)Containers.oneLiter)
                Console.WriteLine(" 1 л: " + countLitres[2] + " шт.");
        }
    }
}
