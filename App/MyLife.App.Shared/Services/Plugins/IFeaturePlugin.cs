using MyLife.App.Shared.Models.Plugins;


namespace MyLife.App.Shared.Services.Plugins;


public interface IFeaturePlugin
{
	public FeaturePluginInfo PluginInfo { get; }
	public IReadOnlyList<Type> Features { get; }
}
