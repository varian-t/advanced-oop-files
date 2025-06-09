using System;
class UpperCaseTextView: IView
{
    public void Update(string message)
    {
        Console.WriteLine("Capitalized Text: " + message.ToUpper());
    }
}
