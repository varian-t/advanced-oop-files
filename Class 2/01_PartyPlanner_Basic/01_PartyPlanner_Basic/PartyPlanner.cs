using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.PropertyStore;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Globalization;

public class PartyPlanner 
{
    private Window win;
    private DinnerParty dinnerParty = new DinnerParty() { NumberOfPeople = 5 };
    private BirthdayParty birthdayParty = new BirthdayParty();

    private NumericUpDown dinner_NumberOfPeopleNumericUpDown;
    private CheckBox dinner_isFancyCheckBox;
    private CheckBox dinner_isHealthyCheckBox;
    private TextBox dinner_costTextBox;

    private NumericUpDown birthday_NumberOfPeopleNumericUpDown;
    private CheckBox birthday_isFancyCheckBox;
    private TextBox birthday_costTextBox;
    private ComboBox birthday_CakeSizeComboBox;

    public PartyPlanner() 
    {
        win = new Window
        {
            Title = "Dinnerparty",
            Height = 700, 
            Width = 600, 
        };

        var tabControl = new TabControl();

        // Tab for adding a new dinner party
        var dinner_PartyPanel = new StackPanel() 
        {
            Orientation = Orientation.Vertical,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            Margin = new Thickness(20),
            RenderTransform = new ScaleTransform(3, 3),
        };

        var dinner_NumberOfPeopleLabel = new Label { Content = "Number of People:" };
        dinner_NumberOfPeopleNumericUpDown = new NumericUpDown { Minimum = 1, Maximum = 100, Value = 5 };

        dinner_isFancyCheckBox = new CheckBox { Content = "Is Fancy?" };
        dinner_isHealthyCheckBox = new CheckBox() { Content = "Healthy Option:" };
        
        dinner_costTextBox = new TextBox { Margin = new Thickness(0, 10, 0, 0), IsEnabled = false };

        dinner_PartyPanel.Children.Add(dinner_NumberOfPeopleLabel);
        dinner_PartyPanel.Children.Add(dinner_NumberOfPeopleNumericUpDown);
        dinner_PartyPanel.Children.Add(dinner_isFancyCheckBox);
        dinner_PartyPanel.Children.Add(dinner_isHealthyCheckBox);
        dinner_PartyPanel.Children.Add(dinner_costTextBox);

        dinner_isFancyCheckBox.IsChecked = false;
        dinner_isHealthyCheckBox.IsChecked = false;

        dinner_NumberOfPeopleNumericUpDown.ValueChanged += DinnerNumberOfPeopleNumericUpDown_ValueChanged;
        dinner_isFancyCheckBox.IsCheckedChanged += IsDinnerFancyCheckBox_CheckedChanged;
        dinner_isHealthyCheckBox.IsCheckedChanged += IsHealthyCheckBox_CheckedChanged;

        UpdateDinnerPartyCost();

        var dinner_Tab = new TabItem 
        {
            Header = "Dinner Party",
            Content = dinner_PartyPanel,
        };

        // Tab for adding a new birthday party
        var birthday_PartyPanel = new StackPanel()
        {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(20),
                RenderTransform = new ScaleTransform(3, 3),
        };

        var birthday_NumberOfPeopleLabel = new Label { Content = "Number of People:" };
        birthday_NumberOfPeopleNumericUpDown = new NumericUpDown { Minimum = 1, Maximum = 100, Value = 5 };
        birthday_isFancyCheckBox = new CheckBox { Content = "Is Fancy?" };
        birthday_costTextBox = new TextBox { Margin = new Thickness(0, 10, 0, 0), IsEnabled = false };
        var birthday_CakeSizeLabel = new Label { Content = "Cake Size:" };
        birthday_CakeSizeComboBox = new ComboBox { ItemsSource = BirthdayParty.CakeSizeOptions };

        birthday_PartyPanel.Children.Add(birthday_NumberOfPeopleLabel);
        birthday_PartyPanel.Children.Add(birthday_NumberOfPeopleNumericUpDown);
        birthday_PartyPanel.Children.Add(birthday_isFancyCheckBox);
        birthday_PartyPanel.Children.Add(birthday_CakeSizeLabel);
        birthday_PartyPanel.Children.Add(birthday_CakeSizeComboBox);
        birthday_PartyPanel.Children.Add(birthday_costTextBox);

        birthday_isFancyCheckBox.IsChecked = false;
        birthday_CakeSizeComboBox.SelectedIndex = 1;

        birthday_NumberOfPeopleNumericUpDown.ValueChanged += BirthdayNumberOfPeopleNumericUpDown_ValueChanged;
        birthday_isFancyCheckBox.IsCheckedChanged += IsBirthdayFancyCheckBox_CheckedChanged;
        birthday_CakeSizeComboBox.SelectionChanged += CakeSizeComboBox_SelectionChanged;

        UpdateBirthdayPartyCost();

        var birthday_Tab = new TabItem {
            Header = "Birthday Party",
            Content = birthday_PartyPanel
        };

        tabControl.ItemsSource = new TabItem[] {dinner_Tab, birthday_Tab};

        win.Content = tabControl;
        win.Show();
    }

    private void IsHealthyCheckBox_CheckedChanged(object sender, EventArgs e) 
    {
        UpdateDinnerPartyCost();
    }

    private void DinnerNumberOfPeopleNumericUpDown_ValueChanged(object sender, NumericUpDownValueChangedEventArgs e) 
    {
        UpdateDinnerPartyCost();
    }

    private void IsDinnerFancyCheckBox_CheckedChanged(object sender, EventArgs e) 
    {
        UpdateDinnerPartyCost();
    }

    private void UpdateDinnerPartyCost() 
    {
        dinnerParty.NumberOfPeople = (int)dinner_NumberOfPeopleNumericUpDown.Value;
        dinnerParty.IsFancy = dinner_isFancyCheckBox.IsChecked ?? false;
        dinnerParty.IsHealthy = dinner_isHealthyCheckBox.IsChecked ?? false;
        var danish = new CultureInfo("da-DK");
        dinner_costTextBox.Text = $"Current Cost: {dinnerParty.CalculateCost().ToString("c", danish)}";
    }

    private void IsBirthdayFancyCheckBox_CheckedChanged(object sender, EventArgs e) 
    {
        UpdateBirthdayPartyCost();
    }

    private void BirthdayNumberOfPeopleNumericUpDown_ValueChanged(object sender, NumericUpDownValueChangedEventArgs e) 
    {
        UpdateBirthdayPartyCost();
    }

    private void CakeSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) 
    {
        UpdateBirthdayPartyCost();
    }

    private void UpdateBirthdayPartyCost() 
    {
        birthdayParty.NumberOfPeople = (int)birthday_NumberOfPeopleNumericUpDown.Value;
        birthdayParty.IsFancy = birthday_isFancyCheckBox.IsChecked ?? false;
        birthdayParty.CakeSize = (string)birthday_CakeSizeComboBox.SelectedItem;
        var danish = new CultureInfo("da-DK");
        birthday_costTextBox.Text = $"Current Cost: {birthdayParty.CalculateCost().ToString("c", danish)}";
    }


    public Window Win 
    {
        get => win;
    }
}