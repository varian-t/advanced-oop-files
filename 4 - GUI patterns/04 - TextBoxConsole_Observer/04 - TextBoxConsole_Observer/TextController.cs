using System;
class TextController
{
    private TextModel model;

    public TextController(TextModel model, List<IView> views)
    {
        this.model = model;
        foreach (var view in views) this.model.AddObserver(view);
    }

    public void Run()
    {
        Console.Clear();
        model.Notify();

        while (true)
        {
            Console.WriteLine("Enter new text (or type 'exit' to quit):");

            string input = Console.ReadLine();

            Console.Clear();
            
            if (input.ToLower() == "exit")
                break;

            if (input.ToLower() == "add")
            {
                this.model.AddObserver(new ReversedTextView());
                continue;
            }
            model.Text = input;
        }
    }
}