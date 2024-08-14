// ==================================
// Generic plugin loader (with modifications)
// Original from: https://makolyte.com/csharp-generic-plugin-loader/
// ==================================

using System.Reflection;
using System.Reflection.PortableExecutable;

namespace MyLife.App.Plugins.Core.Utilities.Plugins;


public class GenericPluginLoader<T> where T : class
{
	//readonly List<PluginAssemblyLoadContext<T>> _loadContexts = new();

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
		//var pluginName = Path.GetFileNameWithoutExtension(pluginPath);

		//var loadContext = new PluginAssemblyLoadContext<T>(pluginName, pluginPath);
		//this._loadContexts.Add(loadContext);

		//var assembly = loadContext.LoadFromAssemblyPath(pluginPath);

		//using var stream = File.OpenRead(pluginPath);
		//using var reader = new PEReader(stream);
		//var hasMetadata = reader.HasMetadata;
		//var arch = reader.PEHeaders.PEHeader?.Magic;
		//var targetMachine = reader.PEHeaders.CoffHeader.Machine;
		//var clrHeader = reader.PEHeaders.CorHeader;
		//var requires32Bit = clrHeader?.Flags.HasFlag(CorFlags.Requires32Bit);
		//var hasIL = clrHeader?.Flags.HasFlag(CorFlags.ILOnly);
		//var isIlLibrary = clrHeader?.Flags.HasFlag(CorFlags.ILLibrary);

		var assembly = Assembly.LoadFrom(pluginPath);

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
		//foreach (var loadContext in this._loadContexts)
		//{
		//	loadContext.Unload();
		//}
	}
}
