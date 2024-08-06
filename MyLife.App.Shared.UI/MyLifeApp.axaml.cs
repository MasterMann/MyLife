using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;

using MyLife.App.Plugins.Core.Services;


namespace MyLife.App.Shared;


public partial class MyLifeApp : Application
{
	public static IFeaturePluginManager PluginManager { get; protected set; }

	public override void Initialize() => AvaloniaXamlLoader.Load(this);

	public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);

		this.InitPlatform();

        if (this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
			desktop.MainWindow = this.GetMainWindow();
        }
        else if (this.ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = this.GetInitialView();
        }

        base.OnFrameworkInitializationCompleted();
    }

	protected virtual void InitPlatform() { }

    protected virtual Control GetInitialView() => new TextBlock
    {
        Text = "Please override GetInitialView()/GetMainWindow() in your platform-specific MyLifeApp class.",
        TextWrapping = Avalonia.Media.TextWrapping.Wrap,
        VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
    };

    protected virtual Window GetMainWindow() => new()
    {
        Content = this.GetInitialView()
    };
}
