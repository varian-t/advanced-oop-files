namespace Tasks.Examples;

class TaskResultExample : IExample
{
    public string Name { get; set; } =  "Task Result";

    public void Run()
    {

        Task<int> task = Task.Run (() => { Console.WriteLine ("Foo"); return 3; });

        int result = task.Result;      // Blocks if not already finished
        Console.WriteLine (result);    // 3
    }
}