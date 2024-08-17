using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;

using MyLife.App.Shared.Models.Plugins.Features;
using MyLife.App.Shared.Services.Plugins.Features;


namespace MyLife.App.Shared.UI.Tabs.ViewModels.Content;


public class TabContentDataTemplate: IDataTemplate
{
	public Control? Build(object? data)
	{
		var viewModelTypeName = data?.GetType().FullName;
		try
		{
			Type? viewType = null;
			foreach (var feature in MyLifeApp.PluginManager.GetFeaturesForType(FeatureType.FEATURE_CONTENT_TAB))
			{
				var tabContentFeature = (ITabContentFeature)feature;
				var pluginTabViewModelType = tabContentFeature.GetTabContentViewModelType();
				if (pluginTabViewModelType?.FullName?.Equals(viewModelTypeName) ?? false)
				{
					// TODO: Cache result as a map<ViewModel, View> of Type type
					viewType = tabContentFeature.GetTabContentViewType();
					break;
				}
			}

			// TODO: Log if type == null

			return viewType != null
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
