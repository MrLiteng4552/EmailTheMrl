public class Employee
{
    public string Name { get; set; }
    public decimal BaseSalary { get; set; }

    public Employee(string name, decimal baseSalary)
    {
        Name = name;
        BaseSalary = baseSalary;
    }

    public virtual decimal CalculateMonthlySalary()
    {
        return BaseSalary;
    }
}

public class Manager : Employee
{
    public decimal Bonus { get; set; }

    public Manager(string name, decimal baseSalary, decimal bonus)
        : base(name, baseSalary)
    {
        Bonus = bonus;
    }

    public override decimal CalculateMonthlySalary()
    {
        return BaseSalary + Bonus;
    }
}

public class Developer : Employee
{
    public int LinesOfCodeWritten { get; set; }

    private const decimal PayPerLine = 0.5m;

    public Developer(string name, decimal baseSalary, int linesOfCode)
        : base(name, baseSalary)
    {
        LinesOfCodeWritten = linesOfCode;
    }

    public override decimal CalculateMonthlySalary()
    {
        return BaseSalary + (LinesOfCodeWritten * PayPerLine);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Расчет заработной платы ---");
        List<Employee> employees = new List<Employee>
        {
            new Manager("Иван Петров", 80000, 25000),
            new Developer("Анна Сидорова", 70000, 50500),
            new Manager("Олег Васильев", 90000, 40000)
        };

        foreach (var emp in employees)
        {
            string position = emp is Manager ? "Менеджер" : "Разработчик";

            Console.WriteLine($"Зарплата для {position} {emp.Name}: {emp.CalculateMonthlySalary():F0}");
        }
    }
}