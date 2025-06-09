public class Invoice
{
    public int InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal InvoiceAmount { get; set; }

    public decimal CalculateTax() {
        return InvoiceAmount * 0.2m;
    }

    public void PrintInvoice() {
        Console.WriteLine($"Invoice Number: {InvoiceNumber}");
        Console.WriteLine($"Invoice Date: {InvoiceDate}");
        Console.WriteLine($"Invoice Amount: {InvoiceAmount}");
        Console.WriteLine($"Tax: {CalculateTax()}");
    }

    public void SaveToDatabase() {
        Console.WriteLine("Invoice saved to database");
    }
}