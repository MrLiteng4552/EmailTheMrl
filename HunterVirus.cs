class CyberHunterPro
{
    static string rootPath = Path.Combine(Path.GetTempPath(), "Core_System_666");
    static List<string> virusFiles = new List<string>();
    static List<string> trapFiles = new List<string>();
    static int timeLeft = 180;
    static bool gameOver = false;
    static string currentDir = rootPath;
    static int selectedIndex = 0;
    static object lockObj = new object();

    static int scansLeft = 10;
    static DateTime lastScanTime = DateTime.MinValue;
    static string scanStatus = "ГОТОВ К РАБОТЕ";

    static void Main()
    {
        Console.Title = "C-666 ANTIVIRUS TERMINAL";
        Console.SetWindowSize(100, 30);
        Console.CursorVisible = false;

        ShowIntro();
        SetupGame();

        new Thread(() => {
            while (timeLeft > 0 && !gameOver)
            {
                RefreshHeader();
                Thread.Sleep(1000);
                timeLeft--;
            }
            if (!gameOver && timeLeft <= 0) EndGame(false);
        }).Start();

        while (!gameOver)
        {
            DrawFileList();
            HandleInput();
        }
    }

    static void ShowIntro()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("!!! ВНИМАНИЕ: ОБНАРУЖЕН ПРОТОКОЛ СМЕРТИ '6' !!!");
        Console.ResetColor();
        Console.WriteLine("\n[ УПРАВЛЕНИЕ ]");
        Console.WriteLine(" СТРЕЛКИ - Навигация по секторам");
        Console.WriteLine(" ENTER   - Войти в папку / BACKSPACE - Назад");
        Console.WriteLine(" INSERT  - СКАНИРОВАТЬ ФАЙЛ (10 использований, КД 10с)");
        Console.WriteLine(" DELETE  - УДАЛИТЬ ОБЪЕКТ");
        Console.WriteLine("\n[ РАЗВЕДДАННЫЕ ]");
        Console.WriteLine("- Вирусы и ЛОВУШКИ содержат в имени цифру '6'.");
        Console.WriteLine("- Удаление ловушки (с цифрой 6): -30 секунд + СБОЙ.");
        Console.WriteLine("- Удаление обычного файла: -15 секунд.");
        Console.WriteLine("\nНажмите любую клавишу для инициализации...");
        Console.ReadKey(true);
    }

    static void SetupGame()
    {
        if (Directory.Exists(rootPath)) Directory.Delete(rootPath, true);
        Directory.CreateDirectory(rootPath);
        Random rng = new Random();

        for (int i = 0; i < 8; i++)
        {
            string sub = Path.Combine(rootPath, $"Sector_0x{i}{rng.Next(10, 99)}");
            Directory.CreateDirectory(sub);
            for (int j = 0; j < 6; j++)
            {
                int type = rng.Next(100);
                string name;
                string p;

                if (type < 15 && virusFiles.Count < 5)
                {
                    name = $"v_core_6_{rng.Next(1000)}.sys";
                    p = Path.Combine(sub, name);
                    File.WriteAllText(p, "VIRUS_DATA");
                    virusFiles.Add(p);
                }
                else if (type < 45)
                {
                    name = $"trap_link_6_{rng.Next(1000)}.dll";
                    p = Path.Combine(sub, name);
                    File.WriteAllText(p, "TRAP_DATA");
                    trapFiles.Add(p);
                }
                else
                {
                    name = $"clean_log_{rng.Next(1000)}.bin";
                    p = Path.Combine(sub, name);
                    File.WriteAllText(p, "NORMAL_DATA");
                }
            }
        }
        while (virusFiles.Count < 5)
        {
            string p = Path.Combine(rootPath, $"emergency_6_{rng.Next(99)}.sys");
            File.WriteAllText(p, "VIRUS");
            virusFiles.Add(p);
        }
    }

    static void RefreshHeader()
    {
        lock (lockObj)
        {
            int oldX = Console.CursorLeft; int oldY = Console.CursorTop;
            Console.SetCursorPosition(0, 0);

            Console.ForegroundColor = timeLeft < 30 ? ConsoleColor.Red : ConsoleColor.Yellow;
            Console.Write($"[ ТАЙМЕР: {timeLeft}s ] | [ ВИРУСОВ: {virusFiles.Count}/5 ]".PadRight(Console.WindowWidth));

            Console.SetCursorPosition(0, 1);
            TimeSpan elapsed = DateTime.Now - lastScanTime;
            bool onCooldown = elapsed < TimeSpan.FromSeconds(10);

            Console.ForegroundColor = scansLeft > 0 ? (onCooldown ? ConsoleColor.DarkGray : ConsoleColor.Cyan) : ConsoleColor.Red;
            string cdInfo = onCooldown ? $"ПЕРЕЗАРЯДКА: {10 - (int)elapsed.TotalSeconds}с" : "ГОТОВ";
            Console.Write($"[ СКАНЕР: {scansLeft} зарядов ] -> {scanStatus} | {cdInfo}".PadRight(Console.WindowWidth));

            Console.ResetColor();
            Console.SetCursorPosition(oldX, oldY);
        }
    }

    static void DrawFileList()
    {
        lock (lockObj)
        {
            Console.SetCursorPosition(0, 3);
            Console.WriteLine($"ПУТЬ: {currentDir.Replace(rootPath, "CORE")}".PadRight(Console.WindowWidth));
            Console.WriteLine(new string('=', Console.WindowWidth));

            var items = Directory.GetFileSystemEntries(currentDir).ToList();
            for (int i = 0; i < items.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                string prefix = Directory.Exists(items[i]) ? "[FOLDER]" : "[ FILE ]";
                Console.WriteLine($"{prefix} {Path.GetFileName(items[i])}".PadRight(Console.WindowWidth));
                Console.ResetColor();
            }
            for (int k = 0; k < 5; k++) Console.WriteLine(new string(' ', Console.WindowWidth));
        }
    }

    static void HandleInput()
    {
        if (!Console.KeyAvailable) return;
        var key = Console.ReadKey(true).Key;
        var items = Directory.GetFileSystemEntries(currentDir).ToList();

        if (key == ConsoleKey.UpArrow && selectedIndex > 0) selectedIndex--;
        if (key == ConsoleKey.DownArrow && selectedIndex < items.Count - 1) selectedIndex++;
        if (key == ConsoleKey.Enter && items.Count > 0 && Directory.Exists(items[selectedIndex]))
        {
            currentDir = items[selectedIndex]; selectedIndex = 0; Console.Clear();
        }
        if (key == ConsoleKey.Backspace && currentDir != rootPath)
        {
            currentDir = Directory.GetParent(currentDir).FullName; selectedIndex = 0; Console.Clear();
        }
        if (key == ConsoleKey.Insert) StartScan(items.ElementAtOrDefault(selectedIndex));
        if (key == ConsoleKey.Delete && items.Count > 0 && File.Exists(items[selectedIndex]))
        {
            ProcessAction(items[selectedIndex]);
        }
    }

    static void StartScan(string path)
    {
        if (string.IsNullOrEmpty(path) || Directory.Exists(path)) return;
        if (scansLeft <= 0 || (DateTime.Now - lastScanTime).TotalSeconds < 10) return;

        scansLeft--;
        lastScanTime = DateTime.Now;
        scanStatus = "ИДЕТ АНАЛИЗ...";
        RefreshHeader();

        Thread.Sleep(1200);
        scanStatus = virusFiles.Contains(path) ? "!!! ОБНАРУЖЕН ВИРУС !!!" : "УГРОЗ НЕ НАЙДЕНО";
        RefreshHeader();
    }

    static void ProcessAction(string path)
    {
        if (virusFiles.Contains(path))
        {
            virusFiles.Remove(path);
            if (virusFiles.Count == 0) EndGame(true);
        }
        else if (trapFiles.Contains(path))
        {
            timeLeft -= 30;
            PlayScreamer();
        }
        else
        {
            timeLeft -= 15;
        }
        File.Delete(path);
        selectedIndex = 0;
    }

    static void PlayScreamer()
    {
        Console.BackgroundColor = ConsoleColor.White; Console.Clear();
        for (int i = 0; i < 15; i++) { Console.Beep(1800, 60); Console.WriteLine("666 ERROR 666 ERROR 666 ERROR 666 ERROR 666"); }
        Thread.Sleep(600); Console.ResetColor(); Console.Clear();
    }

    static void EndGame(bool win)
    {
        gameOver = true; Console.Clear();
        if (win)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("СИСТЕМА ОЧИЩЕНА. ТЕРМИНАЛ СПАСЕН.");
        }
        else
        {
            Random r = new Random();
            for (int i = 0; i < 600; i++)
            {
                Console.SetCursorPosition(r.Next(Console.WindowWidth), r.Next(Console.WindowHeight));
                Console.BackgroundColor = ConsoleColor.DarkRed; Console.Write("X");
                if (i % 30 == 0) Thread.Sleep(5);
            }
            Console.ResetColor(); Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            string msg = "СИСТЕМА РАСПЛАВЛЕНА";
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2);
            foreach (char c in msg) { Console.Write(c); Console.Beep(100, 250); Thread.Sleep(120); }
        }
        Thread.Sleep(4000); Environment.Exit(0);
    }
}
