using MyLife.App.Plugins.Core.Models.Features;
using System.Collections.Generic;
using System.Reflection;
using System;

using MyLife.App.Plugins.Core.Services;
using MyLife.App.Plugins.Core.Services.Features;
using System.Linq;

namespace MyLife.App.Shared.Services.Features;


public class BaseFeaturePluginManager: IFeaturePluginManager
{
	public IReadOnlyList<IFeaturePlugin> LoadedPlugins => this._loadedPlugins;
	List<IFeaturePlugin> _loadedPlugins = new();

	public BaseFeaturePluginManager()
	{
		var dependencies = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
			.Where(x => x.Name!.StartsWith("MyLife.App"));

		var loadedAssemblies = new List<Assembly>();
		foreach (var dependency in dependencies)
		{
			var assembly = Assembly.Load(dependency);
			if (assembly != null)
				loadedAssemblies.Add(assembly);
		}

		this.Initialize(loadedAssemblies);
	}

	public void Initialize(IEnumerable<Assembly> loadedAssemblies)
	{
		foreach (var assembly in loadedAssemblies)
		{
			var pluginTypes = assembly.GetExportedTypes().Where(type
				=> typeof(IFeaturePlugin).IsAssignableFrom(type) && !type.IsAbstract
			);
			if (pluginTypes.Count() > 0)
			{
				foreach (var pluginType in pluginTypes)
				{
					var pluginInstance = (IFeaturePlugin)Activator.CreateInstance(pluginType)!;
					pluginInstance.Initialize();
					this._loadedPlugins.Add(pluginInstance);
				}
			}
		}
	}
	public void Shutdown()
	{

	}

	public TFeature? GetFeature<TFeature>(FeatureType type, string featureId)
		where TFeature : IFeaturePlugin
	{
		var fullFeatureId = type switch
		{
			FeatureType.FEATURE_CONTENT_TAB => $"tabcontent_{featureId}",
			FeatureType.FEATURE_SERVICE => $"service_{featureId}"
		};

		var plugin = this.LoadedPlugins.FirstOrDefault(x => x.FeatureInfo.FeatureId.Equals(fullFeatureId));
		return plugin != null
			? (TFeature)plugin
			: default;
	}
}
