using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace DataTemplateMVVM.ViewModels;

public partial class SalesReportItem : ObservableObject
{
    [ObservableProperty]
    private string? name;

    [ObservableProperty]
    private string? category;

    [ObservableProperty]
    private decimal price;

    [ObservableProperty]
    private int quantitySold;

    [ObservableProperty]
    private decimal totalRevenue;

    [ObservableProperty]
    private DateTime date;
}
