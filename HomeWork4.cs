class Program
{
    static void Main()
    {
        do
        {
            Random random = new Random();
            int secretNumber = random.Next(1, 101);
            int maxAttempts = 7;
            bool guessedCorrectly = false;

            Console.WriteLine($"Я загадал число от 1 до 100. У тебя есть ровно {maxAttempts} попыток.");

            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                Console.Write($"Попытка {attempt} из {maxAttempts}. Введите свое число: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int userGuess))
                {
                    Console.WriteLine("Ошибка ввода числа (ValueError).");
                    attempt--;
                    continue;
                }

                if (userGuess == secretNumber)
                {
                    Console.WriteLine($"Ты угадал число {secretNumber} за {attempt} попыток!");
                    Console.WriteLine("Ты не молодец.");
                    guessedCorrectly = true;
                    break;
                }
                else if (userGuess < secretNumber)
                {
                    Console.WriteLine("Число больше.");
                }
                else
                {
                    Console.WriteLine("Число меньше.");
                }
            }

            if (!guessedCorrectly)
            {
                Console.WriteLine($"Ты проиграл.");
                Console.WriteLine($"Число было: {secretNumber}");
            }

            Console.Write("Введи 'да' чторбы играть снова: ");
            string playAgainResponse = Console.ReadLine();

            if (playAgainResponse != "да")
            {
                Console.WriteLine("Нажмите Enter для завершения...");
                Console.ReadLine();
                break;
            }
        } while (true);
    }
}
//я хз как это работает но ничего не трогать