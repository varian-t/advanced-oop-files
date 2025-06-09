namespace Threading.Examples;
class SharedStateExample : IExample
{
    public string Name { get; set; } = "Shared State";

    private bool _done = false;

    public void Run()
    {
        _done = false;

        Thread thread = new Thread(DoSomething);
        thread.Start();

        DoSomething();

        thread.Join();
    }

    public void DoSomething()
    {
        if (!_done)
        {
            _done = true;
            Console.WriteLine("Done");
        }
    }
}