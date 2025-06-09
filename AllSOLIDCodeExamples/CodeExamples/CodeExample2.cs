public class DiscountCalculator {
    public double CalculateDiscount(string customerType, double amount) {
        if (customerType == "Regular") {
            return amount * 0.1;
        } else if (customerType == "Premium") {
            return amount * 0.2;
        } else if (customerType == "VIP") {
            return 0;
        } else {
            return amount;
        }
    }
}