using MyLife.App.Plugins.Core.Models.Features;
using MyLife.App.Plugins.Core.Models.Features.TabContent;


namespace MyLife.App.Plugins.Core.Services.Features;


public interface ITabContentFeature: IFeature
{
	public TabContentInfo TabInfo { get; }

	FeatureInfo IFeature.FeatureInfo => new()
	{
		FeatureId = $"tabcontent_{this.TabInfo.TabId}",
		FeatureType = FeatureType.FEATURE_CONTENT_TAB,
		FeatureName = $"Tab Content Feature - {this.TabInfo.TabName}"
	};

	public Type GetTabContentViewType();
	public Type GetTabContentViewModelType();
}
