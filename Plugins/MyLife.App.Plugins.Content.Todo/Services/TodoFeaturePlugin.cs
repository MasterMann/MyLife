using MyLife.App.Plugins.Content.Todo.Services.Features;
using MyLife.App.Plugins.Core.Models;
using MyLife.App.Plugins.Core.Services;

using static MyLife.App.Plugins.Content.Todo.BuildConstants;


namespace MyLife.App.Plugins.Content.Todo.Services;


public class TodoFeaturePlugin: IFeaturePlugin
{
	FeaturePluginInfo IFeaturePlugin.PluginInfo => new(BuildInfo)
	{
		Author = "MasterMan",
		PluginId = "todo",
		PluginName = "TODO"
	};

#pragma warning disable IDE2006 // Blank line not allowed after arrow expression clause token
	IReadOnlyList<Type> IFeaturePlugin.Features =>
	[
		typeof(TodoContentTabFeature),
		typeof(TodoContentUIViewLocator),
	];
#pragma warning restore IDE2006 // Blank line not allowed after arrow expression clause token
}
