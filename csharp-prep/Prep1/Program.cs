using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string first = System.Console.ReadLine();

        Console.Write("What is your last name? ");
        string last = System.Console.ReadLine();
        System.Console.WriteLine($"Your name is {last}, {first} {last}");
    }
}