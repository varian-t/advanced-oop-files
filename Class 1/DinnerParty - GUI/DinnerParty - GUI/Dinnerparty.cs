internal class DinnerParty {
    const int CostOfFoodPerPerson = 180;
    public int NumberOfPeople;
    public decimal CostOfBeveragesPerPerson;
    public decimal CostOfDecorations = 0;

    public void SetHealthyOption(bool healthyOption) {
        if (healthyOption) {
            CostOfBeveragesPerPerson = 35.00M;
        } else {
            CostOfBeveragesPerPerson = 145.00M;
        }
    }
    
    public void CalculateCostOfDecorations(bool fancy) {
        if (fancy)
        {
            CostOfDecorations = (NumberOfPeople * 100.00M) + 300M;
        } else {
            CostOfDecorations = (NumberOfPeople * 50.00M) + 200M;
        };
    }
    
    public decimal CalculateCost(bool healthyOption) {
        decimal totalCost = CostOfDecorations + ((CostOfBeveragesPerPerson + CostOfFoodPerPerson) * NumberOfPeople);
        if (healthyOption) {
            return totalCost * .95M;
        } else {
            return totalCost;
        }
    }
}