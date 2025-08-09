using CommunityToolkit.Mvvm.Input;

using MyLife.App.Shared.UI.Models.Navigation;
using MyLife.App.Shared.UI.Services.Navigation;
using MyLife.App.Shared.ViewModels;

namespace MyLife.App.Shared.UI.ViewModels.Navigation;

public abstract partial class ActivityViewModel: ViewModelBase
{
	public UIActivityInfo Activity => this.Router.CurrentRoute.Activity;
	protected IUIRouter Router { get; private init; }
	protected string CurrentPath => this.Router.CurrentRoute.Path;

	private protected ActivityViewModel()
	{
		// TODO: Use a dummy IUIRouter and UIActivityInfo
	}

	protected ActivityViewModel(IUIRouter router) => this.Router = router;

	// TODO: Add support for query params and passing state
	[RelayCommand]
	void NavigateTo(string? path)
	{
		if (string.IsNullOrWhiteSpace(path))
			return;

		this.Router.Navigate(path);
	}

	[RelayCommand]
	void Forward() => this.Router.NavigateForward();

	[RelayCommand]
	void Back() => this.Router.NavigateBack();
}
