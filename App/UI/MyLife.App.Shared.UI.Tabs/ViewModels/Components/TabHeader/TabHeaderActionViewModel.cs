using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MyLife.App.Shared.Models.Plugins.Features.TabContent;
using MyLife.App.Shared.ViewModels;


namespace MyLife.App.Shared.UI.Tabs.ViewModels.Components.TabHeader;


public partial class TabHeaderActionViewModel: ViewModelBase
{
	public TabActionPriority Priority { get; init; }

	[ObservableProperty]
	string _actionId;

	[ObservableProperty]
	string _displayName;

	[ObservableProperty]
	string _iconId;

	[ObservableProperty]
	bool _isEnabled;

	[ObservableProperty]
	IRelayCommand<object?>? _triggerCommand;

	public TabHeaderActionViewModel(TabHeaderAction action)
	{
		this.Priority = action.Priority;
		this._actionId = action.ActionId;
		this._displayName = action.DisplayName;
		this._iconId = action.IconId;
		this._isEnabled = action.IsEnabled;
		this._triggerCommand = action.TriggerCommand;
	}
}
