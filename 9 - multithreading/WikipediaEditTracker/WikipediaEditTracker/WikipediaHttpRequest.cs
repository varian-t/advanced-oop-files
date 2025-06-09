using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading; 

namespace WikipediaConsoleApp; 

// This class is static since each public member is supposed to be used from anywhere in the program
// and it doesn't need to be instantiated.

public static class WikipediaHttpRequest
{
    // HttpClient is intended to be instantiated once and re-used.
    private static readonly HttpClient _httpClient = new HttpClient();


    // Fetches recent changes list from Wikipedia API
    public static async Task<JsonElement.ArrayEnumerator?> FetchEditsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            // This calls the Wikipedia API to get recent changes
            // You can open this URL in a browser to see the JSON response
            string url = "https://en.wikipedia.org/w/api.php?action=query&format=json&list=recentchanges&rcprop=title|user|timestamp|sizes";

            using var response = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            response.EnsureSuccessStatusCode();

            var jsonStream = await response.Content.ReadAsStreamAsync(cancellationToken);

            // Ensure correct deserialization options if needed, but defaults are often fine
            var json = await JsonSerializer.DeserializeAsync<JsonElement>(jsonStream, cancellationToken: cancellationToken);

            // Navigate the JSON structure safely
            if (json.TryGetProperty("query", out var queryElement) &&
                queryElement.TryGetProperty("recentchanges", out var recentChangesElement) &&
                recentChangesElement.ValueKind == JsonValueKind.Array)
            {
                return recentChangesElement.EnumerateArray();
            }
            Console.WriteLine("\n[Error] Could not find 'query.recentchanges' array in API response.\n");
        }
         // Catch specific exceptions
         catch (HttpRequestException ex) { Console.WriteLine($"\n[Error] Network error fetching edits: {ex.Message}\n"); }
         catch (JsonException ex) { Console.WriteLine($"\n[Error] JSON error parsing edits: {ex.Message}\n"); }
         catch (OperationCanceledException) { Console.WriteLine("\n[Info] Edit fetching cancelled.\n"); }
         catch (Exception ex) { Console.WriteLine($"\n[Error] Unexpected error fetching edits: {ex.Message}\n"); }
        return null; // Return null on error or if structure not found
    }

    // Fetches categories for a given wikipedia article given its title
    public static async Task<string[]> FetchCategoriesAsync(string title, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(title)) return ["Invalid title"];
        try
        {
            // API endpoint for categories, title needs to be URL-encoded
            string categoryUrl = $"https://en.wikipedia.org/w/api.php?action=query&format=json&prop=categories&cllimit=max&titles={Uri.EscapeDataString(title)}";
            using var response = await _httpClient.GetAsync(categoryUrl, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            response.EnsureSuccessStatusCode();

            var jsonStream = await response.Content.ReadAsStreamAsync(cancellationToken);
            var json = await JsonSerializer.DeserializeAsync<JsonElement>(jsonStream, cancellationToken: cancellationToken);

            if (json.TryGetProperty("query", out var queryElement) &&
                queryElement.TryGetProperty("pages", out var pagesElement))
            {
                // The structure includes a page ID which varies, so we iterate pages
                foreach (var page in pagesElement.EnumerateObject())
                {
                    // Check if page is valid and has categories property
                    if (page.Value.ValueKind == JsonValueKind.Object &&
                        page.Value.TryGetProperty("categories", out var categories) &&
                        categories.ValueKind == JsonValueKind.Array)
                    {
                        // Extract category titles and clean them up
                        return categories.EnumerateArray()
                            .Select(cat => cat.TryGetProperty("title", out var catTitle) ? catTitle.GetString()?.Replace("Category:", "") ?? "Unknown" : "Unknown")
                            .ToArray();
                    }
                     // Check if page is marked as missing (invalid title, etc.)
                    if (page.Value.TryGetProperty("missing", out _))
                    {
                         return ["Article not found"];
                    }
                }
                 return ["No categories property found"]; // Explicitly state if property missing
            }
        }
         catch (HttpRequestException ex) { Console.WriteLine($"Network error fetching categories for {title}: {ex.Message}"); }
         catch (JsonException ex) { Console.WriteLine($"JSON error parsing categories for {title}: {ex.Message}"); }
         catch (OperationCanceledException) { Console.WriteLine($"Category fetch cancelled for {title}."); }
        catch (Exception ex) { Console.WriteLine($"Unexpected error fetching categories for {title}: {ex.Message}"); }

        return ["Error fetching categories"]; // Default/fallback on error
    }
}
