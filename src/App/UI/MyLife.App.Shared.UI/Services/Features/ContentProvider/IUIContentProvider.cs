using MyLife.App.Shared.UI.Models.Features.ContentProvider;
using MyLife.App.Shared.UI.Models.Navigation;

namespace MyLife.App.Shared.UI.Services.Features.ContentProvider;

public interface IUIContentProvider
{
	public UIContentProviderInfo ProviderInfo { get; }

	public UIRouteInfo GetRootRoute();
	public UIActivityInfo? GetActivityForRoute(string path);
	public IReadOnlyList<UIRouteInfo> GetEnabledRoutes();
}
