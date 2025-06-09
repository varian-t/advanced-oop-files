namespace Threading.Examples
{
    class MultiWaitExample : IExample
    {
        public string Name { get; set; } = "Multithread Waiting";

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

            thread1.Start();
            thread1.Join();

            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    Console.Write($"y");
                }
                Console.WriteLine("Thread 2 is done!");
            });


            thread2.Start();
            thread2.Join();

            Console.WriteLine("Main thread is done!");
        }
    }
}