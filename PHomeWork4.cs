namespace CacheApp
{
    public sealed class CacheService
    {
        private readonly Dictionary<string, object> _cache = new();

        private static readonly Lazy<CacheService> _instance =
            new Lazy<CacheService>(() => new CacheService());

        public static CacheService Instance => _instance.Value;

        private CacheService()
        {
            Console.WriteLine("(Экземпляр CacheService создан)");
        }

        public void Add(string key, object value)
        {
            _cache[key] = value;
            Console.WriteLine($"Данные '{key}' добавлены.");
        }

        public object? Get(string key)
        {
            return _cache.TryGetValue(key, out var value) ? value : null;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Демонстрация работы глобального кэша (Singleton) ---");
            CacheService cache1 = CacheService.Instance;
            Console.WriteLine("Добавляем данные в кэш через первую ссылку...");
            cache1.Add("ConnectionString", "Server=.;Database=CacheDB;");
            cache1.Add("ApiKey", "XYZ12345ABC");
            CacheService cache2 = CacheService.Instance;
            Console.WriteLine("Получаем данные из кэша через ВТОРУЮ ссылку...");
            Console.WriteLine($"Значение по ключу 'ConnectionString': {cache2.Get("ConnectionString")}");
            Console.WriteLine($"Значение по ключу 'ApiKey': {cache2.Get("ApiKey")}");
            Console.WriteLine("Проверяем, что обе переменные ссылаются на один объект...");
            bool areEqual = object.ReferenceEquals(cache1, cache2);
            Console.WriteLine($"Результат: {areEqual}");
        }
    }
}