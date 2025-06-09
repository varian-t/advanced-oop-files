using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading.Tasks;  // To use Task
using System.Collections.Generic;  // To use List<T>
using System.Linq;  // To use LINQ methods like FirstOrDefault

namespace B2ImgEditor
{
    public class FileDialogHelper
    {
        public async Task<string?> ShowOpenFileDialog(Window parent)
        {
            // Initialize the OpenFileDialog
            var openFileDialog = new OpenFileDialog
            {
                AllowMultiple = false, // Allow only one file
                Filters = new List<FileDialogFilter>
                {
                    new FileDialogFilter
                    {
                        Name = "Text Files",
                        Extensions = { "txt" }
                    },
                    new FileDialogFilter
                    {
                        Name = "All Files",
                        Extensions = { "*" }
                    }
                }
            };

            // Show the dialog and get the result
            var result = await openFileDialog.ShowAsync(parent);

            return result?.FirstOrDefault(); // Return the path of the first selected file
        }
    }
}
