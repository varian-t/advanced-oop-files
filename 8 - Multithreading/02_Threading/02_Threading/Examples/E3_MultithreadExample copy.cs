namespace Threading.Examples
{
    class MultithreadExample : IExample
    {
        public string Name { get; } = "Multithread";

        public void Run()
        {
            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    Console.Write($"x");
                }
                Console.WriteLine("Thread 1 is done!");
            });

            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    Console.Write($"y");
                }
                Console.WriteLine("Thread 2 is done!");
            });

            thread1.Start();
            thread2.Start();

            Console.WriteLine("Main thread is done!");
            
            thread1.Join();
            thread2.Join();
        }
    }
}