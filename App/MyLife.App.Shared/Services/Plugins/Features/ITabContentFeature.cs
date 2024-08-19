using MyLife.App.Shared.Models.Plugins.Features;
using MyLife.App.Shared.Models.Plugins.Features.TabContent;


namespace MyLife.App.Shared.Services.Plugins.Features;


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
	public TabHeaderConfig? GetTabHeaderConfig();
}
