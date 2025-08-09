namespace MyLife.App.Shared.UI.Models.Navigation;

public record UIRouteInfo
{
	public required string Path { get; init; }
	public required UIActivityInfo Activity { get; init; }
	public bool IsEnabled { get; init; } = true;
}
