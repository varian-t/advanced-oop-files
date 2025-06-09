using System;
class UpperCaseTextView: IView
{
    public void Display(string text)
    {
        Console.WriteLine("Capitalized Text: " + text.ToUpper());
    }
}
