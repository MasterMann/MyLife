using MyLife.App.Shared.UI.Models.Navigation;

namespace MyLife.App.Shared.UI.Services.Navigation;

public interface IUINavigationManager
{
	public List<UIRouteInfo> ManualRoutes { get; init; }

	public IReadOnlyList<UIRouteInfo> GetEnabledRoutes();
}
