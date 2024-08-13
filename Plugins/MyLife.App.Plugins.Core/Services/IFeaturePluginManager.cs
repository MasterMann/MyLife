using System.Reflection;

using MyLife.App.Plugins.Core.Models.Features;
using MyLife.App.Plugins.Core.Services.Features;


namespace MyLife.App.Plugins.Core.Services;


public interface IFeaturePluginManager
{
	public IReadOnlyList<IFeaturePlugin> LoadedPlugins { get; }

	public void Initialize(IEnumerable<string> pluginFilePaths);
	public void Shutdown();

	public IFeaturePlugin? GetFeature(FeatureType type, string featureId);
}
