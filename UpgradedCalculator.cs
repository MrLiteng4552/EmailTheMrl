class Program
{
    static void Main()
    {
        Console.WriteLine("--- Улучшенный калькулятор ---!");
        Console.WriteLine("Введите первое число:");
        string Inputnumber1 = Console.ReadLine();
        Console.WriteLine("Введите второе число:");
        string Inputnumber2 = Console.ReadLine();
        double doubleNumber1 = Convert.ToDouble(Inputnumber1);
        double doubleNumber2 = Convert.ToDouble(Inputnumber2);
        Console.WriteLine("Введите символ операции (+, -, *, /):");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "+":
                Console.WriteLine(add("Результат:", doubleNumber1, doubleNumber2));
                break;
            case "-":
                Console.WriteLine(munes("Результат:", doubleNumber1, doubleNumber2));
                break;
            case "*":
                Console.WriteLine(drivide("Результат:", doubleNumber1, doubleNumber2));
                break;
            case "/":
                Console.WriteLine(multiply("Результат:", doubleNumber1, doubleNumber2));
                break;
            default:
                Console.WriteLine("Ошибка!");
                break;

        }

        static double add(string message, double doubleNumber1, double doubleNumber2)
        {
            Console.WriteLine(message);
            return (doubleNumber1 + doubleNumber2);
        }
        static double munes(string message, double doubleNumber1, double doubleNumber2)
        {
            Console.WriteLine(message);
            return (doubleNumber1 - doubleNumber2);
        }
        static double multiply(string message, double doubleNumber1, double doubleNumber2)
        {
            Console.WriteLine(message);
            return (doubleNumber1 * doubleNumber2);
        }
        static double drivide(string message, double doubleNumber1, double doubleNumber2)
        {
            Console.WriteLine(message);
            return (doubleNumber1 / doubleNumber2);
        }
    }

}