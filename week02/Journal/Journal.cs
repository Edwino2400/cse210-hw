public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in entries)
            {
                outputFile.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            Entry entry = new Entry
            {
                Date = parts[0],
                Prompt = parts[1],
                Response = parts[2]
            };
            entries.Add(entry);
        }
    }
}
