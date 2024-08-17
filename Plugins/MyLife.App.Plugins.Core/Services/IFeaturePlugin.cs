using MyLife.App.Plugins.Core.Models;


namespace MyLife.App.Plugins.Core.Services;


public interface IFeaturePlugin
{
	public FeaturePluginInfo PluginInfo { get; }
	public IReadOnlyList<Type> Features { get; }
}
