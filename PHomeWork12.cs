class Program
{
    static void Main()
    {
        Console.WriteLine("--- Универсальный калькулятор ---");

        Console.WriteLine("Введите первое число:");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите второе число:");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n--- Результаты вычислений ---");

        double sum = Execute(num1, num2, (a, b) => a + b);
        double subtract = Execute(num1, num2, (a, b) => a - b);
        double multiply = Execute(num1, num2, (a, b) => a * b);
        double divide = Execute(num1, num2, (a, b) => b != 0 ? a / b : 0);

        Console.WriteLine($"Сложение: {sum}");
        Console.WriteLine($"Вычитание: {subtract}");
        Console.WriteLine($"Умножение: {multiply}");
        Console.WriteLine($"Деление: {(num2 != 0 ? divide.ToString() : "Ошибка (деление на ноль)")}");
    }


    static double Execute(double x, double y, Func<double, double, double> operation)
    {
        return operation(x, y);
    }

}
