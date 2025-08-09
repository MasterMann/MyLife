using Avalonia.Controls;

using CommunityToolkit.Mvvm.Input;

using MyLife.App.Shared.UI.ViewModels.Components.Buttons;

namespace MyLife.App.Shared.UI.Views.Components.Buttons;

public partial class FloatingActionButton: UserControl
{
	FloatingActionButtonViewModel? _vm;

	public FloatingActionButton()
	{
		this.InitializeComponent();

		this.Loaded += this.OnLoaded;
	}

	void OnLoaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		var vm = (FloatingActionButtonViewModel?)this.DataContext;

		if (vm != null)
		{
			this.AssignDismissOnActionClick(vm);

			this._vm = vm;

			this.PointerEntered += this.OnPointerEntered;
			this.PointerExited += this.OnPointerExited;
		}
	}

	void AssignDismissOnActionClick(FloatingActionButtonViewModel vm)
	{
		if (vm is null) 
			return;

		foreach (var action in vm.Actions)
		{
			action.Clicked += delegate { this.HideActions(); };
		}
	}

	[RelayCommand]
	void ActionButtonPressed(object? param)
	{
		if (this._vm is null)
			return;

		this._vm.AreActionsVisible = !this._vm.AreActionsVisible;
	}

	void OnPointerEntered(object? sender, Avalonia.Input.PointerEventArgs e)
		=> this.ShowActions();
	void OnPointerExited(object? sender, Avalonia.Input.PointerEventArgs e)
		=> this.HideActions();

	void HideActions()
		=> this._vm?.HideActions();
	void ShowActions()
		=> this._vm?.ShowActions();
}