namespace SchoolManagement
{
    public class Student
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (value >= 6 && value <= 100)
                {
                    _age = value;
                }
                else
                {
                    Console.WriteLine("Ошибка: возраст должен быть в диапазоне от 6 до 100!");
                }
            }
        }

        public string FullName => $"{FirstName} {LastName}";

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Привет, меня зовут {FullName}, мне {Age} лет.");
            Console.WriteLine($"Полное имя: {FullName}");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Создание профилей студентов ---");

            Console.WriteLine("Студент 1:");
            Student s1 = new Student("Иван", "Петров", 19);
            s1.PrintInfo();

            Console.WriteLine("\nСтудент 2:");
            Student s2 = new Student("Анна", "Сидорова", 20);
            s2.PrintInfo();

            Console.WriteLine("\n--- Попытка изменить возраст на некорректное значение ---");
            s1.Age = 150;

            Console.WriteLine($"Текущий возраст студента 1: {s1.Age}");
        }
    }
}