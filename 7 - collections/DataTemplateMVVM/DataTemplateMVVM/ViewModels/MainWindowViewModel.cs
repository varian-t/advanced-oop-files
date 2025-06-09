using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using DataTemplateMVVM.Models;

namespace DataTemplateMVVM.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    List<SalesReportItem> salesReport = [];

    List<Product> Products = 
    [
        new Product { Id = 1, Name = "Laptop", Price = 899.99m, Category = "Electronics" },
        new Product { Id = 2, Name = "Smartphone", Price = 599.99m, Category = "Electronics" },
        new Product { Id = 3, Name = "Tablet", Price = 499.99m, Category = "Electronics" },
        new Product { Id = 4, Name = "Shoes", Price = 59.99m, Category = "Apparel" }
    ];

    List<Sale> Sales = 
    [
        new Sale(1, 5, new DateTime(2024, 3, 1)),  // 5 Laptops sold
        new Sale(2, 10, new DateTime(2024, 3, 2)), // 10 Smartphones sold
        new Sale(3, 7, new DateTime(2024, 3, 3)),  // 7 Tablets sold
        new Sale(1, 3, new DateTime(2024, 3, 4)),  // 3 more Laptops sold
        new Sale(4, 20, new DateTime(2024, 3, 5))  // 20 Shoes sold
    ];

    public MainWindowViewModel()
    {
        SalesReport = Sales!.Join(Products!,
            sale => sale.ProductId,  
            product => product.Id, 
            (sale, product) => new SalesReportItem
            {
                Name = product.Name,
                Category = product.Category,
                Price = product.Price,
                QuantitySold = sale.QuantitySold,
                TotalRevenue = sale.QuantitySold * product.Price,
                Date = sale.Date
            }).ToList();
    }
}
