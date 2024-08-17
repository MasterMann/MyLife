using System;
using System.Linq;

using Avalonia.Controls;
using Avalonia.Controls.Templates;

using MyLife.App.Plugins.Core.Models.Features;
using MyLife.App.Plugins.Core.Services.Features;
using MyLife.App.Shared.Models.Features.Services;
using MyLife.App.Shared.Services.Features.UI;


namespace MyLife.App.Shared.UI.ViewModels.Components.TabHeader;


public class TabHeaderTitleContentViewLocator: IDataTemplate
{
	public Control? Build(object? data)
	{
		var viewModelTypeName = data?.GetType().FullName;
		if (viewModelTypeName == null) return null;

		try
		{
			Type? viewType = null;
			foreach (var feature in MyLifeApp.PluginManager.GetFeaturesForType(FeatureType.FEATURE_SERVICE))
			{
				var serviceFeature = (IServiceFeature)feature;
				if (serviceFeature.ServiceInfo.Capability == DefaultServiceCapabilities.UI_VIEW_LOCATOR)
				{
					var viewLocator = (IUIViewLocatorService)serviceFeature;
					var locatedViewType = viewLocator.FindViewByViewModel(viewModelTypeName);
					if (locatedViewType != null)
					{
						// TODO: Cache result as a map<ViewModel, View> of Type type
						viewType = locatedViewType;
						break;
					}
				}
			}

			// TODO: Log if type == null

			return viewType != null
				? (Control?)Activator.CreateInstance(viewType)
				: null;
		}
		catch (Exception ex)
		{
			// TODO: Log exception

			return null;
		}
	}

	public bool Match(object? data) => data is ViewModelBase;
}
