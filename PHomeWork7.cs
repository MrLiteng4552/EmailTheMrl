public class OrderValidator
{
    public bool Validate(string itemName, int quantity)
    {
        if (string.IsNullOrEmpty(itemName))
        {
            Console.WriteLine("Ошибка: Название товара не может быть пустым.");
            return false;
        }
        if (quantity <= 0)
        {
            Console.WriteLine("Ошибка: Количество должно быть больше нуля.");
            return false;
        }
        Console.WriteLine("Заказ прошел валидацию.");
        return true;
    }
}
public class OrderRepository
{
    public void SaveToFile(string itemName, int quantity)
    {
        File.WriteAllText("order.txt", $"Товар: {itemName}, Количество: {quantity}");
        Console.WriteLine("Заказ сохранен в файл.");
    }
}

public class NotificationService
{
    public void SendEmail(string message)
    {
        Console.WriteLine($"Отправка email-уведомления: '{message}'.");
    }
}

public class OrderProcessor
{
    private readonly OrderValidator _validator;
    private readonly OrderRepository _repository;
    private readonly NotificationService _notification;

    public OrderProcessor()
    {
        _validator = new OrderValidator();
        _repository = new OrderRepository();
        _notification = new NotificationService();
    }

    public void ProcessOrder(string itemName, int quantity)
    {
        if (_validator.Validate(itemName, quantity))
        {
            _repository.SaveToFile(itemName, quantity);
            _notification.SendEmail("Ваш заказ принят");
        }
    }
}

class Program
{
    static void Main()
    {
        OrderProcessor processor = new OrderProcessor();
        Console.WriteLine("--- Обработка нового заказа ---");
        Console.Write("Введите название товара: ");
        string item1 = Console.ReadLine();
        Console.Write("Введите количество: ");
        int.TryParse(Console.ReadLine(), out int qty1);
        processor.ProcessOrder(item1, qty1);
        Console.WriteLine("\n--- Попытка обработки некорректного заказа ---");
        processor.ProcessOrder("", -5);
    }
}