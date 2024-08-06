using System;
using System.Linq;

using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;

using MyLife.App.Plugins.Core.Models.Features;
using MyLife.App.Plugins.Core.Services.Features;


namespace MyLife.App.Shared.UI.ViewModels.Content;


public class TabContentDataTemplate : IDataTemplate
{
	public Control? Build(object? data)
    {
		var viewModelTypeName = data?.GetType().FullName;
		try
		{
			Type? viewType = null;
			foreach (var plugin in MyLifeApp.PluginManager.LoadedPlugins.Where(x => x.FeatureInfo.FeatureType == FeatureType.FEATURE_CONTENT_TAB))
			{
				var tabContentPlugin = (ITabContentFeaturePlugin)plugin;
				var pluginTabViewModelType = tabContentPlugin.GetTabContentViewModelType();
				if (pluginTabViewModelType?.FullName?.Equals(viewModelTypeName) ?? false)
				{
					// TODO: Cache result as a map<ViewModel, View> of Type type
					viewType = tabContentPlugin.GetTabContentViewType();
					break;
				}
			}

			// TODO: Log if type == null

			return (viewType != null)
				? (Control?)Activator.CreateInstance(viewType)
				: new TextBlock
					{
						Text = $"[Tab not found for view model: {viewModelTypeName}]",
						VerticalAlignment = VerticalAlignment.Center,
						HorizontalAlignment = HorizontalAlignment.Center,
						TextWrapping = Avalonia.Media.TextWrapping.Wrap
					};
		}
		catch (Exception ex)
		{
			// TODO: Log exception

			return new TextBlock
			{
				Text = $"[Internal exception: {ex.GetType().Name} (${ex.Message})\nView model type: ${viewModelTypeName ?? "<unknown>"}]",
				VerticalAlignment = VerticalAlignment.Center,
				HorizontalAlignment = HorizontalAlignment.Center,
				TextWrapping = Avalonia.Media.TextWrapping.Wrap
			};
		}
	}

    public bool Match(object? data) => data is TabContentViewModel;
}
