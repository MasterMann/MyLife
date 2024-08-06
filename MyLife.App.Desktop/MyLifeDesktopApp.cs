using Avalonia.Controls;

using MyLife.App.Shared;
using MyLife.App.Desktop.ViewModels;
using MyLife.App.Desktop.Views;
using MyLife.App.Desktop.Services.Features;


namespace MyLife.App.Desktop;


internal class MyLifeDesktopApp: MyLifeApp
{
	protected override Window GetMainWindow() => new MainWindow()
	{
		DataContext = new MainWindowViewModel()
	};

	protected override void InitPlatform()
	{
		base.InitPlatform();

		PluginManager = new DesktopFeaturePluginManager();
	}
}
