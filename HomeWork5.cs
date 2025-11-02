class FactorialCalculator
{
    static void Main()
    {
        Console.WriteLine("--- Калькулятор факториала ---");
        Console.Write("Введите число: ");

        if (int.TryParse(Console.ReadLine(), out int n))
        {
            if (n >= 0)
            {
                int factorial = CalculateFactorial(n);
                Console.WriteLine($"Факториал числа {n} равен {factorial}");
            }
            else
            {
                Console.WriteLine($"Ошибка: введите положительное число.");
            }
        }
        else
        {
            Console.WriteLine("Ошибка: введите целое число.");
        }
    }

    static int CalculateFactorial(int n)
    {
        int result = 1;

        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }
}
