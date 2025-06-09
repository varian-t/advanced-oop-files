using System;

// Main Program
class Program
{
    static void Main()
    {
        TextModel model = new TextModel();
        TextView view = new TextView();
        TextController controller = new TextController(model, view);
        controller.Run();
    }
}
