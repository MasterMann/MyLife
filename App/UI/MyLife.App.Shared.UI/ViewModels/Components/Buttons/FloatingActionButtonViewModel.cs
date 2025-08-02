using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyLife.App.Shared.UI.ViewModels.Components.Buttons;

public partial class FloatingActionButtonViewModel : ButtonViewModel
{
	internal IconButtonViewModel PrimaryDefaultAction => new()
	{
		Id = $"{this.Id}-primary",
		IconId = this.InitialIcon,
		IsEnabled = this.IsEnabled,
		Command = this.ShowActionsCommand
	};

	public IconButtonViewModel PrimaryAction => this.AreActionsVisible
		? this.Actions[0]
		: this.PrimaryDefaultAction;

	[ObservableProperty]
	ObservableCollection<IconButtonViewModel> _actions = new();

	[ObservableProperty]
	string _initialIcon = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(this.PrimaryAction))]
	bool _areActionsVisible = false;

	[RelayCommand]
	public void ShowActions(object? param = null)
		=> this.AreActionsVisible = true;

	[RelayCommand]
	public void HideActions(object? param = null)
		=> this.AreActionsVisible = false;
}
