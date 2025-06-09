using System;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TextBoxAvalonia_XAML
{
    public partial class TextWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? text;
        
        [ObservableProperty]
        private string? reversedText;
        
        [ObservableProperty]
        private string? uppercaseText;

        public TextWindowViewModel()
        {
            Text = string.Empty;
        }

        partial void OnTextChanged(string? value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                ReversedText = new string(value.Reverse().ToArray());
                UppercaseText = value.ToUpper();
            }
            else
            {
                ReversedText = string.Empty;
                UppercaseText = string.Empty;
            }
        }
    }
}