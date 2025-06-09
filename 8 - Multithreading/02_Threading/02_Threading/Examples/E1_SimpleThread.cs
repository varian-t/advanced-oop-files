namespace Threading.Examples;

class SimpleThreadExample : IExample
{
    public string Name { get; } = "Simple Thread";

    public void Run()
    {
        Thread thread = new Thread(CountToTen);
        thread.Start();

        Console.WriteLine("Main thread is done!");
        thread.Join();
    }

    public void CountToTen()
    {
        Console.WriteLine("Second Thread is running!");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{i}");
        }
        Console.WriteLine("Second Thread is done!");
    }
}