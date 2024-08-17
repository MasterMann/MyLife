using MyLife.App.Plugins.Core.Models.Features;
using MyLife.App.Plugins.Core.Services;
using MyLife.App.Plugins.Core.Services.Features;
using MyLife.App.Shared.UI.ViewModels;
using MyLife.App.Shared.UI.ViewModels.Components.Containers.Tabs;
using MyLife.App.Shared.UI.ViewModels.Components.TabNavigation;
using MyLife.App.Shared.UI.ViewModels.Content;


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

			return new()
			{
				TabId = tabInfo.TabId,
				TabName = tabInfo.TabName,
				Content = tabContentVM,
				HeaderConfig = new()
				{
					TitleLabel = tabInfo.TabName,
					// TODO: Add actions and title content
				}
			};
		}

		foreach (var feature in featureManager.GetFeaturesForType(FeatureType.FEATURE_CONTENT_TAB))
		{
			var tabContentFeature = (ITabContentFeature)feature;
			yield return GetContentTabFromFeature(tabContentFeature);
		}
	}
}
