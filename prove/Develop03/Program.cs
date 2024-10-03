using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a scripture reference and scripture
        ScriptureReference reference = new ScriptureReference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");

        Random random = new Random();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("\n\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(random, 3);

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine("All words are hidden. Program will now end.");
                break;
            }
        }
    }
}

class ScriptureReference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int EndVerse { get; private set; }

    public ScriptureReference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = verse;
    }

    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (StartVerse == EndVerse)
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }
}

class Scripture
{
    public ScriptureReference Reference { get; private set; }
    private List<ScriptureWord> Words { get; set; }

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
    }

    public void HideRandomWords(Random random, int count)
    {
        for (int i = 0; i < count; i++)
        {
            int index = random.Next(Words.Count);
            Words[index].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return Words.All(word => word.IsHidden);
    }

    public string GetDisplayText()
    {
        return $"{Reference}\n\n" + string.Join(" ", Words.Select(word => word.GetDisplayText()));
    }
}

class ScriptureWord
{
    private string Text { get; set; }
    public bool IsHidden { get; private set; }

    public ScriptureWord(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string GetDisplayText()
    {
        return IsHidden ? "____" : Text;
    }
}
