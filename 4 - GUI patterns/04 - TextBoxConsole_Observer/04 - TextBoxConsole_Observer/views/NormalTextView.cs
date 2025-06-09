using System;
class NormalTextView: IView
{
    public void Update(string message)
    {
        Console.WriteLine("Current Text: " + message);
    }
}
