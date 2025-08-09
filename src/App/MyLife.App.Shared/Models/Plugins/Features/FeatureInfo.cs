namespace MyLife.App.Shared.Models.Plugins.Features;

public record FeatureInfo
{
	public required string FeatureID { get; init; }
	public required string FeatureName { get; init; }
	public required FeatureType FeatureType { get; init; }
	public bool IsEnabled { get; init; } = true;
}
