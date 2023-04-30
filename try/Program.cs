using System.Text.RegularExpressions;


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

    static string ConverterFromBinToOct(string binNumber)
    {
        int newNumber;

        newNumber = Convert.ToInt32(ConverterFromDecToOct(Convert.ToInt32(ConverterFromBinToDec(binNumber)))); // из двоичного в десятичное, из десятичного в восьмеричное

        return Convert.ToString(newNumber);
    }

    static string ConverterFromBinToDec(string binNumber)
    {
        int newNumber = 0;

        for (int i = 0; i < binNumber.Length; ++i)
        {
            newNumber += (int) Math.Pow(2, i) * (binNumber[binNumber.Length - i - 1] - 48);  
        }

        return Convert.ToString(newNumber);
    }

    //

    static string ConverterFromOctToBin(int octNumber)
    {
        string newNumber;

        newNumber = ConverterFromDecToBin(Convert.ToInt32(ConverterFromOctToDec(octNumber)));

        return newNumber;
    }

    static string ConverterFromOctToDec(int octNumber)
    {
        string octNumberStr = Convert.ToString(octNumber);
        int newNumber = 0;

        for (int i = 0; i < octNumberStr.Length; ++i)
        {
            newNumber += (int)Math.Pow(8, i) * (octNumberStr[octNumberStr.Length - i - 1] - 48);
        }

        return Convert.ToString(newNumber);
    }

    //

    static string ConverterFromDecToBin(int decNumber)
    {
        string newNumber = "";

        for (int i = 0; decNumber / 2 > 0; ++i)
        {
            newNumber += decNumber % 2;
            decNumber /= 2;
            Console.WriteLine($"newNumber {newNumber}");
        }
        newNumber += decNumber % 2;
        Console.WriteLine($"newNumber {newNumber}");

        return new string(newNumber.Reverse().ToArray());
    }

    static string ConverterFromDecToOct(int decNumber)
    {
        string newNumber = "";

        for (int i = 0; decNumber / 8 > 0; ++i)
        {
            newNumber += decNumber % 8;
            decNumber /= 8;
        }
        newNumber += decNumber % 8;

        return new string(newNumber.Reverse().ToArray());
    }

    //

    static void Exercise1()
    {
        int number;
        int choice;


        Console.WriteLine($"ВЫБЕРИТЕ ОТКУДА И КУДА ХОТИТЕ ПЕРЕВЕСТИ ЧИСЛО");
        Console.WriteLine("1 - из 2-ичной в 8-ричную");
        Console.WriteLine("2 - из 2-ичной в 10-ичную\n");

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


            Console.Write("Результат: ");
            switch (choice)
            {
                case 1: Console.WriteLine(ConverterFromBinToOct(Convert.ToString(number))); break; // +
                case 2: Console.WriteLine(ConverterFromBinToDec(Convert.ToString(number))); break; // +

                case 3: Console.WriteLine(ConverterFromOctToBin(number)); break; // +-
                case 4: Console.WriteLine(ConverterFromOctToDec(number)); break; // +

                case 5: Console.WriteLine(ConverterFromDecToBin(number)); break; // +
                case 6: Console.WriteLine(ConverterFromDecToOct(number)); break; // +
            }
        }
        catch (OverflowException oe) // выход за диапазон int
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"ОШИБКА: ваш ввод вне диапазона! ({oe.Message})\n"); Console.ResetColor();
            Exercise1();
        }
        catch (FormatException ae) // ввод не int
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"ОШИБКА: ваш ввод не является числом! ({ae.Message})\n"); Console.ResetColor();
            Exercise1();
        }
        catch (Exception e) // иные исключения
        {
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"ОШИБКА: {e.Message}\n"); Console.ResetColor();
            Exercise1();
        }
    }







    /*
     * Задание 2
    Пользователь вводит словами цифру от 0 до 9. Приложение должно перевести слово в цифру. 
    Например, если пользователь ввёл five, приложение должно вывести на экран 5. 
    */
    static void Exercise2()
    {
        string input;
        try
        {
            Console.Write("Введите число от zero до nine: ");
            input = Console.ReadLine();

            if (input == "")
            {
                throw new ArgumentNullException(nameof(input), "ОШИБКА: вы ничего не ввели!");
            }

            input = input.ToLower(); // преобразует все символы в строке к нижнему регистру 
            input = input.Trim(' '); // убирает все пробелы в начале и в конце строки

            switch (input)
            {
                case "zero": Console.WriteLine("Ваше число: 0"); break;
                case "one": Console.WriteLine("Ваше число: 1"); break;
                case "two": Console.WriteLine("Ваше число: 2"); break;
                case "three": Console.WriteLine("Ваше число: 3"); break;
                case "four": Console.WriteLine("Ваше число: 4"); break;
                case "five": Console.WriteLine("Ваше число: 5"); break;
                case "six": Console.WriteLine("Ваше число: 6"); break;
                case "seven": Console.WriteLine("Ваше число: 7"); break;
                case "eight": Console.WriteLine("Ваше число: 8"); break;
                case "nine": Console.WriteLine("Ваше число: 9"); break;
                default: throw new Exception("ОШИБКА: вы ввели неподходящее число!");
            }
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine(ane.Message + "\n");
            Exercise2();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + "\n");
            Exercise2();
        }
    }







    /*
     * Задание 3
    Создайте класс «Заграничный паспорт». 
    Вам необходимо хранить информацию о номере паспорта, ФИО владельца, дате выдачи и т.д. 
    Предусмотреть механизмы для инициализации полей класса. 
    Если значение для инициализации неверное, генерируйте исключение. 
    */
    public class ForeignPassport
    {
        private ushort ID;
        private string FIO;
        private DateOnly dateOfIssue;


        public ForeignPassport() : this(0, "non", DateOnly.MinValue) { }

        public ForeignPassport(ushort ID, string FIO, DateOnly dateOfIssue)
        {
            this.ID = ID;
            this.FIO = FIO;
            this.dateOfIssue = dateOfIssue;
        }


        public void EnterID()
        {
            ushort input;

            while (true)
            {
                try
                {
                    Console.Write("Введите номер паспорта (4 цифры): ");
                    input = Convert.ToUInt16(Console.ReadLine());

                    if (input < 1000 || input > 9999)
                    {
                        throw new OverflowException($"{input} не четырёхзначное число");
                    }

                    this.ID = input;

                    break;
                }

                catch (FormatException fe)
                {
                    Console.WriteLine($"ОШИБКА: вы ввели не число!\n");
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine($"ОШИБКА: {oe.Message}\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ОШИБКА: {e.Message}\n");
                }
            }
        }

        public void EnterFIO()
        {
            string input;

            while (true)
            {
                try
                {
                    // ВВОД ФАМИЛИИ
                    Console.Write("Введите фамилию: ");
                    input = Console.ReadLine();
                    input = input.Trim(' '); // убираются пробелы в начале и в конце

                    if (Regex.IsMatch(input, @"[\p{P}\d\s]", RegexOptions.IgnoreCase)) // паттерн исключает цифры, всякие символы и пробелы 
                                                                                    // можно было умнее паттерн составить, чтобы сразу вводить полное ФИО,
                                                                                    // но я эту домашку уже миллиард часов делаю, поэтому час попытался разобраться с Regex, не смог
                    {
                        throw new FormatException($"{input} не может быть фамилией");
                    }

                    this.FIO = input + " ";


                    // ВВОД ИМЕНИ
                    Console.Write("Введите имя: ");
                    input = Console.ReadLine();
                    input = input.Trim(' '); // убираются пробелы в начале и в конце

                    if (Regex.IsMatch(input, @"[\p{P}\d\s]", RegexOptions.IgnoreCase))
                    {
                        throw new FormatException($"{input} не может быть именем");
                    }

                    this.FIO += input + " ";


                    // ВВОД ОТЧЕСТВА
                    Console.Write("Введите отчество: ");
                    input = Console.ReadLine();
                    input = input.Trim(' '); // убираются пробелы в начале и в конце

                    if (Regex.IsMatch(input, @"[\p{P}\d\s]", RegexOptions.IgnoreCase))
                    {
                        throw new FormatException($"{input} не может быть отчеством");
                    }

                    this.FIO += input + " ";

                    break;
                }

                catch (FormatException fe)
                {
                    Console.WriteLine($"ОШИБКА: вы ввели не фамилию! ({fe.Message})\n");
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine($"ОШИБКА: вы ввели не четырёхзначное число! ({oe.Message})\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ОШИБКА: что-то сломалось! ({e.Message})\n");
                }
            }
        }

        public void EnterDateOfIssue()
        {
            int input;

            while (true)
            {
                try
                {
                    // ВВОД ГОДА
                    Console.Write("Введите год: ");
                    int.TryParse(Console.ReadLine(), out input);

                    if (input < 1900 || input > 2023)
                    {
                        throw new OverflowException($"{input} не может быть годом");
                    }

                    this.dateOfIssue.AddYears(1000);
                    Console.WriteLine($"Year {dateOfIssue.Year}");


                    // ВВОД МЕСЯЦА
                    Console.Write("Введите месяц: ");
                    int.TryParse(Console.ReadLine(), out input);

                    if (input < 1 || input > 12)
                    {
                        throw new OverflowException($"{input} не может быть месяцем");
                    }

                    this.dateOfIssue.AddMonths(input);
                    Console.WriteLine($"MONTH {dateOfIssue.Month}");


                    // ВВОД ДНЯ
                    Console.Write("Введите день: ");
                    int.TryParse(Console.ReadLine(), out input);

                    if (input < 1 || input > 31)
                    {
                        throw new OverflowException($"{input} не может быть днём");
                    }

                    this.dateOfIssue.AddDays(input);
                    Console.WriteLine($"Day {dateOfIssue.Day}");

                    break;
                }

                catch (FormatException fe)
                {
                    Console.WriteLine($"ОШИБКА: {fe.Message}\n");
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine($"ОШИБКА: {oe.Message}\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ОШИБКА: {e.Message}\n");
                }
            }
        }



        public override string ToString()
        {
            return  $"ID: {this.ID}\n" +
                    $"FIO: {this.FIO}\n" +
                    $"Date of Issue: {this.dateOfIssue}\n";
        }
    }






    /*
     * Задание 4
    Пользователь вводит в строку с клавиатуры логическое выражение. Например, 3>2 или 7<3. 
    Программа должна посчитать результат введенного выражения и дать результат true или false. 
    В строке могут быть только целые числа и операторы: <, >, <=, >=, ==, !=. 
    Для обработки ошибок ввода используйте механизм исключений.
     */

    static void Exercise4()
    {

    }




    static void Main()
    {
        //Exercise1(); // работает, но неправильно сделано
        //Exercise2(); // +


        ForeignPassport foreignPassport = new ForeignPassport();
        Console.WriteLine($"ИСХОДНЫЙ ПАСПОРТ: \n{foreignPassport}");


        //foreignPassport.EnterID(); Console.WriteLine();
        //foreignPassport.EnterFIO(); Console.WriteLine();
        foreignPassport.EnterDateOfIssue(); Console.WriteLine();

        Console.WriteLine($"ИЗМЕНЁННЫЙ ПАСПОРТ: \n{foreignPassport}");




        //Exercise4(); //
    }
}