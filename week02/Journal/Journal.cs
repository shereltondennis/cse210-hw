class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();
    private readonly List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "Who was someone you interacted with today, and what did you learn?",
        "What is one goal you are working toward?",
        "What made you smile today?",
        "What challenge did you face, and how did you respond?"
    };
    private readonly Random _random = new Random();

    public void WriteEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(response))
        {
            Console.WriteLine("An entry needs a response.");
            return;
        }

        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        _entries.Add(new Entry(date, prompt, response.Trim()));
        Console.WriteLine("Entry added.");
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no entries to display.");
            return;
        }

        Console.WriteLine($"Journal entries: {_entries.Count}");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile()
    {
        Console.Write("File name (press Enter for journal.txt): ");
        string fileName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(fileName))
        {
            fileName = "journal.txt";
        }

        File.WriteAllLines(fileName, _entries.Select(entry => entry.ToFileLine()));
        Console.WriteLine($"Journal saved to {fileName}.");
    }

    public void LoadFromFile()
    {
        Console.Write("File name (press Enter for journal.txt): ");
        string fileName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(fileName))
        {
            fileName = "journal.txt";
        }

        if (!File.Exists(fileName))
        {
            Console.WriteLine($"Could not find {fileName}.");
            return;
        }

        List<Entry> loadedEntries = new List<Entry>();
        foreach (string line in File.ReadAllLines(fileName))
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                try
                {
                    loadedEntries.Add(Entry.FromFileLine(line));
                }
                catch (FormatException)
                {
                    Console.WriteLine("A line was skipped because it was not a valid journal entry.");
                }
            }
        }

        _entries.Clear();
        _entries.AddRange(loadedEntries);
        Console.WriteLine($"Loaded {_entries.Count} entries from {fileName}.");
    }

    public void SearchEntries()
    {
        Console.Write("Search keyword: ");
        string keyword = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("Enter a keyword to search.");
            return;
        }

        List<Entry> matches = _entries.Where(entry =>
            entry.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            entry.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

        Console.WriteLine($"Matches found: {matches.Count}");
        foreach (Entry entry in matches)
        {
            entry.Display();
        }
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}