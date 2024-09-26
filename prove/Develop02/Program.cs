using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json; // For JSON support

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }
    public string Mood { get; set; } // Additional field
    public string Tags { get; set; } // Additional field for tags

    public Entry(string prompt, string response, string mood, string tags)
    {
        Prompt = prompt;
        Response = response;
        Mood = mood;
        Tags = tags;
        Date = DateTime.Now;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine($"Tags: {Tags}");
        Console.WriteLine();
    }

    // CSV-friendly format
    public string ToCsv()
    {
        return $"\"{Date}\",\"{Prompt.Replace("\"", "\"\"")}\",\"{Response.Replace("\"", "\"\"")}\",\"{Mood}\",\"{Tags}\"";
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in entries)
        {
            entry.Display();
        }
    }

    // Save entries as a CSV file
    public void SaveToCsv(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            // Write CSV headers
            writer.WriteLine("Date,Prompt,Response,Mood,Tags");

            foreach (var entry in entries)
            {
                writer.WriteLine(entry.ToCsv());
            }
        }
    }

    // Load entries from a CSV file
    public void LoadFromCsv(string file)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(file))
        {
            string line;
            // Skip headers
            reader.ReadLine();
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(new[] { "\",\"" }, StringSplitOptions.None);
                if (parts.Length == 5)
                {
                    var date = DateTime.Parse(parts[0].Trim('"'));
                    var prompt = parts[1].Trim('"').Replace("\"\"", "\"");
                    var response = parts[2].Trim('"').Replace("\"\"", "\"");
                    var mood = parts[3].Trim('"');
                    var tags = parts[4].Trim('"');
                    entries.Add(new Entry(prompt, response, mood, tags) { Date = date });
                }
            }
        }
    }

    // Save entries as a JSON file
    public void SaveToJson(string file)
    {
        string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
        File.WriteAllText(file, json);
    }

    // Load entries from a JSON file
    public void LoadFromJson(string file)
    {
        string json = File.ReadAllText(file);
        entries = JsonConvert.DeserializeObject<List<Entry>>(json);
    }
}

class PromptGenerator
{
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    private int currentIndex = 0;

    public string GetNextPrompt()
    {
        if (currentIndex >= prompts.Count)
        {
            currentIndex = 0; // Reset to the first prompt if we've reached the end
        }
        return prompts[currentIndex++];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a CSV file");
            Console.WriteLine("4. Load the journal from a CSV file");
            Console.WriteLine("5. Save the journal to a JSON file");
            Console.WriteLine("6. Load the journal from a JSON file");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Quick Entry (Y/N)? ");
                    string quickEntry = Console.ReadLine();
                    string prompt = promptGenerator.GetNextPrompt();
                    string response = "";

                    if (quickEntry.ToLower() != "y")
                    {
                        Console.WriteLine($"Prompt: {prompt}");
                        Console.Write("Your response: ");
                        response = Console.ReadLine();
                    }
                    else
                    {
                        response = "Quick Entry: Skipped detailed response.";
                    }

                    Console.Write("Mood: ");
                    string mood = Console.ReadLine();
                    Console.Write("Tags (comma-separated): ");
                    string tags = Console.ReadLine();

                    journal.AddEntry(new Entry(prompt, response, mood, tags));
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter filename to save as CSV: ");
                    string saveCsvFile = Console.ReadLine();
                    journal.SaveToCsv(saveCsvFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load from CSV: ");
                    string loadCsvFile = Console.ReadLine();
                    journal.LoadFromCsv(loadCsvFile);
                    break;
                case "5":
                    Console.Write("Enter filename to save as JSON: ");
                    string saveJsonFile = Console.ReadLine();
                    journal.SaveToJson(saveJsonFile);
                    break;
                case "6":
                    Console.Write("Enter filename to load from JSON: ");
                    string loadJsonFile = Console.ReadLine();
                    journal.LoadFromJson(loadJsonFile);
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}


// using System;
// using System.Collections.Generic;
// using System.IO;

// class Entry
// {
//     public string Prompt { get; set; }
//     public string Response { get; set; }
//     public DateTime Date { get; set; }

//     public Entry(string prompt, string response)
//     {
//         Prompt = prompt;
//         Response = response;
//         Date = DateTime.Now;
//     }

//     public void Display()
//     {
//         Console.WriteLine($"Date: {Date}");
//         Console.WriteLine($"Prompt: {Prompt}");
//         Console.WriteLine($"Response: {Response}");
//         Console.WriteLine();
//     }
// }

// class Journal
// {
//     private List<Entry> entries = new List<Entry>();

//     public void AddEntry(Entry newEntry)
//     {
//         entries.Add(newEntry);
//     }

//     public void DisplayAll()
//     {
//         foreach (var entry in entries)
//         {
//             entry.Display();
//         }
//     }

//     public void SaveToFile(string file)
//     {
//         using (StreamWriter writer = new StreamWriter(file))
//         {
//             foreach (var entry in entries)
//             {
//                 writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
//             }
//         }
//     }

//     public void LoadFromFile(string file)
//     {
//         entries.Clear();
//         using (StreamReader reader = new StreamReader(file))
//         {
//             string line;
//             while ((line = reader.ReadLine()) != null)
//             {
//                 var parts = line.Split('|');
//                 if (parts.Length == 3)
//                 {
//                     var date = DateTime.Parse(parts[0]);
//                     var prompt = parts[1];
//                     var response = parts[2];
//                     entries.Add(new Entry(prompt, response) { Date = date });
//                 }
//             }
//         }
//     }
// }

// class PromptGenerator
// {
//     private List<string> prompts = new List<string>
//     {
//         "Who was the most interesting person I interacted with today?",
//         "What was the best part of my day?",
//         "How did I see the hand of the Lord in my life today?",
//         "What was the strongest emotion I felt today?",
//         "If I had one thing I could do over today, what would it be?"
//     };

//     private int currentIndex = 0;

//     public string GetNextPrompt()
//     {
//         if (currentIndex >= prompts.Count)
//         {
//             currentIndex = 0; // Reset to the first prompt if we've reached the end
//         }
//         return prompts[currentIndex++];
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         Journal journal = new Journal();
//         PromptGenerator promptGenerator = new PromptGenerator();
//         bool running = true;

//         while (running)
//         {
//             Console.WriteLine("Menu:");
//             Console.WriteLine("1. Write a new entry");
//             Console.WriteLine("2. Display the journal");
//             Console.WriteLine("3. Save the journal to a file");
//             Console.WriteLine("4. Load the journal from a file");
//             Console.WriteLine("5. Exit");
//             Console.Write("Choose an option: ");
            
//             string choice = Console.ReadLine();

//             switch (choice)
//             {
//                 case "1":
//                     string prompt = promptGenerator.GetNextPrompt();
//                     Console.WriteLine($"Prompt: {prompt}");
//                     Console.Write("Your response: ");
//                     string response = Console.ReadLine();
//                     journal.AddEntry(new Entry(prompt, response));
//                     break;
//                 case "2":
//                     journal.DisplayAll();
//                     break;
//                 case "3":
//                     Console.Write("Enter filename to save: ");
//                     string saveFile = Console.ReadLine();
//                     journal.SaveToFile(saveFile);
//                     break;
//                 case "4":
//                     Console.Write("Enter filename to load: ");
//                     string loadFile = Console.ReadLine();
//                     journal.LoadFromFile(loadFile);
//                     break;
//                 case "5":
//                     running = false;
//                     break;
//                 default:
//                     Console.WriteLine("Invalid option. Please try again.");
//                     break;
//             }
//         }
//     }
// }
