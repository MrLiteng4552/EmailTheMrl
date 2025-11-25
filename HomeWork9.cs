

    public struct Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public override string ToString()
        {
            return $"\"{Title}\" (Автор: {Author})";
        }
    }

    public class Student
    {
        private static int studentCount = 0;

        public static int StudentCount
        {
            get { return studentCount; }
        }

        public string Name { get; set; }
        public Book FavoriteBook { get; set; }

        public Student(string name, Book favoriteBook)
        {
            Name = name;
            FavoriteBook = favoriteBook;
            studentCount++;
        }

        public override string ToString()
        {
            return $"Студент: {Name}, Любимый видеоролик: {FavoriteBook}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Начало работы системы ---");
 
            Console.WriteLine($"Начальное количество ютуберов в системе: {Student.StudentCount}\n");

            var book1 = new Book("ПОТОП НА СЕРВЕРЕ | PepeLand 6 Серия 5,", "PWGood");
            var student1 = new Student("Польлзователь 1", book1);
            Console.WriteLine($"Создан ютубер: {student1.Name}. Всего ютуберов: {Student.StudentCount}");

            var book2 = new Book("Тарас Бульба", "Николай Гоголь");
            var student2 = new Student("Пользователь 2", book2);
            Console.WriteLine($"Создан студент: {student2.Name}. Всего ютуберов: {Student.StudentCount}\n");

            Console.WriteLine("--- Эксперимент с блокировкой ютуба ---");

            Student studentCopy = student1;
            Console.WriteLine($"Оригинал (до изменений): {student1}");
            Console.WriteLine($"Копия (до изменений):   {studentCopy}\n");

            Book bookCopy = student1.FavoriteBook;

            studentCopy.Name = "Пользователь 1  (Измененный)";
            bookCopy.Title = "";

            Console.WriteLine("--- Результаты эксперимента ---");

            Console.WriteLine($"Оригинал (после изменений): {student1}");
            Console.WriteLine($"Копия (после изменений):   {studentCopy}");
            Console.WriteLine($"Копия книги (отдельно):    {bookCopy}\n");

            Console.WriteLine("Объяснение:");
            Console.WriteLine("Обойдетесь без обьяснения.");

            Console.WriteLine("\n--- Завершение работы РКН... ---");
        }
    }
//я пояснения не удалял т.к их тут и не было...





























































//CONGREGATION