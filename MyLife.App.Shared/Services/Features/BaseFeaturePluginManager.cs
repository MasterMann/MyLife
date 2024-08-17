using MyLife.App.Plugins.Core.Models.Features;
using System.Collections.Generic;
using System;

using MyLife.App.Plugins.Core.Services;
using MyLife.App.Plugins.Core.Services.Features;
using System.Linq;
using System.IO;
using MyLife.App.Plugins.Core.Utilities.Plugins;
using MyLife.App.Shared.Utilities;
using MyLife.App.Plugins.Core.Utilities;


namespace MyLife.App.Shared.Services.Features;


public class BaseFeaturePluginManager: IFeaturePluginManager
{
	public IReadOnlyDictionary<IFeaturePlugin, IReadOnlyList<IFeature>> LoadedPlugins => this._loadedPlugins;
	Dictionary<IFeaturePlugin, IReadOnlyList<IFeature>> _loadedPlugins = new();

	public BaseFeaturePluginManager()
	{
		var rootExecPath = AppDomain.CurrentDomain.BaseDirectory;
		if (rootExecPath == null) throw new Exception("Invalid root executable path.");

		var pluginsRootPath = Path.Combine(rootExecPath, "plugins");
		if (!Directory.Exists(pluginsRootPath)) return;

		var pluginFiles = new List<string>();
		foreach (var pluginDirFullName in Directory.EnumerateDirectories(pluginsRootPath))
		{
			var pluginDirName = pluginDirFullName.SplitLast(Path.DirectorySeparatorChar);

			var foundPluginFiles = Directory.EnumerateFiles(pluginDirFullName)
				.Where(filePath => 
					Path.GetFileNameWithoutExtension(filePath).Equals(pluginDirName) 
					&& filePath.EndsWith(".dll")
				);

			pluginFiles.AddRange(foundPluginFiles);
		}

		this.Initialize(pluginFiles);
	}

	public void Initialize(IEnumerable<string> pluginFilePaths)
	{
		var pluginLoader = new GenericPluginLoader<IFeaturePlugin>();
	
		foreach(var pluginFile in pluginFilePaths)
		{
			var loadedFeaturePlugin = pluginLoader.Load(pluginFile);
			if (loadedFeaturePlugin == null) continue;

			var initializedPluginFeatures = new List<IFeature>();

			foreach (var pluginFeatureType in loadedFeaturePlugin.Features)
			{
				var featureInstance = (IFeature?)Activator.CreateInstance(pluginFeatureType);
				if (featureInstance != null)
				{
					featureInstance.Initialize();
					initializedPluginFeatures.Add(featureInstance);
				}
			}

			this._loadedPlugins.Add(loadedFeaturePlugin, initializedPluginFeatures);
		}
	}
	public void Shutdown()
	{

	}

	public IEnumerable<IFeature> GetPluginFeatures(string pluginId)
		=> this.LoadedPlugins.FirstOrDefault(kv => kv.Key.PluginInfo.PluginId.Equals(pluginId)).Value;
	public IEnumerable<IFeature> GetFeaturesForType(FeatureType type)
		=> this.LoadedPlugins.Select(kv => kv.Value)
			.Aggregate(new List<IFeature>(),
				(all, next) =>
				{
					all.AddRange(next);
					return all;
				}
			).Where(feature => feature.FeatureInfo.FeatureType == type);
	public IFeature? GetFeature(string pluginId, FeatureType type, string featureId)
		=> this.GetPluginFeatures(pluginId).FirstOrDefault(feature => feature.FeatureInfo.FeatureName.Equals(type switch
		{
			FeatureType.FEATURE_CONTENT_TAB => $"tabcontent_{featureId}",
			FeatureType.FEATURE_SERVICE => $"service_{featureId}"
		}));
}
