
using System;

class Program
{
    static void Main()
    {
        string text = "Default text";
        while (true)
        {
            Console.Clear(); // Clears the console screen
            Console.WriteLine("Current Text: " + text);
            Console.WriteLine("Enter new text (or type 'exit' to quit):");
            string? input = Console.ReadLine();
            
            if (input.ToLower() == "exit")
                break;
            
            text = input; // Update the text
        }
    }
}
