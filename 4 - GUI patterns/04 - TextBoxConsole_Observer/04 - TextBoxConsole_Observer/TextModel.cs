
// Model
class TextModel: IObservable
{
    public List<IObserver> Observers { get; set; } = new List<IObserver>();
    public string Text 
    { 
        get;
        set
        {
            field = value;
            Notify();
        }
    } = "Default text";

    public void AddObserver(IObserver observer)
    {
        Observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        Observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in Observers)
        {
            observer.Update(Text);
        }
    }
}
