namespace MyLife.App.Shared.UI.Models.Navigation;

public record UIRouterState
{
	public UIRouteInfo Route { get; internal init; }
	public IReadOnlyDictionary<string, IEnumerable<string>> Query { get; internal init; } = new Dictionary<string, IEnumerable<string>>();
	public string? SerializedState { get; internal init; }
}
