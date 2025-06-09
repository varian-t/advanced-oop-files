using System;
using System.Collections.Generic;

public class BirthdayParty 
{
    public Guid Id {get;} = Guid.NewGuid();
    public static List<string> CakeSizeOptions { get; } = 
        new List<string> { "Small", "Medium", "Large" };
    const int CostOfFoodPerPerson = 180;
    public int NumberOfPeople { get; set; }
    public bool IsFancy { get; set; }
    public string CakeSize { get; set; }


    public decimal CalculateCost()
    {   
        decimal totalCost = NumberOfPeople * CostOfFoodPerPerson;
        totalCost += NumberOfPeople * (IsFancy ? 100.00M : 50.00M) + (IsFancy ? 300M : 200M);
        totalCost += CakeSize switch {
            "Small" => 112M,
            "Medium" => 210M,
            "Large" => 350M,
            _ => 0
        };
        return totalCost;
    }
}