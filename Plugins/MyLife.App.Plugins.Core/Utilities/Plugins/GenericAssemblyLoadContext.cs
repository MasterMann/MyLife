// ==================================
// Generic assembly load context for plugins
// Original from: https://makolyte.com/csharp-generic-plugin-loader/
// ==================================

using System.Reflection;
using System.Runtime.Loader;


namespace MyLife.App.Plugins.Core.Utilities.Plugins;


public class GenericAssemblyLoadContext<T>: AssemblyLoadContext where T : class
{
	AssemblyDependencyResolver _resolver;
	HashSet<string> _skipAssemblyLoadList;

	public GenericAssemblyLoadContext(string pluginPath) : base(isCollectible: true)
	{
		var pluginInterfaceAssembly = typeof(T).Assembly.FullName!;
		_skipAssemblyLoadList = this.GetReferencedAssemblyFullNames(pluginInterfaceAssembly);
		this._skipAssemblyLoadList.Add(pluginInterfaceAssembly);

		this._resolver = new AssemblyDependencyResolver(pluginPath);
	}
	HashSet<string> GetReferencedAssemblyFullNames(string ReferencedBy)
	{
		return AppDomain.CurrentDomain
			.GetAssemblies().FirstOrDefault(t => t.FullName == ReferencedBy)
			.GetReferencedAssemblies()
			.Select(t => t.FullName)
			.ToHashSet();
	}
	protected override Assembly? Load(AssemblyName assemblyName)
	{
		//Do not load the Plugin Interface DLL into the adapter's context
		//otherwise IsAssignableFrom is false. 
		if (_skipAssemblyLoadList.Contains(assemblyName.FullName))
		{
			return null;
		}

		var assemblyPath = this._resolver.ResolveAssemblyToPath(assemblyName);
		return (assemblyPath != null) ? this.LoadFromAssemblyPath(assemblyPath) : null;
	}
	protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
	{
		var libraryPath = this._resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
		return (libraryPath != null) ? this.LoadUnmanagedDllFromPath(libraryPath) : IntPtr.Zero;
	}
}