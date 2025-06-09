using System;
using System.Linq;

namespace WikipediaConsoleApp;

public class WikipediaEdit
{
    public string? Type { get; set; }
    public string? Title { get; set; }
    public string? User { get; set; }
    public int SizeChange { get; set; }
    public string? Timestamp { get; set; }
    public string[]? Categories { get; set; }


    // TODO: Task 1 - Implement ToString()
    public override string ToString()
    {
        // Implement this method to return a user-friendly string representation.
        // Use string interpolation (e.g., $"Title: {Title}...")
        // Use the null-coalescing operator (?? "N/A") to handle potential null values gracefully for Title, User, Timestamp.
        // Example format: "Title: {Title} | User: {User} | Change: {SizeChange}"
        return $"Type: {Title} | Title: {Title} | User: {User} | Change: {SizeChange} | Timestamp: {Timestamp} | Categories: {Categories}"; // Replace this line
    }
}
