using System.Linq;

using Avalonia;
using Avalonia.Controls;

using MyLife.App.Common.ViewModels.Components.Buttons;

namespace MyLife.App.Common.Views.Components.Buttons;


public partial class FloatingActionButton: UserControl
{
	FloatingActionButtonViewModel _vm;

	string _firstActionIcon = string.Empty;

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
			this._vm = vm;

			this.UpdateFirstActionIconCache();
			this.UpdateMainIcon(true);
			this.PointerEntered += this.OnPointerEntered;
			this.PointerExited += this.OnPointerExited;
		}
	}

	void OnPointerEntered(object? sender, Avalonia.Input.PointerEventArgs e)
	{
		this.UpdateMainIcon();
		this.ShowActions();

		this.mainActionButtonTooltip.IsVisible = true;
	}
	void OnPointerExited(object? sender, Avalonia.Input.PointerEventArgs e)
	{
		this.UpdateMainIcon(true);
		this.HideActions();

		this.mainActionButtonTooltip.IsVisible = false;
	}

	void HideActions()
	{
		this.extraActionsList.IsVisible = false;
	}
	void ShowActions()
	{
		this.extraActionsList.IsVisible = true;
	}

	void UpdateMainIcon(bool useInitial = false)
	{
		this._vm.UpdateActionIcon(0, useInitial
			? this._vm.InitialIcon
			: this._firstActionIcon
		);
	}

	void UpdateFirstActionIconCache()
	{
		this._firstActionIcon = this._vm.Actions.FirstOrDefault()?.IconId ?? string.Empty;
	}
}