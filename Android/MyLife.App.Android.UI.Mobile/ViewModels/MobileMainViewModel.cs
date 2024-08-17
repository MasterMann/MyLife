using MyLife.App.Shared.Models.Plugins.Features;
using MyLife.App.Shared.Services.Plugins;
using MyLife.App.Shared.Services.Plugins.Features;
using MyLife.App.Shared.UI.Tabs.ViewModels.Components.Containers;
using MyLife.App.Shared.UI.Tabs.ViewModels.Components.TabNavigation;
using MyLife.App.Shared.UI.Tabs.ViewModels.Content;
using MyLife.App.Shared.ViewModels;


namespace MyLife.App.Android.UI.Mobile.ViewModels;


public partial class MobileMainViewModel : ViewModelBase
{
    public TabNavigationViewModel Navigation { get; init; } = new();

	public MobileMainViewModel(IFeaturePluginManager featureManager)
	{
		var navItems = this.GetNavItemsFromFeatures(featureManager);
		var tabs = this.GetContentTabsFromFeatures(featureManager);

		this.Navigation = new()
		{
			Tabs = new(tabs),
			NavItems = new(navItems)
		};
	}

	IEnumerable<TabNavigationItemViewModel> GetNavItemsFromFeatures(IFeaturePluginManager featureManager)
	{
		static TabNavigationItemViewModel GetNavItemFromFeature(ITabContentFeature feature)
		{
			var tabInfo = feature.TabInfo;

			return new()
			{
				TabId = tabInfo.TabId,
				TabName = tabInfo.TabName,
				TabIconId = tabInfo.TabIconId
			};
		}

		foreach (var feature in featureManager.GetFeaturesForType(FeatureType.FEATURE_CONTENT_TAB))
		{
			var tabContentFeature = (ITabContentFeature)feature;
			yield return GetNavItemFromFeature(tabContentFeature);
		}
	}

	IEnumerable<TabContainerViewModel> GetContentTabsFromFeatures(IFeaturePluginManager featureManager)
	{
		static TabContainerViewModel GetContentTabFromFeature(ITabContentFeature feature)
		{
			var tabInfo = feature.TabInfo;
			var tabContentVM = (TabContentViewModel?)Activator.CreateInstance(feature.GetTabContentViewModelType());
			var tabHeaderConfig = feature.GetTabHeaderConfig();

			return new()
			{
				TabId = tabInfo.TabId,
				TabName = tabInfo.TabName,
				Content = tabContentVM,
				HeaderConfig = (tabHeaderConfig != null)
					? new(tabHeaderConfig)
					: new(new()
					{
						TitleLabel = tabInfo.TabName
					})
			};
		}

		foreach (var feature in featureManager.GetFeaturesForType(FeatureType.FEATURE_CONTENT_TAB))
		{
			var tabContentFeature = (ITabContentFeature)feature;
			yield return GetContentTabFromFeature(tabContentFeature);
		}
	}
}
