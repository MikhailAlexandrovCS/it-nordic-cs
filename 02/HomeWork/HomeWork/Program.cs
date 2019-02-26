using System;

namespace HomeWork
{
    class Program
    {
        //------------------------------------------------------------------------
        // функция получения целочисленного числа с клавиатуры с проверкой ввода
        //------------------------------------------------------------------------
        public static int GetIntNumberFromKeyBoardByUser(string message)
        {
            int result;
            bool isCheck;
            do
            {
                Console.Write(message);
                isCheck = int.TryParse(Console.ReadLine(), out result);
            }
            while (isCheck == false);
            return result;
        }
        //------------------------------------------------------------------------
        // функция ввода дробного числа с клавиатуры с проверкой ввода
        //------------------------------------------------------------------------
        public static double GetDoubleNumberFromKeyBoardByUser(string message)
        {
            double result;
            bool isCheck;
            do
            {
                Console.Write(message);
                isCheck = double.TryParse(Console.ReadLine(), out result);
            }
            while (isCheck == false);
            return result;
        }
        //------------------------------------------------------------------------
        // функция соотношения введенного пользователем типа данных и ключевого слова
        //------------------------------------------------------------------------
        public static string GetNumberTypeByUser(string type)
        {
            if (type == "целое")
                return "int";
            return "double";
        }
        //------------------------------------------------------------------------
        // получение строки с типами данных вводимых чисел от пользователя
        //------------------------------------------------------------------------
        public static string GetNumbersTypesFromUser(string message)
        {
            Console.Write(message);
            string numbersTypes = Console.ReadLine();
            return numbersTypes;
        }
        //------------------------------------------------------------------------
        // функция получения результата суммы с перегрузками
        //------------------------------------------------------------------------
        public static int Sum(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        public static double Sum(int firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
        public static double Sum(double firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        public static double Sum(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
        //------------------------------------------------------------------------
        // функция получения результата разности с перегрузками
        //------------------------------------------------------------------------
        public static int Subtraction(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }
        public static double Subtraction(int firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
        public static double Subtraction(double firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }
        public static double Subtraction(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
        //------------------------------------------------------------------------
        // функция получения результата произведения с перегрузками
        //------------------------------------------------------------------------
        public static int Multiplication(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }
        public static double Multiplication(int firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
        public static double Multiplication(double firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }
        public static double Multiplication(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
        //------------------------------------------------------------------------
        // функция получения результата деления с перегрузками
        //------------------------------------------------------------------------
        public static int Division(int firstNumber, int secondNumber)
        {
            return firstNumber / secondNumber;
        }
        public static double Division(int firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber;
        }
        public static double Division(double firstNumber, int secondNumber)
        {
            return firstNumber / secondNumber;
        }
        public static double Division(double firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber;
        }
        //------------------------------------------------------------------------
        // функция получения остатка от деления с перегрузками
        //------------------------------------------------------------------------
        public static int RemainderOfDivision(int firstNumber, int secondNumber)
        {
            return firstNumber % secondNumber;
        }
        public static double RemainderOfDivision(int firstNumber, double secondNumber)
        {
            return firstNumber % secondNumber;
        }
        public static double RemainderOfDivision(double firstNumber, int secondNumber)
        {
            return firstNumber % secondNumber;
        }
        public static double RemainderOfDivision(double firstNumber, double secondNumber)
        {
            return firstNumber % secondNumber;
        }
        //------------------------------------------------------------------------
        // функция проверки ввода пользователем правильного типа данных
        //------------------------------------------------------------------------
        public static bool CheckUsersInputTypesIsCorrect(string[] types, object result)
        {
            if (Convert.ToInt32(result) == 0)
            {
                if (types.Length > 1)
                {
                    if (types[0] == "целое" || types[1] == "дробное")
                        return true;
                    if (types[0] == "дробное" || types[1] == "целое")
                        return true;
                }
            }
            else
            {
                if (types[0] == "целое")
                    return true;
                if (types[0] == "дробное")
                    return true;
            }
            return false;
        }
        //------------------------------------------------------------------------
        // функция меню
        //------------------------------------------------------------------------
        public static int menu(object result)
        {
            int menuNumber = -1;
            bool check;
            do
            {
                Console.WriteLine("1 - Сумма");
                Console.WriteLine("2 - Разность");
                Console.WriteLine("3 - Деление");
                Console.WriteLine("4 - Умножение");
                Console.WriteLine("5 - Остаток от деления");
                Console.WriteLine("6 - Возведение в степень");
                Console.WriteLine("7 - Обнулить значение");
                Console.WriteLine("0 - Выход");
                Console.WriteLine("Текущее значение: " + result);
                Console.Write("Выбор: ");
                check = int.TryParse(Console.ReadLine(), out menuNumber);
            }
            while (menuNumber > 7 || menuNumber < 0);
            return menuNumber;
        }
        static void Main(string[] args)
        {
            var result = 0.0;
            int menuParameter = -1;
            do
            {
                menuParameter = menu(result);
                switch (menuParameter)
                {
                    // подсчет суммы
                    case 1:
                        {
                            object firstNumber = 0, secondNumber = 0;
                            string[] types = null;
                            if (result == 0)    // если текущее значение 0, то пользователь вводит два числа
                            {
                                do
                                {
                                    types = GetNumbersTypesFromUser("Введите через пробел типы данных двух чисел, с которыми будет производиться операция (целое, дробное): ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                }
                                while (!CheckUsersInputTypesIsCorrect(types, result));
                                if (GetNumberTypeByUser(types[0]) == "int")
                                    firstNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    firstNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                if (GetNumberTypeByUser(types[1]) == "int")
                                    secondNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    secondNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                if (types[0] == "дробное" && types[1] == "дробное")
                                    result = Sum(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                                if (types[0] == "целое" && types[1] == "целое")
                                    result = Sum(Convert.ToInt32(firstNumber), Convert.ToInt32(secondNumber));
                                else
                                {
                                    if (firstNumber is int)
                                        result = Sum(Convert.ToInt32(firstNumber), Convert.ToDouble(secondNumber));
                                    if (secondNumber is int)
                                        result = Sum(Convert.ToDouble(firstNumber), Convert.ToInt32(secondNumber));
                                }
                                Console.WriteLine("Результат операции: " + result.ToString());
                            }
                            else  // иначе пользователь вводит только одно числа, к которому добавится результат предыдущего подсчета
                            {
                                do
                                {
                                    types = GetNumbersTypesFromUser("Введите тип данных числа, с которым будет производиться операция (целое, дробное): ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                }
                                while (!CheckUsersInputTypesIsCorrect(types, result));
                                if (GetNumberTypeByUser(types[0]) == "int")
                                    firstNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    firstNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                result += Convert.ToDouble(firstNumber);
                                Console.WriteLine("Результат операции: " + result.ToString());
                            }
                            break;
                        }
                    // подсчет разности
                    case 2:
                        {
                            object firstNumber = 0, secondNumber = 0;
                            string[] types = null;
                            if (result == 0)    // если текущее значение 0, то пользователь вводит два числа
                            {
                                do
                                {
                                    types = GetNumbersTypesFromUser("Введите через пробел типы данных двух чисел, с которыми будет производиться операция (целое, дробное): ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                }
                                while (!CheckUsersInputTypesIsCorrect(types, result));
                                if (GetNumberTypeByUser(types[0]) == "int")
                                    firstNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    firstNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                if (GetNumberTypeByUser(types[1]) == "int")
                                    secondNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    secondNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                if (types[0] == "дробное" && types[1] == "дробное")
                                    result = Subtraction(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                                if (types[0] == "целое" && types[1] == "целое")
                                    result = Subtraction(Convert.ToInt32(firstNumber), Convert.ToInt32(secondNumber));
                                else
                                {
                                    if (firstNumber is int)
                                        result = Subtraction(Convert.ToInt32(firstNumber), Convert.ToDouble(secondNumber));
                                    if (secondNumber is int)
                                        result = Subtraction(Convert.ToDouble(firstNumber), Convert.ToInt32(secondNumber));
                                }
                                Console.WriteLine("Результат операции: " + result.ToString());
                            }
                            else  // иначе пользователь вводит одно число для вычетания из текущего значения
                            {
                                do
                                {
                                    types = GetNumbersTypesFromUser("Введите тип данных числа, с которым будет производиться операция (целое, дробное): ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                }
                                while (!CheckUsersInputTypesIsCorrect(types, result));
                                if (GetNumberTypeByUser(types[0]) == "int")
                                    firstNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    firstNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                result -= Convert.ToDouble(firstNumber);
                                Console.WriteLine("Результат операции: " + result.ToString());
                            }
                            break;
                        }
                    // деление
                    case 3:
                        {
                            object firstNumber = 0, secondNumber = 0;
                            string[] types = null;
                            if (result == 0)    // если текущее значение 0, то пользователь вводит два числа
                            {
                                do
                                {
                                    types = GetNumbersTypesFromUser("Введите через пробел типы данных двух чисел, с которыми будет производиться операция (целое, дробное): ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                }
                                while (!CheckUsersInputTypesIsCorrect(types, result));
                                if (GetNumberTypeByUser(types[0]) == "int")
                                    firstNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    firstNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                if (GetNumberTypeByUser(types[1]) == "int")
                                    secondNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    secondNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                if (types[0] == "дробное" && types[1] == "дробное")
                                    result = Division(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                                if (types[0] == "целое" && types[1] == "целое")
                                    result = Division(Convert.ToInt32(firstNumber), Convert.ToInt32(secondNumber));
                                else
                                {
                                    if (firstNumber is int)
                                        result = Division(Convert.ToInt32(firstNumber), Convert.ToDouble(secondNumber));
                                    if (secondNumber is int)
                                        result = Division(Convert.ToDouble(firstNumber), Convert.ToInt32(secondNumber));
                                }
                                Console.WriteLine("Результат операции: " + result.ToString());
                            }
                            else   // иначе пользователь вводит одно число для деления на текущее значение
                            {
                                do
                                {
                                    types = GetNumbersTypesFromUser("Введите тип данных числа, с которым будет производиться операция (целое, дробное): ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                }
                                while (!CheckUsersInputTypesIsCorrect(types, result));
                                if (GetNumberTypeByUser(types[0]) == "int")
                                    firstNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    firstNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                result /= Convert.ToDouble(firstNumber);
                                Console.WriteLine("Результат операции: " + result.ToString());
                            }
                            break;
                        }
                    // умножение
                    case 4:
                        {
                            object firstNumber = 0, secondNumber = 0;
                            string[] types = null;
                            if (result == 0)    // если текущее значение 0, то пользователь вводит два числа
                            {
                                do
                                {
                                    types = GetNumbersTypesFromUser("Введите через пробел типы данных двух чисел, с которыми будет производиться операция (целое, дробное): ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                }
                                while (!CheckUsersInputTypesIsCorrect(types, result));
                                if (GetNumberTypeByUser(types[0]) == "int")
                                    firstNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    firstNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                if (GetNumberTypeByUser(types[1]) == "int")
                                    secondNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    secondNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                if (types[0] == "дробное" && types[1] == "дробное")
                                    result = Multiplication(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                                if (types[0] == "целое" && types[1] == "целое")
                                    result = Multiplication(Convert.ToInt32(firstNumber), Convert.ToInt32(secondNumber));
                                else
                                {
                                    if (firstNumber is int)
                                        result = Multiplication(Convert.ToInt32(firstNumber), Convert.ToDouble(secondNumber));
                                    if (secondNumber is int)
                                        result = Multiplication(Convert.ToDouble(firstNumber), Convert.ToInt32(secondNumber));
                                }
                                Console.WriteLine("Результат операции: " + result.ToString());
                            }
                            else    // иначе пользователь вводит одно число для умножения на текущее значение
                            {
                                do
                                {
                                    types = GetNumbersTypesFromUser("Введите тип данных числа, с которым будет производиться операция (целое, дробное): ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                }
                                while (!CheckUsersInputTypesIsCorrect(types, result));
                                if (GetNumberTypeByUser(types[0]) == "int")
                                    firstNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    firstNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                result = Multiplication(result, Convert.ToDouble(firstNumber));
                                Console.WriteLine("Результат операции: " + result.ToString());
                            }
                            break;
                        }
                    // получение остатка от деления
                    case 5:
                        {
                            object firstNumber = 0, secondNumber = 0;
                            string[] types = null;
                            if (result == 0)    // если текущее значение 0, то пользователь вводит два числа
                            {
                                do
                                {
                                    types = GetNumbersTypesFromUser("Введите через пробел типы данных двух чисел, с которыми будет производиться операция (целое, дробное): ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                }
                                while (!CheckUsersInputTypesIsCorrect(types, result));
                                if (GetNumberTypeByUser(types[0]) == "int")
                                    firstNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    firstNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                if (GetNumberTypeByUser(types[1]) == "int")
                                    secondNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    secondNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                if (types[0] == "дробное" && types[1] == "дробное")
                                    result = RemainderOfDivision(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                                if (types[0] == "целое" && types[1] == "целое")
                                    result = RemainderOfDivision(Convert.ToInt32(firstNumber), Convert.ToInt32(secondNumber));
                                else
                                {
                                    if (firstNumber is int)
                                        result = RemainderOfDivision(Convert.ToInt32(firstNumber), Convert.ToDouble(secondNumber));
                                    if (secondNumber is int)
                                        result = RemainderOfDivision(Convert.ToDouble(firstNumber), Convert.ToInt32(secondNumber));
                                }
                                Console.WriteLine("Результат операции: " + result.ToString());
                            }
                            else  // иначе пользователь вводит ожно число для получения остатка от деления от текущего значения
                            {
                                do
                                {
                                    types = GetNumbersTypesFromUser("Введите тип данных числа, с которым будет производиться операция (целое, дробное): ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                }
                                while (!CheckUsersInputTypesIsCorrect(types, result));
                                if (GetNumberTypeByUser(types[0]) == "int")
                                    firstNumber = GetIntNumberFromKeyBoardByUser("Введите целое число в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    firstNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                result = RemainderOfDivision(result,  Convert.ToDouble(firstNumber));
                                Console.WriteLine("Результат операции: " + result.ToString());
                            }
                            break;
                        }
                    // возведение в степень
                    case 6:
                        {
                            object firstNumber = 0, secondNumber = 0;
                            string[] types = null;
                            if (result == 0)    // если текущее значение 0, то пользователь вводит два числа: что возводить, в какую степень
                            {
                                do
                                {
                                    types = GetNumbersTypesFromUser("Введите через пробел типы данных двух чисел, с которыми будет производиться операция (целое, дробное): ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                }
                                while (!CheckUsersInputTypesIsCorrect(types, result));
                                if (GetNumberTypeByUser(types[0]) == "int")
                                    firstNumber = GetIntNumberFromKeyBoardByUser("Введите целое число, возводимое в степень в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    firstNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число, возводимое в степень в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                if (GetNumberTypeByUser(types[1]) == "int")
                                    secondNumber = GetIntNumberFromKeyBoardByUser("Введите целое число (степень) в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    secondNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число (степень) в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                result = Math.Pow(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                                Console.WriteLine("Результат операции: " + result.ToString());
                            }
                            else   // иначе пользователь вводит только одно число (степень) для возведения текущего значения
                            {
                                do
                                {
                                    types = GetNumbersTypesFromUser("Введите тип данных числа, с которым будет производиться операция (целое, дробное): ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                }
                                while (!CheckUsersInputTypesIsCorrect(types, result));
                                if (GetNumberTypeByUser(types[0]) == "int")
                                    firstNumber = GetIntNumberFromKeyBoardByUser("Введите целое число (степень) в промежутке [" + int.MinValue + "... " + int.MaxValue + "]: ");
                                else
                                    firstNumber = GetDoubleNumberFromKeyBoardByUser("Введите дробное число (степень) в промежутке [" + double.MinValue + "... " + double.MaxValue + "]: ");
                                result = Math.Pow(Convert.ToDouble(result), Convert.ToDouble(firstNumber));
                                Console.WriteLine("Результат операции: " + result.ToString());
                            }
                            break;
                        }
                    // обнуление текущего значения
                    case 7:
                        {
                            result = 0;
                            break;
                        }
                }
            }
            while (menuParameter != 0);
        }
    }
}
