using MyLife.App.Shared.Models.Plugins.Features;
using MyLife.App.Shared.Models.Plugins.Features.Services;

namespace MyLife.App.Shared.Services.Plugins.Features;

public interface IServiceFeature: IFeature
{
	string IFeature.FEATURE_ID_PREFIX => "service_";

	public ServiceInfo ServiceInfo { get; }

	FeatureInfo IFeature.FeatureInfo => new()
	{
		FeatureID = $"{this.FEATURE_ID_PREFIX}{this.ServiceInfo.ServiceID}",
		FeatureType = FeatureType.FEATURE_SERVICE,
		FeatureName = $"Service Feature - {this.ServiceInfo.ServiceID} ({this.ServiceInfo.Capability})"
	};
}
