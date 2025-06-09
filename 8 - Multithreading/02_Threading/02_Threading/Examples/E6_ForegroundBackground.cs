namespace Threading.Examples;

using System.Threading;

class ForegroundBackgroundExample : IExample 
{
    public bool IsBackground {get; set;} = true;

    public string Name {get; set;} = "Background/Foreground";

    public void Run () 
    {
        Thread thread = new Thread(DoWork);
        thread.IsBackground = IsBackground;
        thread.Start();
    }

    public void DoWork()
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} is doing work...");

        // Simulate some work
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} is working... ({i + 1})");
            Thread.Sleep(1000); // Sleep for 1 second between each iteration
        }

        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} work finished.");
    }
    
}

