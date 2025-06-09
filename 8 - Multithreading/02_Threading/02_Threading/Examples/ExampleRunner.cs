namespace Threading.Examples;

class ExampleRunner
{
    public List<IExample> Examples { get; set; }

    public ExampleRunner(List<IExample> examples)
    {
        Examples = examples;
    }

    public bool RunExample(string input)
    {
        if (int.TryParse(input, out int index) && index < Examples.Count)
        {
            Examples[index].Run();
            return true;
        }
        return false;
    }

}