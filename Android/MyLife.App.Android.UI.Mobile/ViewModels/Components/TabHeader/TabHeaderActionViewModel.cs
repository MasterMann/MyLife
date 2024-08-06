using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MyLife.App.Android.UI.Mobile.Models.Containers.Tabs;
using MyLife.App.Shared.ViewModels;


namespace MyLife.App.Android.UI.Mobile.ViewModels.Components.TabHeader;


public partial class TabHeaderActionViewModel: ViewModelBase
{
	public TabActionPriority Priority { get; init; }

	[ObservableProperty]
	string _actionId = Guid.NewGuid().ToString();

	[ObservableProperty]
	string _displayName = "[Unknown]";

	[ObservableProperty]
	string _iconId = string.Empty;

	[ObservableProperty]
	bool _isEnabled = true;

	[ObservableProperty]
	IRelayCommand<object?>? _triggerCommand;
}
