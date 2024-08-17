using MyLife.Utilities;


namespace MyLife.App.Plugins.Core.Models;


public partial record FeaturePluginInfo(BuildInformation BuildInfo)
{
	public string PluginId { get; init; } = string.Empty;
	public string PluginName { get; init; } = string.Empty;
	public string Author { get; init; } = string.Empty;
}
