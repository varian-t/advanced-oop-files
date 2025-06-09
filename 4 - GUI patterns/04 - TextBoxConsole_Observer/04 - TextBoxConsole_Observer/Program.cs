using System;

class Program
{
    static void Main()
    {
        TextModel model = new TextModel();
        List<IView> views = new List<IView> { new NormalTextView(), new ReversedTextView(), new UpperCaseTextView() };
        TextController controller = new TextController(model, views);
        controller.Run();
    }
}

