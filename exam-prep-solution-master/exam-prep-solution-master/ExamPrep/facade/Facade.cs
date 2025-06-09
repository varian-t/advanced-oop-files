using System;

namespace ExamPrep.facade;

public class Facade
{
    private Random _random;

    public int[]? IntArray { get; private set; }

    public Facade()
    {
        IntArray = null;
        _random = new Random();
    }

    public int[]? FillArray(int size, int max)
    {
        IntArray = new int[size];
        for (int i = 0; i < IntArray.Length; i++)
        {
            IntArray[i] = _random.Next(max);
        }

        return IntArray;
    }

    public int SumOfDivisors(int divisor)
    {
        int sum = 0;
        foreach (var val in IntArray!)
        {
            if(val % divisor == 0){
                sum += val;
            }
        }
        return sum;
    }

    private bool Contains(int x, int beforeIndex){
        for (int i = 0; i < beforeIndex; i++) {
            if(IntArray![i] == x){
                return true;
            }
        }
        return false;
    }

    public int[]? FillUniqueArray(int size, int max)
    {
        if (!(size <= max))
        {
            throw new ArgumentException("Size is greater than max!");
        }
        IntArray = new int[size];
        for (int i = 0; i < IntArray.Length; i++)
        {
            while (true)
            {
                int randomInt = _random.Next(0, max);
                if(!Contains(randomInt, i)){
                    IntArray[i] = randomInt;
                    break;
                }
            }
        }
        Array.Sort(IntArray);
        return IntArray;
    }

    public static void TestFacadeOutput()
    {
        Facade facade = new Facade();
        int divisor = 3;
        Console.WriteLine("FillArray: " + string.Join(", ", facade.FillArray(20, 10)!));
        Console.WriteLine("Divisor of "+divisor+" has a sum of: " + string.Join(", ", facade.SumOfDivisors(divisor)));
        Console.WriteLine("FillUniqueArray: " + string.Join(", ", facade.FillUniqueArray(20, 30)!));
    }
}