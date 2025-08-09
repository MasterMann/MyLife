namespace MyLife.App.Shared.UI.Models.Navigation;

public record UIActivityInfo
{
	public required string ActivityID { get; init; }
	public required string ActivityName { get; init; }
	public UIResourcePath? IconResource { get; init; }
	public required UIResourcePath ViewModelResource { get; init; }
}
