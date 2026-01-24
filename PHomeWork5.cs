public interface ITextPlugin
{
    string Process(string input);
}

public class ToUpperPlugin : ITextPlugin
{
    public string Process(string input) => input.ToUpper();
}

public class SpaceRemoverPlugin : ITextPlugin
{
    public string Process(string input) => input.Replace(" ", "");
}

public class ReversePlugin : ITextPlugin
{
    public string Process(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

public class TextProcessor
{
    public string ExecutePipeline(string input, List<ITextPlugin> plugins)
    {
        string result = input;
        foreach (var plugin in plugins)
        {
            result = plugin.Process(result);
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Система обработки текста на плагинах ---");

        string originalText = "Hello World! This is a test.";
        Console.WriteLine($"Исходная строка: {originalText}");

        var pipeline = new List<ITextPlugin>
        {
            new ToUpperPlugin(),
            new SpaceRemoverPlugin(),
            new ReversePlugin()
        };

        Console.WriteLine("Примененные плагины:");
        foreach (var plugin in pipeline)
        {
            Console.WriteLine($" - {plugin.GetType().Name}");
        }

        TextProcessor processor = new TextProcessor();
        string finalResult = processor.ExecutePipeline(originalText, pipeline);

        Console.WriteLine($"Результат после обработки: {finalResult}");
    }
}