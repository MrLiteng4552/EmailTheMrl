using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        Library myLibrary = new Library();

        while (true)
        {
            ShowMenu();
            Console.Write("Выберите действие: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    HandleAddBook(myLibrary);
                    break;
                case "2":
                    HandleRemoveBook(myLibrary);
                    break;
                case "3":
                    HandleFindBook(myLibrary);
                    break;
                case "4":
                    HandleShowAllBooks(myLibrary);
                    break;
                case "5":
                    Console.WriteLine("Выход из программы...");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, введите число от 1 до 5.");
                    break;
            }
        }
    }

    public static void ShowMenu()
    {
        Console.WriteLine("\n--- Консольная библиотека ---");
        Console.WriteLine("1. Добавить книгу");
        Console.WriteLine("2. Удалить книгу");
        Console.WriteLine("3. Найти книгу");
        Console.WriteLine("4. Показать все книги");
    }
    public static void HandleAddBook(Library library)
    {
        Console.Write("Введите название: ");
        string? title = Console.ReadLine();
        Console.Write("Введите автора: ");
        string? author = Console.ReadLine();
        Console.Write("Введите год издания (или оставьте пустым): ");
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
            Console.WriteLine("Неверный формат года. Год не будет сохранен.");
        }

        library.AddBook(title ?? "Без названия", author ?? "Неизвестен", year);
        Console.WriteLine("Книга успешно добавлена!");
    }

    public static void HandleRemoveBook(Library library)
    {
        Console.Write("Введите ID книги для удаления: ");
        try
        {
            int id = Convert.ToInt32(Console.ReadLine());
            bool removed = library.RemoveBook(id);
            if (removed)
            {
                Console.WriteLine("Книга успешно удалена.");
            }
            else
            {
                Console.WriteLine("Книга с таким ID не найдена.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: ID должен быть числом.");
        }
    }

    public static void HandleFindBook(Library library)
    {
        Console.WriteLine("Выберите критерий поиска:");
        Console.WriteLine("1. По названию");
        Console.WriteLine("2. По автору");
        Console.Write("Ваш выбор: ");
        string? choice = Console.ReadLine();
        Console.Write("Введите поисковый запрос: ");
        string? query = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(query))
        {
            Console.WriteLine("Поисковый запрос не может быть пустым.");
            return;
        }

        List<Book> foundBooks;
        switch (choice)
        {
            case "1":
                foundBooks = library.FindBooksByTitle(query);
                break;
            case "2":
                foundBooks = library.FindBooksByAuthor(query);
                break;
            default:
                Console.WriteLine("Неверный критерий поиска.");
                return;
        }

        Console.WriteLine("\n--- Результаты поиска ---");
        PrintBooks(foundBooks);
    }

    public static void HandleShowAllBooks(Library library)
    {
        Console.WriteLine("\n--- Все книги в библиотеке ---");
        var allBooks = library.FindAllBooks();
        PrintBooks(allBooks);
    }

    public static void PrintBooks(List<Book> books)
    {
        if (!books.Any())
        {
            Console.WriteLine("Книг не найдено.");
            return;
        }
        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.Id}, Название: {book.Title}, Автор: {book.Author}, Год: {book.Year?.ToString() ?? "N/A"}");
        }
    }
}

public class Library
{
    private List<Book> _books;
    private int _nextId;

    public Library()
    {
        _books = new List<Book>();
        _nextId = 1;
    }

    public void AddBook(string title, string author, int? year)
    {
        var book = new Book { Id = _nextId++, Title = title, Author = author, Year = year };
        _books.Add(book);

    }

    public bool RemoveBook(int id)
    {
        var bookToRemove = _books.FirstOrDefault(b => b.Id == id);
        if (bookToRemove != null)
        {
            _books.Remove(bookToRemove);

            return true;
        }
        return false;
    }

    public List<Book> FindAllBooks() => _books;
    public List<Book> FindBooksByTitle(string query) =>
        _books.Where(b => b.Title != null && b.Title.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    public List<Book> FindBooksByAuthor(string query) =>
        _books.Where(b => b.Author != null && b.Author.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
}

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int? Year { get; set; }
}