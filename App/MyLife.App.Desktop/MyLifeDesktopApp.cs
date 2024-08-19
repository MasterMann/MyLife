using Avalonia.Controls;

using MyLife.App.Desktop.ViewModels;
using MyLife.App.Desktop.Views;
using MyLife.App.Shared.Services.Plugins;
using MyLife.App.Shared.UI;


namespace MyLife.App.Desktop;


internal class MyLifeDesktopApp: MyLifeApp
{
	protected override Window GetMainWindow() => new MainWindow()
	{
		DataContext = new MainWindowViewModel(PluginManager)
	};

	protected override void InitPlatform()
	{
		base.InitPlatform();

		PluginManager = new BaseFeaturePluginManager();
	}
}
