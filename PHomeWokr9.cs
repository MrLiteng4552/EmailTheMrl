namespace DataProcessingApp
{

    public abstract class DataProcessor
    {
        protected int RecordCount;
        public void Process()
        {
            ReadData();
            ParseData();
            AnalyzeData();
            SaveReport();
        }
        protected abstract void ReadData();
        protected abstract void ParseData();
        protected virtual void AnalyzeData()
        {
            Console.WriteLine($"[Анализ]: Анализ данных... Найдено {RecordCount} записей.");
        }

        protected virtual void SaveReport()
        {
            Console.WriteLine($"[Сохранение]: Отчет сохранен в консоль. Результат: {RecordCount} записей обработано.");
        }
    }
    public class CsvDataProcessor : DataProcessor
    {
        protected override void ReadData()
        {
            Console.WriteLine("[Чтение]: Чтение сырых данных из CSV...");
        }

        protected override void ParseData()
        {
            Console.WriteLine("[Парсинг]: Парсинг CSV данных...");
            RecordCount = 2;
        }
    }
    public class XmlDataProcessor : DataProcessor
    {
        protected override void ReadData()
        {
            Console.WriteLine("[Чтение]: Чтение сырых данных из XML...");
        }

        protected override void ParseData()
        {
            Console.WriteLine("[Парсинг]: Парсинг XML данных...");
            RecordCount = 3;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Запуск обработчика CSV данных ---");
            DataProcessor csvProcessor = new CsvDataProcessor();
            csvProcessor.Process();
            Console.WriteLine();
            Console.WriteLine("--- Запуск обработчика XML данных ---");
            DataProcessor xmlProcessor = new XmlDataProcessor();
            xmlProcessor.Process();
        }
    }
}