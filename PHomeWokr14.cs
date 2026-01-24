namespace AdapterPatternDemo
{
    public interface ILogger
    {
        void Log(string message);
    }
    public class OldLogger
    {
        public void LogMessage(string message, DateTime date)
        {
            Console.WriteLine($"[OldLogger]: {date:dd.MM.yyyy HH:mm:ss} - {message}");
        }
    }
    public class LoggerAdapter : ILogger
    {
        private readonly OldLogger _oldLogger;

        public LoggerAdapter(OldLogger oldLogger)
        {
            _oldLogger = oldLogger;
        }

        public void Log(string message)
        {
            DateTime currentDateTime = DateTime.Now;
            _oldLogger.LogMessage(message, currentDateTime);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Демонстрация работы Адаптера ---");
            OldLogger oldLibraryLogger = new OldLogger();
            ILogger modernLogger = new LoggerAdapter(oldLibraryLogger);
            Console.WriteLine("Вызов логгера через адаптер...");
            modernLogger.Log("Это тестовое сообщение для лога");
        }
    }
}