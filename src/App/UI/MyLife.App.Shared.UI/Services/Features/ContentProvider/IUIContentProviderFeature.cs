using MyLife.App.Shared.Models.Plugins.Features;
using MyLife.App.Shared.Services.Plugins.Features;

namespace MyLife.App.Shared.UI.Services.Features.ContentProvider;

public interface IUIContentProviderFeature: IFeature
{
	string IFeature.FEATURE_ID_PREFIX => "ui-content-provider_";

	public IUIContentProvider Provider { get; }

	FeatureInfo IFeature.FeatureInfo => new()
	{
		FeatureID = $"{this.FEATURE_ID_PREFIX}{this.Provider.ProviderInfo.ProviderID}",
		FeatureType = FeatureType.FEATURE_UI_CONTENT_PROVIDER,
		FeatureName = $"UI Content Provider - {this.Provider.ProviderInfo.ProviderName}"
	};
}
