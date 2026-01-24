public abstract class Document
{
    public string Author { get; set; }

    public Document(string author)
    {
        Author = author;
    }

    public abstract void Render();
}

public class TextDocument : Document
{
    public string Content { get; set; }

    public TextDocument(string author, string content) : base(author)
    {
        Content = content;
    }

    public override void Render()
    {
        Console.WriteLine("--------------------");
        Console.WriteLine($"[Текст] Автор: {Author}");
        Console.WriteLine($"Содержимое: {Content}");
    }
}

public class ImageDocument : Document
{
    public string Resolution { get; set; }

    public ImageDocument(string author, string resolution) : base(author)
    {
        Resolution = resolution;
    }

    public override void Render()
    {
        Console.WriteLine("--------------------");
        Console.WriteLine($"[Изображение] Автор: {Author}");
        Console.WriteLine($"Рендеринг изображения с разрешением {Resolution}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Рендеринг документов ---");
        Console.WriteLine("Начинаю рендеринг...");

        List<Document> docs = new List<Document>
        {
            new TextDocument("Лев Толстой", "Все счастливые семьи похожи друг на друга..."),
            new ImageDocument("Иван Шишкин", "3558x2180"),
            new TextDocument("Михаил Булгаков", "В белом плаще с кровавым подбоем...")
        };

        foreach (var doc in docs)
        {
            doc.Render();
        }

        Console.WriteLine("--------------------");
    }
}