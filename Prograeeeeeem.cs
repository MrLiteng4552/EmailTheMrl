using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("C# IDE-Console. [F5] - Запустить код | [#exit] - Выход");
ScriptState<object> state = null;

// Ключевые слова для подсветки
string[] keywords = { "int", "string", "var", "double", "if", "else", "foreach", "for", "while", "return", "true", "false", "void", "static", "class", "new", "Console", "WriteLine", "await" };

// НАСТРОЙКА "МАТРЕШКИ": Даем скрипту доступ к самому себе и компилятору
var options = ScriptOptions.Default
    .AddReferences(
        typeof(CSharpScript).Assembly,
        typeof(ScriptOptions).Assembly,
        typeof(Regex).Assembly,
        typeof(StringBuilder).Assembly)
    .WithImports("System", "System.Text", "System.Text.RegularExpressions", "Microsoft.CodeAnalysis.CSharp.Scripting", "Microsoft.CodeAnalysis.Scripting", "System.Threading.Tasks");

while (true)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write(">>> ");
    Console.ResetColor();

    // Передаем управление в наш кастомный ввод (теперь запуск по F5)
    string input = CustomReadLine(keywords);
    if (input.ToLower().Trim() == "#exit") break;
    if (string.IsNullOrWhiteSpace(input)) continue;

    try
    {
        // Используем наши расширенные options
        state = (state == null)
            ? await CSharpScript.RunAsync(input, options)
            : await state.ContinueWithAsync(input);

        if (state.ReturnValue != null)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n[Out]: {state.ReturnValue}");
            Console.ResetColor();
        }
        else Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n[Error]: {ex.Message}");
        Console.ResetColor();
    }
}

string CustomReadLine(string[] keywords)
{
    StringBuilder buffer = new StringBuilder();
    while (true)
    {
        var key = Console.ReadKey(true);

        // ЗАПУСК ПО F5 (так удобнее вставлять многострочный код)
        if (key.Key == ConsoleKey.F5) break;

        // ОБЫЧНЫЙ ВВОД
        if (key.Key == ConsoleKey.Enter)
        {
            buffer.AppendLine();
            Console.WriteLine();
            Console.Write("... ");
            continue;
        }

        if (key.Key == ConsoleKey.Backspace && buffer.Length > 0)
        {
            buffer.Remove(buffer.Length - 1, 1);
            Console.Write("\b \b");
        }
        else if (!char.IsControl(key.KeyChar))
        {
            buffer.Append(key.KeyChar);
        }

        RefreshLine(buffer.ToString(), keywords);
    }
    return buffer.ToString();
}

void RefreshLine(string text, string[] keywords)
{
    // Берем только последнюю строку для отрисовки
    string lastLine = text.Split('\n').Last();
    int currentLine = Console.CursorTop;
    int offset = text.Contains('\n') ? 4 : 4; // Отступ для >>> или ...

    Console.SetCursorPosition(offset, currentLine);
    Console.Write(new string(' ', Console.WindowWidth - offset - 1));
    Console.SetCursorPosition(offset, currentLine);

    string[] tokens = Regex.Split(lastLine, @"(\b\w+\b|[^\w\s])");
    foreach (var token in tokens)
    {
        if (keywords.Contains(token)) Console.ForegroundColor = ConsoleColor.Blue;
        else if (int.TryParse(token, out _)) Console.ForegroundColor = ConsoleColor.Magenta;
        else if (token.StartsWith("\"")) Console.ForegroundColor = ConsoleColor.DarkYellow;
        else Console.ForegroundColor = ConsoleColor.Gray;

        Console.Write(token);
    }
    Console.ResetColor();
}
