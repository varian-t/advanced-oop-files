using System;
using System.Linq;
class ReversedTextView: IView
{
    public void Update(string message)
    {
        Console.WriteLine($"Reversed Text: {new string(message.Reverse().ToArray())}");
    }
}
