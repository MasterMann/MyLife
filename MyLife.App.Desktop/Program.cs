using System;
using System.Runtime.CompilerServices;

using Avalonia;

using MyLife.App.Shared;


[assembly: InternalsVisibleTo("MyLife.App.Shared.UI.DesignerStub")]


namespace MyLife.App.Desktop;


class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<MyLifeDesktopApp>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();

}
