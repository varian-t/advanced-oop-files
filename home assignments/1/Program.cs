using Avalonia;
using System;

namespace B2ImgEditor; // Give a meaningful namespace

class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        // Start Avalonia application
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
