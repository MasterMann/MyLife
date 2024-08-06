using MyLife.App.Android.UI.Mobile.Models.Containers.Tabs;
using MyLife.App.Android.UI.Mobile.ViewModels;
using MyLife.App.Android.UI.Mobile.ViewModels.Content.Todo;
using MyLife.App.Shared.ViewModels;


namespace MyLife.App.Desktop.ViewModels;


public partial class MainWindowViewModel : ViewModelBase
{
	public MobileMainViewModel Content { get; set; } = new()
	{
		BottomNav = new()
		{
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
			],
			NavItems =
			[
				new(){ TabId = "todo", TabIconId = "FormatListChecks", TabName = "TODO" },
				new(){ TabId = "notes", TabIconId = "Note", TabName = "Notes" },
				new(){ TabId = "home", TabIconId = "Home", TabName = "Home" },
				new(){ TabId = "services", TabIconId = "ViewGridPlus", TabName = "Services" },
				new(){ TabId = "stats", TabIconId = "Abacus", TabName = "Statistics" }
			]
		}
	};
}
