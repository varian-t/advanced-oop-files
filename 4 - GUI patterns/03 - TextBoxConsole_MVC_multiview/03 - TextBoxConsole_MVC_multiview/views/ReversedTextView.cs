using System;
using System.Linq;
class ReversedTextView: IView
{
    public void Display(string text)
    {
        Console.WriteLine($"Reversed Text: {new string(text.Reverse().ToArray())}");
    }
}
