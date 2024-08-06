using System;

using CommunityToolkit.Mvvm.ComponentModel;


namespace MyLife.App.Shared.UI.ViewModels.Components.TabNavigation;


public partial class TabNavigationItemViewModel : ViewModelBase
{
	public event EventHandler<string>? TabRequested;

    [ObservableProperty]
    string _tabId = string.Empty;

	[ObservableProperty]
	string _tabName = string.Empty;

	[ObservableProperty]
	string _tabIconId = string.Empty;

	[ObservableProperty]
	bool _isEnabled = true;

	[ObservableProperty]
	bool _isSelected;

	public void Execute() => this.TabRequested?.Invoke(this, this.TabId);
	public bool CanExecute() => this.IsEnabled;
}
