public record Student(string Name, int Age, double AverageGrade);

class Program
{
    static void Main()
    {

        var students = new List<Student>
        {
            new Student("Петров Иван", 20, 85.5),
            new Student("Сидорова Анна", 23, 78.1),
            new Student("Кузнецов Олег", 19, 74.9),
            new Student("Васильева Мария", 26, 82.0),
            new Student("Смирнов Алексей", 22, 95.2)
        };

        Console.WriteLine("--- Список студентов-хорошистов (балл от 75 до 90) ---");
        var goodStudents = students.Where(s => s.AverageGrade >= 75 && s.AverageGrade <= 90);
        foreach (var s in goodStudents)
            Console.WriteLine($"{s.Name} - {s.AverageGrade}");

        Console.WriteLine("\n--- Все студенты ---");
        List<string> namesOnly = students.Select(s => s.Name).ToList();
        namesOnly.ForEach(Console.WriteLine);

        Console.WriteLine("\n--- Сортировка по возрасту ---");
        var sortedByAge = students.OrderBy(s => s.Age);
        foreach (var s in sortedByAge)
            Console.WriteLine($"{s.Name} - {s.Age} лет");

        Console.WriteLine("\n--- Рейтинг студентов младше 25 лет (по убыванию балла) ---");
        var rating = students
            .Where(s => s.Age < 25)
            .OrderByDescending(s => s.AverageGrade)
            .Select(s => $"{s.Name} - {s.AverageGrade}");

        foreach (var entry in rating)
            Console.WriteLine(entry);
    }
}