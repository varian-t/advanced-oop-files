namespace Threading.Examples
{
    class ThreadWithSleepExample : IExample
    {
        public string Name { get; } = "Thread with Sleep";
        
        public void Run()
        {
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(1000);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Thread is running... {i}");
                }
                Console.WriteLine("Thread is done!");
            });

            thread.Start();
            
            Console.WriteLine("Main Thread is done!");

            thread.Join();
        }
    }
}