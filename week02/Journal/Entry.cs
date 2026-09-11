class Entry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date} - Prompt: {Prompt}");
        Console.WriteLine($"{Response}\n");
    }

    public string ToFileLine()
    {
        return $"{Date}\t{Prompt}\t{Response.Replace("\t", " ")}";
    }

    public static Entry FromFileLine(string line)
    {
        string[] parts = line.Split('\t', 3);
        if (parts.Length != 3)
        {
            throw new FormatException("The journal file contains an invalid entry.");
        }

        return new Entry(parts[0], parts[1], parts[2]);
    }
}