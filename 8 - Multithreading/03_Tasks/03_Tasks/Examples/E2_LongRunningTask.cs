namespace Tasks.Examples;

class LongRunningTaskExample : IExample
{
    public string Name { get; set; } = "Long-running Task";

    public void Run()
    {
       Task task = Task.Factory.StartNew(() => 
       {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} is working... ({i + 1})");
                Thread.Sleep(1000); // Sleep for 1 second between each iteration
            }
       }, TaskCreationOptions.LongRunning);
    }
}