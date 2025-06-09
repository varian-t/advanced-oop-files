
class NormalTextView
{
    public void Display(string text)
    {
        Console.Clear();
        Console.WriteLine("Current Text: " + text);
        Console.WriteLine("Enter new user first and last name (or type 'exit' to quit):");
    }

  public static implicit operator NormalTextView(TextView v)
  {
    throw new NotImplementedException();
  }
}
