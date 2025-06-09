using System.Data;
using System.Threading;
using Threading.Examples;

namespace Threading;

class Program 
{
    public static void Main() 
    {
        ExampleRunner exampleRunner = new ExampleRunner
        (
            new List<IExample>
            {
                new SimpleThreadExample(),
                new ThreadWithSleepExample(),
                new MultithreadExample(),
                new MultiWaitExample(),
                new SharedStateExample(),
                new ForegroundBackgroundExample {Name="Background", IsBackground=true},
                new ForegroundBackgroundExample {Name="Foreground", IsBackground=false},
            }
        );

        bool isRunning = true;

        while(isRunning) {
            System.Console.WriteLine("Choose an example to run:");
            for (int i = 0; i < exampleRunner.Examples.Count; i++) {
                IExample example = exampleRunner.Examples[i];
                System.Console.WriteLine($"{i}: {example.Name} Example");
            }
            string? input = System.Console.ReadLine();

            Console.Clear();
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            if (input == "exit") {
                isRunning = false;
                Console.Clear();
                break;
            }
            
            if (input is not null) exampleRunner.RunExample(input!);

            Console.WriteLine();
            Console.WriteLine("-----------------------------");
        }
    }
}