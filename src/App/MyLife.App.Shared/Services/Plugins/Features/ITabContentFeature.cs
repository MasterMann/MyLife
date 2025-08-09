using MyLife.App.Shared.Models.Plugins.Features;
using MyLife.App.Shared.Models.Plugins.Features.TabContent;

namespace MyLife.App.Shared.Services.Plugins.Features;

public interface ITabContentFeature: IFeature
{
	string IFeature.FEATURE_ID_PREFIX => "tab-content_";

	public TabContentInfo TabInfo { get; }

	FeatureInfo IFeature.FeatureInfo => new()
	{
		FeatureID = $"{this.FEATURE_ID_PREFIX}{this.TabInfo.TabId}",
		FeatureType = FeatureType.FEATURE_CONTENT_TAB,
		FeatureName = $"Tab Content Feature - {this.TabInfo.TabName}"
	};

	public Type GetTabContentViewType();
	public Type GetTabContentViewModelType();
	public TabHeaderConfig? GetTabHeaderConfig();
}
