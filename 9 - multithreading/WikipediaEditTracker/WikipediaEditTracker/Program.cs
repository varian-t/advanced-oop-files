using System;
using System.Collections.Generic; 
using System.Linq;             
using System.Threading;        
using System.Threading.Tasks;  

namespace WikipediaConsoleApp;

class Program
{
    private const int FetchingPeriodInSeconds = 10; // Fetches every x seconds

    private static readonly WikipediaFetcher s_fetcher = new WikipediaFetcher(); 

    private static PeriodicTimer? s_timer; // Keep track of the active timer

    public static void Main(string[] args) 
    {
        Console.WriteLine("-- Simple Wikipedia Edit Viewer --");
        bool isRunning = true;

        while (isRunning)
        {
            DisplayMenu();
            var input = Console.ReadLine();
            Console.Clear(); // Clear screen after input

            switch (input)
            {
                case "1": // Start Fetching
                    // TODO: Task 3 - Implement Start
                    // Instructions:
                    // 1. Check if s_timer is already not null. If it is, print "Already fetching."
                    // 2. Check if already running, else:
                    //    - Print "Starting fetch..."
                    //    - Create a `new PeriodicTimer(TimeSpan.FromSeconds(FetchingPeriodInSeconds))` and store it in s_timer.
                    //    - Call `s_fetcher.StartFetching(s_timer)`.
                    //    - Print a confirmation message like $"Fetching started (every {FetchingPeriodInSeconds} seconds)."
                    // 3. Call PauseForUser() at the end of the case.
                    throw new NotImplementedException("Start Fetching logic needed.");


                case "2": // Stop Fetching
                     // TODO: Task 3 - Implement Stop
                     // Instructions:
                     // 1. Check if s_timer is null. If it is, print "Not currently fetching."
                     // 2. If running (else block):
                     //    - Print "Stopping fetch..."
                     //    - Call `s_fetcher.StopFetching()`.
                     //    - Dispose the s_timer (`s_timer?.Dispose();`).
                     //    - Set `s_timer = null;`
                     //    - Print confirmation message like "Fetching stopped."
                     // 3. Call PauseForUser() at the end of the case.
                    throw new NotImplementedException("Stop Fetching logic needed.");


                case "3": // Print Current Edits
                   // TODO: Task 4 & 5 - Implement Print
                   // Instructions:
                   // 1. Print "Current Edits Log:".
                   // 2. Call `s_fetcher.GetEditsSnapshot()` to get a thread-safe copy (Task 5). 
                   // Store in a local variable `List<WikipediaEdit> editsSnapshot`. 
                   // 3. Check if the edits list empty. If yes, notify the user.
                   // 4. Else:
                   //    - Iterate through `editsSnapshot`.
                   //    - Print each `edit`.
                   //    - If `edit.Categories` isn't null/empty, print them.
                   //    - After the loop, print a separator and the total count (`editsSnapshot.Count`).
                   // 5. Call PauseForUser().
                    throw new NotImplementedException("Print Edits logic needed.");


                case "4": // Exit
                    // TODO: Task 3 - Implement Exit
                    // Instructions:
                    // 1. Print "Exiting...".
                    // 2. Check if `s_timer != null`.
                    // 3. If it's not null, call the Stop Fetching logic (call `s_fetcher.StopFetching()`, dispose timer, nullify timer).
                    // 4. Set `isRunning = false;`
                    throw new NotImplementedException("Exit logic (including stopping fetcher) needed.");


                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    PauseForUser();
                    break;
            }
        }
        Console.WriteLine("\nApplication exited. Press Enter to close window.");
        Console.ReadLine();
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n========== MENU ==========");
        string status = (s_timer == null) ? "Stopped" : "Running"; 
        Console.WriteLine($"Status: {status}");
        Console.WriteLine("--------------------------");
        Console.WriteLine("1. Start Fetching");
        Console.WriteLine("2. Stop Fetching");
        Console.WriteLine("3. Print Current Edits");
        Console.WriteLine("4. Exit");
        Console.Write("Enter choice: ");
    }

    static void PauseForUser()
    {
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadLine();
        Console.Clear();
    }
}
