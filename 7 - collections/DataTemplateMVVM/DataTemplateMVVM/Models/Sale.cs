using System;

namespace DataTemplateMVVM.Models;
public class Sale
{
    public int ProductId { get; set; }
    public int QuantitySold { get; set; }
    public DateTime Date { get; set; }

    public Sale(int productId, int quantitySold, DateTime date)
    {
        ProductId = productId;
        QuantitySold = quantitySold;
        Date = date;
    }
}