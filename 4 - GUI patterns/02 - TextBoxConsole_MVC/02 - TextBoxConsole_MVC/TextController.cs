using System;
class TextController
{
    private TextModel model;
    private NormalTextView view;
    private TextViewUpcase;

    public TextController(TextModel model, TextView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Run()
    {
        while (true)
        {
            view.Display(model.Text);
            string input = Console.ReadLine();
            
            if (input.ToLower() == "exit")
                break;
            
            model.Text = input;
        }
    }
}