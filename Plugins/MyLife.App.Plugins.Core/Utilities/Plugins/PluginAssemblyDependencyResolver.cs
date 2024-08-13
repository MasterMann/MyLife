using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;


namespace MyLife.App.Plugins.Core.Utilities.Plugins;


public readonly struct DependencyInfo
{
	public string Name { get; init; }
	public string Version { get; init; }
}

public sealed class PluginAssemblyDependencyResolver
{
	const string DotNetTargetRegex = "\\.NETCoreApp,Version=v([a-z0-9.]+)";

	/// <summary>
	/// The name of the neutral culture (same value as in Variables::Init in CoreCLR)
	/// </summary>
	const string NeutralCultureName = "neutral";

	/// <summary>
	/// The extension of resource assembly (same as in BindSatelliteResourceByResourceRoots in CoreCLR)
	/// </summary>
	const string AssemblyExtension = ".dll";

	readonly Dictionary<string, string> _assemblyPaths = new();
	readonly List<string> _nativeSearchPaths = new();
	readonly List<string> _resourceSearchPaths = new();
	readonly List<string> _assemblyDirectorySearchPaths = new();

	public PluginAssemblyDependencyResolver(string componentAssemblyPath)
	{
		var targetAssemblyName = Path.GetFileNameWithoutExtension(componentAssemblyPath);
		var targetAssemblyPath = componentAssemblyPath.Replace('/', Path.DirectorySeparatorChar);

		var assemblyDependenciesListFile = targetAssemblyPath.Replace(AssemblyExtension, ".deps.json");
		if (!File.Exists(assemblyDependenciesListFile)) throw new Exception("Failed to parse assembly dependencies.");

		var stream = File.OpenRead(assemblyDependenciesListFile);
		var assemblyDeps = JsonSerializer.Deserialize<JsonElement>(stream);
		if (assemblyDeps.TryGetProperty("targets", out var targets))
		{
			foreach (var target in targets.EnumerateObject()
				.Where(target => Regex.IsMatch(target.Name, DotNetTargetRegex)))
			{
				foreach (var assembly in target.Value.EnumerateObject())
				{
					var assemblyName = assembly.Name.Split('/')[0];

					IEnumerable<DependencyInfo> dependencies = [];
					if (assembly.Value.TryGetProperty("dependencies", out var dependenciesList))
					{
						dependencies = dependenciesList.EnumerateObject()
							.Select(assembly => new DependencyInfo { Name = assembly.Name, Version = assembly.Value.GetString() ?? string.Empty }) 
							?? [];
					}

					IEnumerable<string> satelliteAssemblyPaths = [];
					if (assembly.Value.TryGetProperty("runtime", out var assemblyPathsList))
					{
						satelliteAssemblyPaths = assemblyPathsList.EnumerateObject()
							.Select(path => path.Name)
							?? [];
					}

					if (assemblyName.Equals(targetAssemblyName))
					{
						this._assemblyPaths.Add(assemblyName, targetAssemblyPath);
					}
					//else if (satelliteAssemblyPaths.Count() > 0)
					//{
					//	var satelliteAssemblyFullPaths = satelliteAssemblyPaths.Select(path => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path.SplitLast('/').Replace('/', Path.DirectorySeparatorChar)));

					//	foreach (var satelliteAssemblyPath in satelliteAssemblyFullPaths)
					//	{
					//		var satelliteAssemblyName = Path.GetFileNameWithoutExtension(satelliteAssemblyPath);

					//		this._assemblyPaths.Add(satelliteAssemblyName, satelliteAssemblyPath);
					//	}
					//}
				}
			}
		}

		stream.Close();

		this._assemblyDirectorySearchPaths.Add(AppDomain.CurrentDomain.BaseDirectory);
		this._assemblyDirectorySearchPaths.Add(componentAssemblyPath.SplitLast(Path.DirectorySeparatorChar));
	}

	public string? ResolveAssemblyToPath(AssemblyName assemblyName)
	{
		static string? ResolveAssemblyPath(string searchPath, string assemblyName)
		{
			var possibleFullPath = Path.Combine(searchPath, $"{assemblyName}{AssemblyExtension}");
			if (File.Exists(possibleFullPath)) return possibleFullPath;
			else
			{
				var childDirectories = Directory.EnumerateDirectories(searchPath);

				if (childDirectories.Count() > 0)
				{
					foreach (var childDirectory in childDirectories)
					{
						return ResolveAssemblyPath(childDirectory, assemblyName);
					}
				}
			}

			return null;
		}
	
		if (assemblyName.Name == null) return null;

		var name = assemblyName.Name;
		if (this._assemblyPaths.TryGetValue(name, out var assemblyPath))
		{
			if (File.Exists(assemblyPath)) return assemblyPath;
			else
			{
				foreach (var searchPath in this._assemblyDirectorySearchPaths)
				{
					return ResolveAssemblyPath(searchPath, name);
				}
			}
		}

		return null;
	}

	public string? ResolveUnmanagedDllToPath(string unmanagedDllName)
	{
		

		return null;
	}
}

