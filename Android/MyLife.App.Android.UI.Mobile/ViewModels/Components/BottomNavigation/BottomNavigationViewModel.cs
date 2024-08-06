using System.Collections.ObjectModel;
using System.Collections.Specialized;

using CommunityToolkit.Mvvm.ComponentModel;

using MyLife.App.Android.UI.Mobile.ViewModels.Components.Containers.Tabs;
using MyLife.App.Shared.ViewModels;


namespace MyLife.App.Android.UI.Mobile.ViewModels.Components.BottomNavigation;


public partial class BottomNavigationViewModel : ViewModelBase
{
	[ObservableProperty]
	ObservableCollection<TabContainerViewModel> _tabs = [];

	[ObservableProperty]
	ObservableCollection<BottomNavigationItemViewModel> _navItems = [];

	[ObservableProperty]
	string _selectedTabId = string.Empty;

	public string DefaultTabId { get; set; } = string.Empty;

	public BottomNavigationViewModel()
	{
		this.NavItems.CollectionChanged += this.NavItemsListChanged;
	}

	void NavItemsListChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (this.NavItems.Count == 0) return;

		switch (e.Action)
		{
			case NotifyCollectionChangedAction.Add:
			{
				foreach (var item in e.NewItems)
				{
					var navItem = (BottomNavigationItemViewModel)item;

					navItem.TabRequested += this.OnTabRequested;
				}

				break;
			}
			case NotifyCollectionChangedAction.Remove:
			{
				foreach (var item in e.OldItems)
				{
					var navItem = (BottomNavigationItemViewModel)item;

					navItem.TabRequested -= this.OnTabRequested;
				}

				break;
			}
			case NotifyCollectionChangedAction.Replace:
			{
				foreach (var item in e.OldItems)
				{
					var navItem = (BottomNavigationItemViewModel)item;

					navItem.TabRequested -= this.OnTabRequested;
				}
				foreach (var item in e.NewItems)
				{
					var navItem = (BottomNavigationItemViewModel)item;

					navItem.TabRequested += this.OnTabRequested;
				}

				break;
			}
		}

		if (this.DefaultTabId.Length == 0)
		{
			this.DefaultTabId = this.NavItems.FirstOrDefault()!.TabId;
		}
		else
		{
			var navItem = this.NavItems.FirstOrDefault(item => item.TabId == this.DefaultTabId);
			if (navItem == null)
			{
				this.DefaultTabId = this.NavItems.FirstOrDefault()!.TabId;
			}
		}

		if (this.SelectedTabId.Length == 0)
		{
			this.SetActiveTab(this.DefaultTabId);
		}
		else
		{
			var selectedNavItem = this.NavItems.FirstOrDefault(item => item.TabId == this.SelectedTabId);
			if (selectedNavItem == null)
			{
				this.SetActiveTab(this.DefaultTabId);
			}
			else this.SetActiveTab(this.SelectedTabId);
		}
	}

	void OnTabRequested(object? sender, string tabId) => this.SetActiveTab(tabId);

	public void SetActiveTab(string tabId)
	{
		this.SelectedTabId = tabId;

		var foundNavItem = this.NavItems.FirstOrDefault(item => item.TabId == this.SelectedTabId);
		if (foundNavItem != null)
		{
			foundNavItem.IsSelected = true;
		}
		
		foreach (var navItem in this.NavItems.Where(item => item.TabId != this.SelectedTabId))
		{
			navItem.IsSelected = false;
		}
	}
}
