using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MultiViewExample.ViewModels;

public partial class SecondViewModel : ViewModelBase
{
    [ObservableProperty]
    private string secondViewText = "Second!";
}
