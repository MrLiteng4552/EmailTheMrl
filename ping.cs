using System.Text;
using System.Diagnostics;
public class Programm
{   
    public static void Main()
    {
        const int iterations = 50000;
        Console.WriteLine($"Идет подсчет пинга... {iterations}");
        Stopwatch swString = new Stopwatch();
        swString.Start();

        string resultString = "";

        for (int i = 0; i < iterations; i++)
        {
            resultString += "a";
        }
        swString.Stop();
        Console.WriteLine($"Ваш пинг: {swString.ElapsedMilliseconds} мс");
        Console.WriteLine($"Длина итоговой строки: {resultString.Length}");

        Console.WriteLine($"\nНачинаем тест пинга {iterations}...");
        Stopwatch swBuilder = new Stopwatch();
        swBuilder.Start();

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < iterations; i++)
        {
            sb.Append("a");
        }
        string resultBuilder = sb.ToString();

        swBuilder.Stop();
        Console.WriteLine($"Ваш пинг: {swBuilder.ElapsedMilliseconds} мс");
        Console.WriteLine($"Длина итоговой строки: {resultBuilder.Length}");
    }
}