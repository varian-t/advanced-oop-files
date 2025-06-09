using System;

public class DinnerParty 
{
    public Guid Id { get; } = Guid.NewGuid();
    const int CostOfFoodPerPerson = 180;
    public int NumberOfPeople { get; set; }
    public bool IsFancy { get; set; } = false;
    public bool IsHealthy { get; set; } = false;
    public decimal CalculateCost() 
    {
        decimal totalCost = NumberOfPeople * CostOfFoodPerPerson;
        totalCost += NumberOfPeople * (IsHealthy ? 35.00M : 145.00M);
        totalCost += NumberOfPeople * (IsFancy ? 100.00M : 50.00M) + (IsFancy ? 300M : 200M);
        totalCost *= IsHealthy ? 0.95m : 1; // 5% discount
        return totalCost;
    }
    
}