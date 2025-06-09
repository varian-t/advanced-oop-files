
using System;
using System.Text.Json;

namespace WikipediaConsoleApp;

public static class JsonConverter
{
    public static WikipediaEdit? Convert(JsonElement element)
    {
        // This method takes a JsonElement representing a single edit from the Wikipedia API
        // and should return a WikipediaEdit instance.
        try
        {
            // 1. Create a new instance of WikipediaEdit
            var edit = new WikipediaEdit();

            // 2. Extract basic properties checking for null values
            edit.Type = element.TryGetProperty("type", out var typeEl) ? typeEl.GetString() : null;
            edit.Title = element.TryGetProperty("title", out var titleEl) ? titleEl.GetString() : null;
            edit.Timestamp = element.TryGetProperty("timestamp", out var tsEl) ? tsEl.GetString() : null;

            // 3. Calculate SizeChange by substracting the previous length of the article from the length after the edit
            //    This might be negative if the edit was a deletion.
            int newLen = element.TryGetProperty("newlen", out var newLenEl) && newLenEl.TryGetInt32(out int nl) ? nl : 0;
            int oldLen = element.TryGetProperty("oldlen", out var oldLenEl) && oldLenEl.TryGetInt32(out int ol) ? ol : 0;
            edit.SizeChange = newLen - oldLen;

            // 4. Determine if User is anonymous: Handle 'anon' property
            // TODO: Task 2 - Implement the 'anon' check logic.
            //    - Check if an "anon" property exist.
            //    - If it exists, set the User to "Anon".`
            //    - Otherwise (else block):
            //        - Try to get the "user" property from the JSON.
            //        - If successful, set it in the edit.
            //        - If getting "user" fails, set the User property to "Unknown";

            if (element.TryGetProperty("anon", out _)){
                edit.User = "anon";
            } else {

              if(element.TryGetProperty("user", out var userEl)){
              edit.User = userEl.GetString();
              }
              else{
                edit.User = "Unknown";
              }
            };

            return edit;
        }
        catch (Exception ex)
        {
             // Log errors during parsing
             Console.WriteLine($"\n[Error] Failed to convert JSON element: {ex.Message}\n");
             return null; // Return null on failure
        }
    }
}