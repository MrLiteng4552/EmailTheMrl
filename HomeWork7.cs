public class Rectangle
{
    public double width;
    public double height;
    public double GetArea()
    {
        return width * height;
    }
    public double GetPerimeter()
    {
        return 2 * (width + height);
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Rectangle rectangle1 = new Rectangle();
        rectangle1.width = 324325.0;
        rectangle1.height = 15450.0;
        double area1 = rectangle1.GetArea();
        double perimeter1 = rectangle1.GetPerimeter();
        Console.WriteLine("Прямоугольник 19:");
        Console.WriteLine($"Ширина: {rectangle1.width}");
        Console.WriteLine($"Высота: {rectangle1.height}");
        Console.WriteLine($"Площадь: {area1}");
        Console.WriteLine($"Периметр: {perimeter1}");
        Console.WriteLine();
        Rectangle rectangle2 = new Rectangle();
        rectangle2.width = 72342.5243;
        rectangle2.height = 3342.278;
        double area2 = rectangle2.GetArea();
        double perimeter2 = rectangle2.GetPerimeter();
        Console.WriteLine("Прямоугольник 29:");
        Console.WriteLine($"Ширина: {rectangle2.width}");
        Console.WriteLine($"Высота: {rectangle2.height}");
        Console.WriteLine($"Площадь: {area2}");
        Console.WriteLine($"Периметр: {perimeter2}");
    }
}
