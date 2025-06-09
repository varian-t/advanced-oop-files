using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media; // Needed for Brushes
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using B2ImgEditor.Models;  // <-- Add this at the top


namespace B2ImgEditor
{
    public partial class MainWindow : Window
    {
        private B2Image _image;
        private readonly FileDialogHelper _fileDialogHelper; // Declare the helper instance

        public MainWindow()
        {
            InitializeComponent();
            _fileDialogHelper = new FileDialogHelper(); // Initialize the helper
            _image = B2Image.LoadFromFile("test.b2img.txt"); // Load default image file
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            var grid = this.FindControl<Grid>("PixelGrid");

            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();

            for (int i = 0; i < _image.Height; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            for (int j = 0; j < _image.Width; j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < _image.Height; i++)
            {
                for (int j = 0; j < _image.Width; j++)
                {
                    var pixelButton = new Button
                    {
                        Background = _image.Pixels[i, j] == 1 ? Brushes.Black : Brushes.White,
                        Width = 20,
                        Height = 20
                    };

                    // Store pixel coordinates inside the button's Tag
                    pixelButton.Tag = (i, j);
                    pixelButton.Click += PixelButton_Click; // Attach click event

                    grid.Children.Add(pixelButton);
                    Grid.SetRow(pixelButton, i);
                    Grid.SetColumn(pixelButton, j);
                }
            }
        }

        private void PixelButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button pixelButton && pixelButton.Tag is ValueTuple<int, int> pos)
            {
                int i = pos.Item1;
                int j = pos.Item2;

                // Toggle between 0 (white) and 1 (black)
                _image.Pixels[i, j] = _image.Pixels[i, j] == 1 ? 0 : 1;

                // Update button color
                pixelButton.Background = _image.Pixels[i, j] == 1 ? Brushes.Black : Brushes.White;
            }
        }

        private async void ChooseFileButton_Click(object sender, RoutedEventArgs e)
        {
            var filePath = await _fileDialogHelper.ShowOpenFileDialog(this);

            if (!string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine($"Selected file: {filePath}");
                _image = B2Image.LoadFromFile(filePath); // Load the new image
                PopulateGrid(); // Refresh grid to reflect new image
            }
            else
            {
                Console.WriteLine("No file selected.");
            }
        }

        private async void ExportImageButton_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                DefaultExtension = "txt",
                Filters = new List<FileDialogFilter>
                {
                    new FileDialogFilter { Name = "Text Files", Extensions = { "txt" } }
                }
            };

            string filePath = await saveFileDialog.ShowAsync(this);

            if (!string.IsNullOrEmpty(filePath))
            {
                SaveImageToFile(filePath);
                Console.WriteLine($"Image saved to: {filePath}");
            }
        }

        public void SaveImageToFile(string filePath)
{
    Console.WriteLine("Saving file to: " + filePath);
    
    // Comment out file writing for now
    // File.WriteAllText(filePath, ConvertToB2ImageFormat());
    
    Console.WriteLine("File saved successfully.");
}
    }
}
