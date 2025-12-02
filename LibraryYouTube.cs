using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        YouTube myLibraryYouTube = new YouTube();

        while (true)
        {
            ShowMenu();
            Console.Write("Выберите действие: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    HandleAddVideo(myLibraryYouTube);
                    break;
                case "2":
                    HandleRemoveVideo(myLibraryYouTube);
                    break;
                case "3":
                    HandleFindVideo(myLibraryYouTube);
                    break;
                case "4":
                    HandleShowAllVideos(myLibraryYouTube);
                    break;
                case "5":
                    Console.WriteLine("Слом программы...");
                    return;
                default:
                    Console.WriteLine("Error.");
                    break;
            }
        }
    }

    public static void ShowMenu()
    {
        Console.WriteLine("\n╔═════════════════════════════╗");
        Console.WriteLine("║Консольная библиотека YouTube║");
        Console.WriteLine("╠═════════════════════════════╣");
        Console.WriteLine("║1. Добавить видео            ║");
        Console.WriteLine("║2. Удалить видео             ║");
        Console.WriteLine("║3. Найти видео               ║");
        Console.WriteLine("║4. Показать все видео        ║");
        Console.WriteLine("║5. Выйти из этого ада        ║");
        Console.WriteLine("╚═════════════════════════════╝");
    }
    public static void HandleAddVideo(YouTube library)
    {
        Console.Write("Введите название видео: ");
        string? title = Console.ReadLine();
        Console.Write("Введите ютубера: ");
        string? author = Console.ReadLine();
        Console.Write("Введите год выхода видео (и оставьте пустым): ");
        int? year = null;
        try
        {
            string? yearInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(yearInput))
            {
                year = Convert.ToInt32(yearInput);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Error.");
        }

        library.AddVIdeo(title ?? "Без названия", author ?? "Неизвестен", year);
        Console.WriteLine("Видео успешно добавленно!");
    }

    public static void HandleRemoveVideo(YouTube youtubelibrary)
    {
        Console.Write("Введите ссылку на видео для удаления: ");
        try
        {
            int id = Convert.ToInt32(Console.ReadLine());
            bool removed = youtubelibrary.RemoveVideo(id);
            if (removed)
            {
                Console.WriteLine("Видео успешно удалено.");
            }
            else
            {
                Console.WriteLine("Видео с такой ссылкой не найдено.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Error.");
        }
    }

    public static void HandleFindVideo(YouTube youtube)
    {
        Console.WriteLine("\n╔═════════════════════════════╗");
        Console.WriteLine("║   Выберите способ поиска    ║");
        Console.WriteLine("╠═════════════════════════════╣");
        Console.WriteLine("║1. По названию               ║");
        Console.WriteLine("║2. По ютуберу                ║");
        Console.WriteLine("╚═════════════════════════════╝");
        Console.Write("Ваш выбор: ");
        string? choice = Console.ReadLine();
        Console.Write("Введите поисковый запрос: ");
        string? query = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(query))
        {
            Console.WriteLine("Error.");
            return;
        }

        List<Video> foundVideos;
        switch (choice)
        {
            case "1":
                foundVideos = youtube.FindVideosByTitle(query);
                break;
            case "2":
                foundVideos = youtube.FindVideossByYoutuber(query);
                break;
            default:
                Console.WriteLine("Error.");
                return;
        }

        Console.WriteLine("\n--- Результаты поиска ---");
        PrintVideos(foundVideos);
    }

    public static void HandleShowAllVideos(YouTube youtube)
    {
        Console.WriteLine("\n--- Все видео в библиотеке ютуб ---");
        var allVideos = youtube.FindAllVideos();
        PrintVideos(allVideos);
    }

    public static void PrintVideos(List<Video> videos)
    {
        if (!videos.Any())
        {
            Console.WriteLine("Видео не найдено.");
            return;
        }
        foreach (var video in videos)
        {
            Console.WriteLine($"ID: {video.Id}, Название: {video.Title}, Ютубер: {video.Youtuber}, Год: {video.Year?.ToString() ?? "N/A"}");
        }
    }
}

public class YouTube
{
    private List<Video> _videos;
    private int _nextId;

    public YouTube()
    {
        _videos = new List<Video>();
        _nextId = 1;
    }

    public void AddVIdeo(string title, string youtuber, int? year)
    {
        var video = new Video { Id = _nextId++, Title = title, Youtuber = youtuber, Year = year };
        _videos.Add(video);

    }

    public bool RemoveVideo(int id)
    {
        var videoToRemove = _videos.FirstOrDefault(b => b.Id == id);
        if (videoToRemove != null)
        {
            _videos.Remove(videoToRemove);

            return true;
        }
        return false;
    }

    public List<Video> FindAllVideos() => _videos;
    public List<Video> FindVideosByTitle(string query) =>
        _videos.Where(b => b.Title != null && b.Title.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    public List<Video> FindVideossByYoutuber(string query) =>
        _videos.Where(b => b.Youtuber != null && b.Youtuber.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
}

public class Video
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Youtuber { get; set; }
    public int? Year { get; set; }
}