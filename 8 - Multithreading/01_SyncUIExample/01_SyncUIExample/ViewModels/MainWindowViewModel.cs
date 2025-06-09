using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia.Controls;
using Avalonia.Threading;
using System;
using System.Threading;

namespace SyncUIExample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string? result = "Nothing";

    [ObservableProperty]
    private bool? enabled = true;

    [RelayCommand]
    private void DoSomething()
    {
        Result = string.Empty;
        foreach(char c in "Something")
        {
            Result += c;
        }
        Result = "Nothing";
    }

}