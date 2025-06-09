public interface IWorker
{
    void Work();
    void Eat();
    void TakeBreak();
}

public class OfficeWorker : IWorker 
{
    public void Work() => Console.WriteLine("Office worker is working");

    public void Eat() =>  Console.WriteLine("Office worker is eating");

    public void TakeBreak() => Console.WriteLine("Office worker is taking a break");
}

public class RobotWorker : IWorker
{
    public void Work() => Console.WriteLine("Robot worker is working");

    public void Eat() => throw new NotImplementedException();

    public void TakeBreak() => throw new NotImplementedException();
}