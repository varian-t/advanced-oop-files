using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia;
using Avalonia.Interactivity;
using MultiViewExample.Views;
using Avalonia.Controls;

namespace MultiViewExample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{   
    [ObservableProperty]
    private UserControl currentView;

    [ObservableProperty]
    private bool isPaneOpen = false;

    private FirstView _firstView = new FirstView{DataContext=new FirstViewModel()};
    private SecondView _secondView = new SecondView{DataContext=new SecondViewModel()};

    public MainWindowViewModel() 
    {
        CurrentView = _firstView;
    }

    [RelayCommand]
    public void NavigateToFirstView()
    {
        CurrentView = _firstView;
    }

    [RelayCommand]
    public void NavigateToSecondView()
    {
        CurrentView = _secondView;
    }
}
