using System.Data;
using System.Threading;
using Tasks.Examples;

namespace Tasks;

class Program 
{
    public static void Main() 
    {
        ExampleRunner exampleRunner = new ExampleRunner
        (
            new List<IExample>
            {
                new SimpleTaskExample(),
                new LongRunningTaskExample(),
                new TaskResultExample(),
                new TaskExceptionExample(),
                new TaskContinuationExample(),
                new AsyncTaskExample()
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
                continue;
            }
            
            if (input is not null) exampleRunner.RunExample(input!);

            Console.WriteLine();
            Console.WriteLine("-----------------------------");
        }
    }
}