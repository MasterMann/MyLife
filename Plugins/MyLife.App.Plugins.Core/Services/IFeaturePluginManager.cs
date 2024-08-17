﻿using System.Reflection;

using MyLife.App.Plugins.Core.Models.Features;
using MyLife.App.Plugins.Core.Services.Features;


namespace MyLife.App.Plugins.Core.Services;


public interface IFeaturePluginManager
{
	public IReadOnlyDictionary<IFeaturePlugin, IReadOnlyList<IFeature>> LoadedPlugins { get; }

	public void Initialize(IEnumerable<string> pluginFilePaths);
	public void Shutdown();

	public IEnumerable<IFeature> GetPluginFeatures(string pluginId);
	public IEnumerable<IFeature> GetFeaturesForType(FeatureType type);
	public IFeature? GetFeature(string pluginId, FeatureType type, string featureId);
}
