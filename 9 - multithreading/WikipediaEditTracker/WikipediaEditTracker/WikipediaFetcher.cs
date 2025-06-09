using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json; 
using System.Linq; 

namespace WikipediaConsoleApp;

public class WikipediaFetcher
{
    // TODO: Task 4 - Define _edits list field (`List<WikipediaEdit>`). Initialize it.
    // TODO: Task 5 - Define _lockObject field (`private readonly object`). Initialize it.
    private PeriodicTimer? _timer;
    private Task? _fetchingTask;
    private CancellationTokenSource? _cts;


    // TODO: Task 3 - Complete Constructor (Minimal needed if list initialized above)
    public WikipediaFetcher()
    {
        
    }

    // TODO: Task 3 - Implement StartFetching
    public void StartFetching(PeriodicTimer timer)
    {
        // Instructions:
        // 1. Check if already running: if _fetchingTask is not null AND its IsCompleted property is false, print a message and return.
        // 2. Store the passed 'timer' argument in the _timer field.
        // 3. Create a new CancellationTokenSource and store it in the _cts field.
        // 4. Get the token from the source
        // 5. Start the FetchEditsLoopAsync method on a background thread using Task.Run
        // 6. Print a confirmation message like "[Info] Fetcher started."
    }

    // TODO: Task 3 - Implement StopFetching
    public void StopFetching()
    {
        // Instructions:
        // 1. Check if already stopped: if _cts is null OR _cts.IsCancellationRequested is true, print a message and return.
        // 2. Dispose the timer: `_timer?.Dispose();`.
        // 3. Request cancellation: `_cts.Cancel();`
        // 4. Dispose the cancellation token source: `_cts?.Dispose();`
        // 5. Set _cts = null;
        // 6. Set _timer = null; 
        // 7. Print a confirmation message like "[Info] Fetcher stop requested."
    }

    // TODO: Task 3, 4, 5 - Implement the FetchEditsLoopAsync method
    private async Task FetchEditsLoopAsync(CancellationToken token)
    {
        // This method runs on a background thread and loops until cancelled.
        Console.WriteLine("[Fetcher] Fetching loop started.");
        try
        {
            if (_timer == null) return;

            while (await _timer.WaitForNextTickAsync(token)) // Loop based on timer and token
            {
                Console.WriteLine("[Fetcher] Fetching batch...");
                // 1. Call helper to get edits: `JsonElement.ArrayEnumerator? results = await WikipediaHttpRequest.FetchEditsAsync(token);`

                // 2. Check if results has value: `if (results.HasValue)`
                if (true) // Replace 'true' with your check
                {
                    // 3. Iterate through results
                    // Inside the loop:
                        // 4. Check for cancellation
                        // 5. Convert JSON: `WikipediaEdit? edit = JsonConverter.Convert(resultElement);`
                        // 6. Check if edit is not null
                        // If not null:
                            // --- Task 3 Test Point ---
                            // Initially, just print the edit to test fetching and converting:

                            // --- Task 4 Implementation ---
                            // Comment out the direct Console.WriteLine above.
                            // Add the edit to the _edits list. (This is NOT thread-safe yet).

                            // --- Task 5 Implementation ---
                            // Using a lock add the `edit` to the `_edits` list in a thread safe manner.

                } 
                else { Console.WriteLine("[Fetcher] No results in batch or API error."); }

                if (token.IsCancellationRequested) break;

            } 
        }
        catch (OperationCanceledException) { Console.WriteLine("[Fetcher] Loop cancelled."); }
        catch (Exception ex) { Console.WriteLine($"[Fetcher] Error in loop: {ex.Message}"); }
        finally { Console.WriteLine("[Fetcher] Fetching loop stopped."); }
    }


    // TODO: Task 5 - Implement GetEdits safely
    public List<WikipediaEdit> GetEditsSnapshot()
    {
        // This method needs to return a *copy* of the internal _edits list
        // in a thread-safe way.
        // Instructions:
        // 1. Use a `lock` statement targeting your `_lockObject`.
        // 2. Inside the lock block:
        //    - Create a new list from the existing _edits list. `_edits.ToList();` (requires using System.Linq).
        //    - Return the newly created list (the snapshot).
        throw new NotImplementedException("Implement GetEditsSnapshot with locking.");
    }

    // Helper for Printing Categories
    private bool ShouldFetchCategories(WikipediaEdit edit)
    {
        // Fetch categories only for likely articles (no namespace prefix like "User:")
        return edit?.Title != null && !edit.Title.Contains(':');
    }
}