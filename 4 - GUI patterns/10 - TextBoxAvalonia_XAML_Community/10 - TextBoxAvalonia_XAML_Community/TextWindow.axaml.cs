using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Data;

namespace TextBoxAvalonia_XAML
{
    public partial class TextWindow : Window
    {
        public TextWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}