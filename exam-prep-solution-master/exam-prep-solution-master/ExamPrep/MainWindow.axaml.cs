using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ExamPrep.facade;
using ExamPrep.laundry_facade;

namespace ExamPrep;

public partial class MainWindow : Window
{
    private Facade _facade;
    public MainWindow()
    {
        InitializeComponent();
        _facade = new Facade();
        LaundrySingleton.GetInstance.BuildLaundry();
    }

    private void FacadeHandler(object? sender, RoutedEventArgs _)
    {
        if (!int.TryParse(TextBoxSize.Text, out int size))
        {
            // Not an int
            return;
        }

        if (!int.TryParse(TextBoxMax.Text, out int max))
        {
            // Not an int
            return;
        }
        
        if(Equals(sender, ButtonFill)){
            if (TextBoxSize.Text != null && TextBoxMax.Text!=null)
            {
                TextBoxFacade.Text += "FillArray: [" + string.Join(", ", _facade.FillArray(size, max)!) + "]" + "\n";
            }
        }
        if(Equals(sender, ButtonUnique)){
            if (TextBoxSize.Text != null && TextBoxMax.Text != null) 
            {
                TextBoxFacade.Text += "FillUniqueArray: [" + string.Join(", ", _facade.FillUniqueArray(size, max)!) + "]" + "\n";
            }
        }
        if(Equals(sender, ButtonSum) && TextBoxDivisor.Text != null && int.TryParse(TextBoxDivisor.Text, out int divisor) && _facade.IntArray != null){
            TextBoxFacade.Text += "Divisor of "+divisor+" has a sum of: " + _facade.SumOfDivisors(divisor) + "\n";
        }
    }
    //private LaundrySingleton _selectedShape;
    private void WashHandler(object? sender, RoutedEventArgs e)
    {
        if (!int.TryParse(TextBoxProgram.Text, out int program))
        {
            // Not an int
            Console.WriteLine("Not a number!");
            return;
        }

        List<int> legalPrograms = [1, 2, 3, 4, 5, 6, 7];

        if ((bool)RadioButtonWash6.IsChecked!)
        {
            LabelMachine.Content = (LaundrySingleton.GetInstance.GetMachine(0).GetModel() +":");
            if (legalPrograms.Contains(program))
            {
                TextBoxResult.Text = (LaundrySingleton.GetInstance.GetProgramName(0, program) + "  :  " + $"{LaundrySingleton.GetInstance.GetPrice(0, program):F}");
            }
            else{
                TextBoxResult.Text = ("Program " + program + " does not exist: " + -1);
            }
        }

        if ((bool)RadioButtonWash12.IsChecked!)
        {
            LabelMachine.Content = (LaundrySingleton.GetInstance.GetMachine(1).GetModel() +":");
            if (legalPrograms.Contains(program))
            {
                TextBoxResult.Text = (LaundrySingleton.GetInstance.GetProgramName(1, program) + "  :  " + $"{LaundrySingleton.GetInstance.GetPrice(1, program):F}");
            }
            else{
                TextBoxResult.Text = ("Program " + program + " does not exist: " + -1);
            }
        }

        if ((bool)RadioButtonTumble.IsChecked!)
        {
            LabelMachine.Content = (LaundrySingleton.GetInstance.GetMachine(2).GetModel() +":");
            TextBoxResult.Text = (LaundrySingleton.GetInstance.GetProgramName(2, program) + "  :  " + $"{LaundrySingleton.GetInstance.GetPrice(2, program):F}");
        }
    }

    private void TextBoxProgram_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        WashHandler(sender, new RoutedEventArgs());
    }
}