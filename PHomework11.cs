namespace TaskManager
{

    public class TaskItem
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public TaskItem(string description)
        {
            Description = description;
            IsDone = false;
        }

        public override string ToString()
        {
            string statusIcon = IsDone ? "[X]" : "[ ]";
            return $"{statusIcon} {Description}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<TaskItem> tasks = new List<TaskItem>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Менеджер задач ---");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Посмотреть задачи");
                Console.WriteLine("3. Отметить задачу как выполненную");
                Console.WriteLine("4. Выйти");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите описание задачи: ");
                        string desc = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(desc))
                        {
                            tasks.Add(new TaskItem(desc));
                            Console.WriteLine("Задача добавлена!");
                        }
                        break;

                    case "2":
                        ShowTasks(tasks);
                        break;

                    case "3":
                        MarkTaskDone(tasks);
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Программа завершена.");
                        break;

                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова.");
                        break;
                }
            }
        }

        static void ShowTasks(List<TaskItem> tasks)
        {
            Console.WriteLine("\n--- Текущие задачи ---");
            if (tasks.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        static void MarkTaskDone(List<TaskItem> tasks)
        {
            ShowTasks(tasks);
            if (tasks.Count == 0) return;

            Console.Write("\nВведите номер задачи для выполнения: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks[taskNumber - 1].IsDone = true;
                Console.WriteLine($"Задача \"{tasks[taskNumber - 1].Description}\" отмечена как выполненная!");
            }
            else
            {
                Console.WriteLine("Некорректный номер задачи.");
            }
        }
    }
}