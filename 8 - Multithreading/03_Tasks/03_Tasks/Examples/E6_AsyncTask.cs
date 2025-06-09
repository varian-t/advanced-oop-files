namespace Tasks.Examples;

class AsyncTaskExample : IExample
{
    public string Name { get; set; } =  "Asyncronous Task";

    public void Run()
    {
        Console.WriteLine("1 Starting");
        doSomethingAsync();
        Console.WriteLine("2 Continuing");
    }

    private async Task doSomethingAsync()
    {
        Console.WriteLine("3 Starting Task");
        Task task = TaskAsync();
        Thread.Sleep(1000);

        Console.WriteLine("4 Doing Something Else");

         Thread.Sleep(1000);

        Console.WriteLine("5 Awaiting Task");
        await task;

        Console.WriteLine("6 Task Done");
    }

    private Task TaskAsync()
    {
        Task task = Task.Run(() => 
        {
            for (int i = 0; i < 10; i++) 
            {
                Console.WriteLine("7 Actually Doing Something");
                Thread.Sleep(1000);
            }   
        });
        return task;
    }
}