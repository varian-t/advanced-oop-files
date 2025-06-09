using System;

namespace Polymorphism.Polymorphism;

public sealed class ShapeFacade
{
    // Creating the Singleton
    private static readonly Lazy<ShapeFacade> Lazy = new(() => new ShapeFacade());
    
    public static ShapeFacade GetInstance => Lazy.Value;

    private ShapeFacade()
    {
    }
    
    public enum Shapes
    {
        Ellipse,
        Rectangle,
        Circle,
        Square
    };

    public string GetShapeInfo(Shapes shape, params double[] p)
    {
        throw new NotImplementedException("Not implemented!");
    }
}