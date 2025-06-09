using System;
using System.Collections.Generic;

namespace ExamPrep.laundry_facade;

public class WashingMachine : ILaundryMachine
{
    private readonly Dictionary<int, WashProgram> _programs;
    private readonly string _model;

    public WashingMachine(string model)
    {
        _programs = new Dictionary<int, WashProgram>();
        _model = model;
    }

    public void AddProgram(int code, string name, double price) {
        _programs.Add(code, new WashProgram(name, price));
    }
    
    public string GetModel()
    {
        return _model;
    }
    
    public double GetPrice(int prog)
    {
        return _programs.TryGetValue(prog, out var program) ? program.GetPrice() : 0.0;
    }

    public string GetProgramName(int prog) {
        return _programs.TryGetValue(prog, out var program) ? program.GetName() : "Program not found";
    }

    public override string ToString() {
        return GetModel() + "\n" + string.Join(", ", _programs) + "\n";
    }

}