public record Product(int Id, string Name, decimal Price);

public class Inventory
{
    private readonly List<Product> _products = new List<Product>();
    public void AddProduct(Product product)
    {
        _products.Add(product);
        Console.WriteLine($"Добавлен товар: {product}");
    }
    public Product? FindById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Управление инвентарем ---");

        Inventory inventory = new Inventory();
        inventory.AddProduct(new Product(1, "Молоко", 80.50m));
        inventory.AddProduct(new Product(2, "Хлеб", 40.00m));
        inventory.AddProduct(new Product(3, "Сыр", 450.99m));
        int searchId1 = 2;
        Console.WriteLine($"--- Поиск товара с ID {searchId1} ---");
        var foundProduct = inventory.FindById(searchId1);
        if (foundProduct != null)
            Console.WriteLine($"Найден товар: {foundProduct}");
        else
            Console.WriteLine($"Товар с ID {searchId1} не найден.");
        int searchId2 = 99;
        Console.WriteLine($"--- Поиск товара с ID {searchId2} ---");
        var missingProduct = inventory.FindById(searchId2);
        if (missingProduct != null)
            Console.WriteLine($"Найден товар: {missingProduct}");
        else
            Console.WriteLine($"Товар с ID {searchId2} не найден.");
    }
}