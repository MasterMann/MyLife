using System.Collections.ObjectModel;

using MyLife.App.Shared.Models.Plugins.Features;
using MyLife.App.Shared.Services.Plugins;
using MyLife.App.Shared.Services.Plugins.Features;
using MyLife.App.Shared.UI.ViewModels;
using MyLife.App.Shared.UI.ViewModels.Components.Buttons;
using MyLife.App.Shared.ViewModels;

namespace MyLife.App.Android.UI.Watch.ViewModels;

public partial class WatchMainViewModel : ViewModelBase
{
    public ObservableCollection<PillButtonViewModel> NavItems { get; init; } = new();

	public WatchMainViewModel()
	{

	}

	public WatchMainViewModel(IFeaturePluginManager featureManager)
	{
		this.NavItems = new(this.GetNavItemsFromFeatures(featureManager));
	}

	IEnumerable<PillButtonViewModel> GetNavItemsFromFeatures(IFeaturePluginManager featureManager)
	{
		static PillButtonViewModel GetNavItemFromFeature(ITabContentFeature feature)
		{
			var tabInfo = feature.TabInfo;

			return new()
			{
				Id = tabInfo.TabId,
				Label = tabInfo.TabName,
				IconId = tabInfo.TabIconId
			};
		}

		foreach (var feature in featureManager.GetFeaturesForType(FeatureType.FEATURE_CONTENT_TAB))
		{
			var tabContentFeature = (ITabContentFeature)feature;
			yield return GetNavItemFromFeature(tabContentFeature);
		}
	}
}
