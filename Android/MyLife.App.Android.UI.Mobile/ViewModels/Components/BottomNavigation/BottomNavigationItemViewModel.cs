using CommunityToolkit.Mvvm.ComponentModel;

using MyLife.App.Common.ViewModels;


namespace MyLife.App.Android.UI.Mobile.ViewModels.Components.BottomNavigation;


public partial class BottomNavigationItemViewModel : ViewModelBase
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
