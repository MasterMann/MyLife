// ==================================
// Generic plugin loader (with modifications)
// Original from: https://makolyte.com/csharp-generic-plugin-loader/
// ==================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MyLife.App.Plugins.Core.Utilities.Plugins;


public class GenericPluginLoader<T> where T : class
{
	public List<T> LoadAll(string pluginPath, string filter = "*.dll", params object[] constructorArgs)
	{
		List<T> plugins = new();

		foreach (var filePath in Directory.EnumerateFiles(pluginPath, filter, SearchOption.AllDirectories))
		{
			var pluginInstance = this.Load(filePath, constructorArgs);

			if (pluginInstance != null)
			{
				plugins.Add(pluginInstance);
			}
		}

		return plugins;
	}
	public T? Load(string pluginPath, params object[] constructorArgs)
	{
		var assembly = Assembly.LoadFrom(pluginPath);

		var pluginType = assembly.GetExportedTypes().FirstOrDefault(type
			=> typeof(T).IsAssignableFrom(type) && !type.IsAbstract
		);
		
		if (pluginType != null)
		{
			var pluginInstance = (T?)Activator.CreateInstance(pluginType, constructorArgs)!;
			return pluginInstance;
		}
		else return null;
	}
	public void UnloadAll()
	{
		//foreach (var loadContext in this._loadContexts)
		//{
		//	loadContext.Unload();
		//}
	}
}
