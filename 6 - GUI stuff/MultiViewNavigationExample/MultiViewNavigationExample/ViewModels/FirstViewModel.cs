using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MultiViewExample.ViewModels;

public partial class FirstViewModel : ViewModelBase
{
    [ObservableProperty]
    private string firstViewText = "First!";
}
