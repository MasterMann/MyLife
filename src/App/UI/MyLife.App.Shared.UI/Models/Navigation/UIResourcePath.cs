namespace MyLife.App.Shared.UI.Models.Navigation;

public record UIResourcePath
{
	public required string SourceAssembly { get; init; }
	public required string Namespace { get; init; }
	public required string ResourceName { get; init; }
}
