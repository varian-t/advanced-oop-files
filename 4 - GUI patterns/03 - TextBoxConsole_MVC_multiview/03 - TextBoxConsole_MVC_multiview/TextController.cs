using System;
class TextController
{
    private TextModel model;
    private List<IView> views;

    public TextController(TextModel model, List<IView> views)
    {
        this.model = model;
        this.views = views;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            
            foreach (var view in views)
            {
                view.Display(model.Text);
            }   
        
            Console.WriteLine("Enter new text (or type 'exit' to quit):");
            
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
                break;

            if (input.ToLower() == "add")
            {
                this.views.Add(new ReversedTextView());
                continue;
            }
            
            model.Text = input;
        }
    }
}