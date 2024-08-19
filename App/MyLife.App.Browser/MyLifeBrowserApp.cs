using Avalonia.Controls;

using MyLife.App.Android.UI.Mobile.ViewModels;
using MyLife.App.Android.UI.Mobile.Views;
using MyLife.App.Shared.Services.Plugins;
using MyLife.App.Shared.UI;


namespace MyLife.App.Browser;


internal class MyLifeBrowserApp: MyLifeApp
{
	protected override Control GetInitialView() => new MobileMainView()
	{
		DataContext = new MobileMainViewModel(PluginManager)
	};

	protected override void InitPlatform()
	{
		base.InitPlatform();

		PluginManager = new BaseFeaturePluginManager();
	}
}
