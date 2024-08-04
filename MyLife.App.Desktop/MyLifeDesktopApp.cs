using Avalonia.Controls;

using MyLife.App.Common;
using MyLife.App.Desktop.ViewModels;
using MyLife.App.Desktop.Views;


namespace MyLife.App.Desktop;


internal class MyLifeDesktopApp: MyLifeApp
{
	protected override Window GetMainWindow() => new MainWindow()
	{
		DataContext = new MainWindowViewModel()
	};
}
