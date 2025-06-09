using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Avalonia.Input;
using ContactListMVVM.ViewModels;
using ContactListMVVM.Views;
using Xunit;



namespace ContactListTest;

public class ContactListTests
{
    [AvaloniaFact]
    public void AddingContact_UpdatesListBox()
    {
        var window = new MainWindow()
        {
            DataContext = new MainWindowViewModel()
        };

        window.Show();

        //Simulate Text Input
        window.NameTextBox.Focus();
        window.KeyTextInput("Unit Test");
        
        window.EmailTextBox.Focus();
        window.KeyTextInput("unit@test.com");

        // Simulate button click
        window.AddContactButton.Focus();
        window.KeyPressQwerty(PhysicalKey.Enter, RawInputModifiers.None);


        // Find ListBox and verify the new item exists
        Assert.Contains(window.ContactsListBox.Items, item => item?.ToString() == "Unit Test (unit@test.com)");
    }
}