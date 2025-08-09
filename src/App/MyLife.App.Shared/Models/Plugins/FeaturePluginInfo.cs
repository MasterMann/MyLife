using MyLife.Common.Models;

namespace MyLife.App.Shared.Models.Plugins;

public partial record FeaturePluginInfo(BuildInformation BuildInfo)
{
	public required string PluginID { get; init; } = string.Empty;
	public string PluginName { get; init; } = string.Empty;
	public string Author { get; init; } = string.Empty;
}
