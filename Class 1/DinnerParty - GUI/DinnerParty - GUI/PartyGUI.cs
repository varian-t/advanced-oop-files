using System;
using System.Reflection.Metadata.Ecma335;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.PropertyStore;
using Avalonia.Layout;

// We need this namespace to use the Brushes class, which contains
// convenient color definitions.

internal class PartyGUI
{
    DinnerParty party;
    public Window win;

    private TextBox textCost;
    private CheckBox healthyCheckbox;
    private CheckBox fancyCheckbox;
    private NumericUpDown numeric;


    public PartyGUI()
    {
        // Note that it is simple and intuitive to set the dimensions.

        win = new Window
        {
            Title = "Dinnerparty",
            Height = 500, 
            Width = 500, 
            RenderTransform = new ScaleTransform(3, 3),
        };

        party = new() {NumberOfPeople = 5};

        // The only content for this window will be a StackPanel. This
        // control can contain any number of other controls. All of its
        // contents will appear in a vertical layout, from top to bottom,
        // in the order in which those contents were added.

        var stack = new StackPanel {
            Orientation = Orientation.Vertical,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            Margin = new Thickness(20),
        };

        var labelTop = new Label {
            Content = "Number of People",
        };

        numeric = new NumericUpDown {
            Value = 5,
            Increment = 1, 
            Minimum = 0,
        };

        fancyCheckbox = new CheckBox {
            Content = "Fancy Decorations",
        };

        healthyCheckbox = new CheckBox {
            Content = "Healthy Option",
          };

        textCost = new TextBox {
            Text = "",
            IsEnabled = false,
        };

        fancyCheckbox.IsChecked = true;

        party.CalculateCostOfDecorations(fancyCheckbox.IsChecked.Value);
        party.SetHealthyOption(healthyCheckbox.IsChecked.Value);
        DisplayDinnerPartyCost();

        fancyCheckbox.IsCheckedChanged += fancyBoxCheckedChanged;
        healthyCheckbox.IsCheckedChanged += healthyBoxCheckedChanged;
        numeric.ValueChanged += numericUpDownValueChanged;
     
        // Add the labels to the StackPanel. They will appear, top down, in
        // the order they were added.
        stack.Children.Add(labelTop);
        stack.Children.Add(numeric);
        stack.Children.Add(fancyCheckbox);
        stack.Children.Add(healthyCheckbox);
        stack.Children.Add(textCost);

        // Make the StackPanel the window's content. Note that it doesn't
        // matter if you add content to the stack or the window first.
        win.Content = stack;
        win.Show();
    }

    void fancyBoxCheckedChanged(object s, EventArgs   e) {
        party.CalculateCostOfDecorations(fancyCheckbox.IsChecked.Value);
        DisplayDinnerPartyCost();
    }

    void healthyBoxCheckedChanged(object s, EventArgs   e) {
        party.SetHealthyOption(healthyCheckbox.IsChecked.Value);
        DisplayDinnerPartyCost();
    }
    
    void numericUpDownValueChanged(object s, EventArgs   e) {
        party.NumberOfPeople = (int)numeric.Value;
        DisplayDinnerPartyCost();
    }

    void DisplayDinnerPartyCost() {
        decimal Cost = party.CalculateCost(healthyCheckbox.IsChecked.Value);
        textCost.Text = Cost.ToString("c");
    }
}