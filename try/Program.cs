using System.Security.Cryptography;

namespace Try;
internal class Program
{
    /*
     * Задание 1
    Создайте приложение калькулятор для перевода числа из одной системы исчисления в другую. 
    Пользователь с помощью меню выбирает направление перевода. Например, из десятичной в двоичную. 
    После выбора направления, пользователь вводит число в исходной системе исчисления. 
    Приложение должно перевести число в требуемую систему.
    Предусмотреть случай выхода за границы диапазона, определяемого типом int, неправильный ввод.
    */



    static string ConverterFromBin(string binNumber, int numeralSystem)
    {
        int newNumber = 0;

        if (numeralSystem == 10) // перевод в десятичную
        {
            for (int i = 0; i < binNumber.Length; ++i)
            {
                newNumber += (int) Math.Pow(2, i) * (binNumber[binNumber.Length - i - 1] - 48);  
            }
        }
        else // перевод в восьмеричную
        {
            while (binNumber.Length % 3 != 0) // добавляются нули (например, было 1001, стало  001 001 - это по формуле нужно)
            {
                binNumber = binNumber.Insert(0, "0");
            }

            for (int i = 0; i < binNumber.Length; i += 3) //
            {
                if (binNumber.Length != 3)
                {
                    newNumber += Convert.ToInt32(ConverterFromBin(binNumber.Remove(i, 3), 10)) * (int) Math.Pow(10, i / 3);
                }
                else
                {
                    newNumber += Convert.ToInt32(ConverterFromBin(binNumber, 10));
                }
            }
        }

        return Convert.ToString(newNumber);
    }

    static string ConverterFromOct(int binNumber, int numeralSystem)
    {
        string newNumber = "";

        for (int i = 0; binNumber / numeralSystem > 0; ++i)
        {
            newNumber += binNumber % numeralSystem;
            binNumber /= numeralSystem;
        }
        newNumber += binNumber % numeralSystem;

        return new string(newNumber.Reverse().ToArray());
    }

    static string ConverterFromDec(int decNumber, int numeralSystem)
    {
        string newNumber = "";

        for (int i = 0; decNumber / numeralSystem > 0; ++i)
        {
            newNumber += decNumber % numeralSystem;
            decNumber /= numeralSystem;
        }
        newNumber += decNumber % numeralSystem;

        return new string(newNumber.Reverse().ToArray());
    }



    static void Function1()
    {
        int number = 0;
        int choice = 0;


        Console.WriteLine($"ВЫБЕРИТЕ ОТКУДА И КУДА ХОТИТЕ ПЕРЕВЕСТИ ЧИСЛО");
        Console.WriteLine("1 - из 2-ичной в 10-ичную");
        Console.WriteLine("2 - из 2-ичной в 8-ричную\n");

        Console.WriteLine("3 - из 8-ричной в 2-ичную");
        Console.WriteLine("4 - из 8-ричной в 10-ричную\n");

        Console.WriteLine("5 - из 10-ичной в 2-ичную");
        Console.WriteLine("6 - из 10-ичной в 8-ричную\n");

        try
        { 
            Console.Write("Ваш выбор: ");
            choice = int.Parse(Console.ReadLine());

            if (choice < 1 || choice > 6)
            {
                throw new Exception($"ваш ввод ({choice}) выходит за диапазон выбора!");
            }
        
            Console.Write("Введите число: ");
            number = int.Parse(Console.ReadLine());
        }
        catch (OverflowException oe) // выход за диапазон int
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"ОШИБКА: ваш ввод вне диапазона! ({oe.Message})\n"); Console.ResetColor();
            Function1();
        }
        catch (FormatException ae) // ввод не int
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"ОШИБКА: ваш ввод не является числом! ({ae.Message})\n"); Console.ResetColor();
            Function1();
        }
        catch (Exception e) // иные исключения
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"ОШИБКА: {e.Message}\n"); Console.ResetColor();
            Function1();
        }



        Console.Write("Результат: ");
        switch (choice) 
        {
            case 1: Console.WriteLine(ConverterFromBin(Convert.ToString(number), 10)); break; // +
            case 2: Console.WriteLine(ConverterFromBin(Convert.ToString(number), 8)); break; // +
            case 3: Console.WriteLine(ConverterFromOct(number, 2)); break; // 
            case 4: Console.WriteLine(ConverterFromOct(number, 10)); break; //
            case 5: Console.WriteLine(ConverterFromDec(number, 2)); break; // +
            case 6: Console.WriteLine(ConverterFromDec(number, 8)); break; // +

        }



    }

    /*
     * Задание 2
    Пользователь вводит словами цифру от 0 до 9. Приложение должно перевести слово в цифру. 
    Например, если пользователь ввёл five, приложение должно вывести на экран 5. 
    */

    /*
     * Задание 3
    Создайте класс «Заграничный паспорт». 
    Вам необходимо хранить информацию о номере паспорта, ФИО владельца, дате выдачи и т.д. 
    Предусмотреть механизмы для инициализации полей класса. 
    Если значение для инициализации неверное, генерируйте исключение. 
    */

    /*
     * Задание 4
    Пользователь вводит в строку с клавиатуры логическое выражение. Например, 3>2 или 7<3. 
    Программа должна посчитать результат введенного выражения и дать результат true или false. 
    В строке могут быть только целые числа и операторы: <, >, <=, >=, ==, !=. 
    Для обработки ошибок ввода используйте механизм исключений.
     */

    static void Main()
    {
        Function1();
    }
}