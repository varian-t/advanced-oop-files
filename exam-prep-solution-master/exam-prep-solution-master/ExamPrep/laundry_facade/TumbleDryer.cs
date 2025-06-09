using System;

namespace ExamPrep.laundry_facade;

public class TumbleDryer : ILaundryMachine
{
    
    private double _pricePerMinute;
    private readonly string _model;

    public TumbleDryer(string model)
    {
        _model = model;
    }

    public void SetPrice(double pricePerMinute)
    {
        _pricePerMinute = pricePerMinute;
    }


    public override string ToString() {
        return GetModel() + " Minute price: " + _pricePerMinute + "\n";
    }


    public string GetModel()
    {
        return _model;
    }

    public double GetPrice(int prog)
    {
        return _pricePerMinute * prog;
    }

    public string GetProgramName(int prog)
    {
        return "Drying for " + prog + " minutes";
    }
}