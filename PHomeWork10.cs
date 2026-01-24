class Program
{
    static void Main()
    {
        string input = " иванов иван,петров петр, сидорова Анна, бобров БОРИС ";

        Console.WriteLine("--- Форматирование списка пользователей ---");
        Console.WriteLine($"Исходная строка: \"{input}\"");

        var formattedUsers = input
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(rawName => rawName.Trim())
            .Select(CleanAndFormat)
            .ToList();

        Console.WriteLine("\nОтформатированный список:");
        for (int i = 0; i < formattedUsers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {formattedUsers[i]}");
        }
    }

    static string CleanAndFormat(string rawName)
    {

        var parts = rawName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var formattedParts = parts.Select(p =>
            char.ToUpper(p[0]) + p.Substring(1).ToLower()
        );

        return string.Join(" ", formattedParts);
    }
}