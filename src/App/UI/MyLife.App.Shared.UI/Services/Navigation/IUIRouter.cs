using MyLife.App.Shared.UI.Models.Navigation;

namespace MyLife.App.Shared.UI.Services.Navigation;

public interface IUIRouter
{
	public delegate void OnNavigatingHandler(IUIRouter router, UIRouterState prevState, UIRouterState nextState);
	public event OnNavigatingHandler? Navigating;

	public delegate void OnNavigatedHandler(IUIRouter router, UIRouterState prevState, UIRouterState currentState);
	public event OnNavigatedHandler? Navigated;

	public UIRouterState CurrentState { get; }
	public UIRouteInfo CurrentRoute => this.CurrentState.Route;

	// TODO: Figure out if necessary
	public IReadOnlySet<UIRouterState> History { get; }

	public IReadOnlySet<UIRouterState> Stack { get; }

	public void Navigate(string path, IReadOnlyDictionary<string, IEnumerable<string>>? query = null);
	public void NavigateForward();
	public void NavigateBack();

	public UIRouteInfo? GetRouteForPath(string path);

	public void SetCurrentState(string? serializedState);		// => this.CurrentState = this.CurrentState with { SerializedState = serializedState };
}
