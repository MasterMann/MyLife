// ==================================
// Generic plugin loader (with modifications)
// Original from: https://makolyte.com/csharp-generic-plugin-loader/
// ==================================

namespace MyLife.App.Plugins.Core.Utilities.Plugins;


public class GenericPluginLoader<T> where T : class
{
	readonly List<GenericAssemblyLoadContext<T>> _loadContexts = new();

	public List<T> LoadAll(string pluginPath, string filter = "*.dll", params object[] constructorArgs)
	{
		List<T> plugins = new();

		foreach (var filePath in Directory.EnumerateFiles(pluginPath, filter, SearchOption.AllDirectories))
		{
			var loadedPlugins = this.Load(filePath, constructorArgs);

			if (loadedPlugins.Count() > 0)
			{
				plugins.AddRange(loadedPlugins);
			}
		}

		return plugins;
	}
	public IEnumerable<T> Load(string pluginPath, params object[] constructorArgs)
	{
		var loadContext = new GenericAssemblyLoadContext<T>(pluginPath);

		this._loadContexts.Add(loadContext);

		var assembly = loadContext.LoadFromAssemblyPath(pluginPath);

		var loadedPlugins = new List<T>();

		var pluginTypes = assembly.GetExportedTypes().Where(type
			=> typeof(T).IsAssignableFrom(type) && !type.IsAbstract
		);
		if (pluginTypes.Count() > 0)
		{
			foreach (var pluginType in pluginTypes)
			{
				var pluginInstance = (T)Activator.CreateInstance(pluginType, constructorArgs)!;
				loadedPlugins.Add(pluginInstance);
			}
		}

		return loadedPlugins;
	}
	public void UnloadAll()
	{
		foreach (var loadContext in this._loadContexts)
		{
			loadContext.Unload();
		}
	}
}
