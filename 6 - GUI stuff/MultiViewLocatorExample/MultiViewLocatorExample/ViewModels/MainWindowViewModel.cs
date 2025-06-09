using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MultiViewExample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{

    [ObservableProperty]
    private ViewModelBase currentView;

    private readonly List<ViewModelBase> Views = 
    [
        new FirstViewModel(),
        new SecondViewModel(),
    ];

    public MainWindowViewModel() 
    {
        currentView = Views[0];
    }

    [RelayCommand]
    public void NavigateNextCommand()
    {
        var index = Views.IndexOf(CurrentView);

        if (index < Views.Count - 1) CurrentView = Views[index+1];
    }

    
    [RelayCommand]
    public void NavigatePreviousCommand()
    {
        var index = Views.IndexOf(CurrentView);

        if (index > 0) CurrentView = Views[index-1];
    }

}
