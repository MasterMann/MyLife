using MyLife.App.Plugins.Core.Models.Features;
using System.Collections.Generic;
using System.Reflection;
using System;

using MyLife.App.Plugins.Core.Services;
using MyLife.App.Plugins.Core.Services.Features;
using System.Linq;
using System.IO;
using MyLife.App.Plugins.Core.Utilities.Plugins;
using MyLife.App.Shared.Utilities;

namespace MyLife.App.Shared.Services.Features;


public class BaseFeaturePluginManager: IFeaturePluginManager
{
	public IReadOnlyList<IFeaturePlugin> LoadedPlugins => this._loadedPlugins;
	List<IFeaturePlugin> _loadedPlugins = new();

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
			var loadedFeaturePlugins = pluginLoader.Load(pluginFile);

			foreach (var loadedPlugin in loadedFeaturePlugins)
			{
				loadedPlugin.Initialize();
			}

			this._loadedPlugins.AddRange(loadedFeaturePlugins);
		}
	}
	public void Shutdown()
	{

	}

	public IFeaturePlugin? GetFeature(FeatureType type, string featureId)
	{
		var fullFeatureId = type switch
		{
			FeatureType.FEATURE_CONTENT_TAB => $"tabcontent_{featureId}",
			FeatureType.FEATURE_SERVICE => $"service_{featureId}"
		};

		var plugin = this.LoadedPlugins.FirstOrDefault(x => x.FeatureInfo.FeatureId.Equals(fullFeatureId));
		return plugin ?? default;
	}
}
