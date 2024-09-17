// using System;

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Write the qualification:");

        // Read the qualification
        string input = Console.ReadLine();
        int grade = int.Parse(input);

        // Determine the letter grade
        string letterGrade = "";

        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        // Determine the sign
        string sign = "";
        int lastDigit = grade % 10;

        if (letterGrade != "A" && letterGrade != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letterGrade == "A" && lastDigit < 3)
        {
            sign = "-";
        }

        // Show the letter grade with sign
        Console.WriteLine("The letter grade is: " + letterGrade + sign);

        if (grade >= 70)
        {
            System.Console.WriteLine("You passed the test, congratulations!");
        }
        else
        {
            System.Console.WriteLine("Keep working harder.");
        }
    }
}

