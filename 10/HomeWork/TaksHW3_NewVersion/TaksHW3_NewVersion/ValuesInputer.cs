using System;
using System.Collections.Generic;
using System.Text;

namespace TaksHW3_NewVersion
{
    class ValuesInputer
    {
        public static Person[] GetValues(int maxPeopleValue)
        {
            Person[] people = new Person[maxPeopleValue];
            for (int i = 0; i < people.Length; i++)
            {
                try
                {
                    people[i] = new Person
                    {
                        Name = GetName($"Введите имя человека ({i + 1}): "),
                        Age = GetAge($"Введите возраст человека ({i + 1}): ")
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}\nВведите информаци о человеке повторно!");
                    i--;
                }
            }
            return people;
        }

        private static uint GetAge(string message)
        {
            uint age = 0;
            while (true)
            {
                if (age != 0)
                    break;
                Console.Write(message);
                try
                {
                    age = uint.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Неверный формат данных! " +
                        "Необходимо ввести положительнон натуральное число не превыщающее 100");
                    continue;
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Слишком большое значение или отрицательное!");
                    continue;
                }
            }
            return age;
        }

        private static string GetName(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
