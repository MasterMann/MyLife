using Avalonia.Controls;

using Microsoft.Maui.Devices;

using MyLife.App.Shared;
using MyLife.App.Android.UI.Watch.Views;
using MyLife.App.Android.UI.Mobile.Views;
using MyLife.App.Android.UI.Mobile.ViewModels;
using MyLife.App.Android.UI.Watch.ViewModels;
using MyLife.App.Android.UI.Mobile.ViewModels.Content.Todo;
using MyLife.App.Android.UI.Mobile.Models.Containers.Tabs;


namespace MyLife.App.Android;


public class MyLifeAndroidApp: MyLifeApp
{
	protected bool IsWatchDevice { get; private set; }

	protected override void InitPlatform()
	{
		base.InitPlatform();

		this.IsWatchDevice = DeviceInfo.Idiom == DeviceIdiom.Watch;
	}

	protected Control GetInitialWatchView() => new WatchMainView
	{
		DataContext = new WatchMainViewModel()
		{
			Buttons =
			{
				new() { IconId = "FormatListChecks", Id = "todo", Label = "TODO" },
				new() { IconId = "Note", Id = "notes", Label = "Notes" },
				new() { IconId = "ViewGridPlus", Id = "services", Label = "Services" },
				new() { IconId = "Cog", Id = "settings", Label = "Settings" },
			}
		}
	};
	protected Control GetInitialMobileView() => new MobileMainView
	{
		DataContext = new MobileMainViewModel()
		{
			BottomNav = new()
			{
				NavItems =
				[
					new(){ TabId = "todo", TabIconId = "FormatListChecks", TabName = "TODO" },
					new(){ TabId = "notes", TabIconId = "Note", TabName = "Notes" },
					new(){ TabId = "home", TabIconId = "Home", TabName = "Home" },
					new(){ TabId = "services", TabIconId = "ViewGridPlus", TabName = "Services" },
					new(){ TabId = "spending", TabIconId = "Abacus", TabName = "Spending" }
				],
				Tabs =
				[
					new()
					{
						TabId = "todo",
						TabName = "TODO",
						Content = new TodoTabContentViewModel(),
						HeaderConfig = new()
						{
							TitleLabel = "TODO",
							TitleContent = new TodoListSelectorViewModel(),
							Actions =
							[
								new()
								{
									ActionId = "sync",
									DisplayName = "Sync to server",
									IconId = "CloudArrowUp",
									IsEnabled = true,
									Priority = TabActionPriority.DEFAULT
								}
							]
						}
					}
				]
			}
		}
	};

	protected override Control GetInitialView()
		=> this.IsWatchDevice
			? this.GetInitialWatchView()
			: this.GetInitialMobileView();
}
