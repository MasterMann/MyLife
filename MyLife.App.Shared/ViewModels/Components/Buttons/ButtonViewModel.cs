using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace MyLife.App.Shared.ViewModels.Components.Buttons;


public partial class ButtonViewModel : ViewModelBase
{
	[ObservableProperty]
	string _id = string.Empty;

	[ObservableProperty]
	int _elevation = 3;

	[ObservableProperty]
	bool _isEnabled = true;

	[ObservableProperty]
	string _label = string.Empty;

	[ObservableProperty]
	IRelayCommand<object?>? _command;

	[ObservableProperty]
	object? _commandParameter;

	public void Execute() => this.Command?.Execute(this.CommandParameter);
	public bool CanExecute() => this.IsEnabled;
}
