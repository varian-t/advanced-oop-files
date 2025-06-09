namespace Tasks.Examples;

class TaskExceptionExample : IExample
{
    public string Name { get; set; } =  "Task Exception";

    public void Run()
    {
        // Start a Task that throws a NullReferenceException:
        Task task = Task.Run (() => 
        {
            Thread.Sleep(2000); 
            throw null; 
        });
        try 
        {
        task.Wait();
        }
        catch (AggregateException aex)
        {
        if (aex.InnerException is NullReferenceException)
            Console.WriteLine ("Null!");
        else
            throw;
        }
    }
}