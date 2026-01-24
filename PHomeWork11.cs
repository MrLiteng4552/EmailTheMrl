namespace NotificationSystem
{
    public interface IMessageSender
    {
        void Send(string message);
    }
    public class EmailSender : IMessageSender
    {
        public void Send(string message) =>
            Console.WriteLine($"Отправка по Email: {message}");
    }

    public class SmsSender : IMessageSender
    {
        public void Send(string message) =>
            Console.WriteLine($"Отправка по SMS: {message}");
    }
    public abstract class NotificationServiceFactory
    {
        public abstract IMessageSender CreateSender();
        public void SendNotification(string message)
        {
            IMessageSender sender = CreateSender();
            sender.Send(message);
        }
    }
    public class EmailNotificationFactory : NotificationServiceFactory
    {
        public override IMessageSender CreateSender() => new EmailSender();
    }

    public class SmsNotificationFactory : NotificationServiceFactory
    {
        public override IMessageSender CreateSender() => new SmsSender();
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Гибкая система уведомлений ---");
            Console.Write("Какой тип уведомлений использовать? (email/sms): ");
            string type = Console.ReadLine()?.ToLower();

            NotificationServiceFactory factory = null;
            if (type == "email")
            {
                factory = new EmailNotificationFactory();
                Console.WriteLine("Создана фабрика для Email.");
            }
            else if (type == "sms")
            {
                factory = new SmsNotificationFactory();
                Console.WriteLine("Создана фабрика для SMS.");
            }
            else
            {
                Console.WriteLine("Неизвестный тип уведомлений.");
                return;
            }
            Console.WriteLine("Отправляем уведомление...");
            factory.SendNotification("Ваш заказ #123 успешно оформлен.");
        }
    }
}