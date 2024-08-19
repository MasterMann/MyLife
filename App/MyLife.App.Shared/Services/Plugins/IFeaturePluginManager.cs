using MyLife.App.Shared.Models.Plugins.Features;
using MyLife.App.Shared.Services.Plugins.Features;


namespace MyLife.App.Shared.Services.Plugins;


public interface IFeaturePluginManager
{
	public IReadOnlyDictionary<IFeaturePlugin, IReadOnlyList<IFeature>> LoadedPlugins { get; }

	public void Initialize(IEnumerable<string> pluginFilePaths);
	public void Shutdown();

	public IEnumerable<IFeature> GetPluginFeatures(string pluginId);
	public IEnumerable<IFeature> GetFeaturesForType(FeatureType type);
	public IFeature? GetFeature(string pluginId, FeatureType type, string featureId);
}
