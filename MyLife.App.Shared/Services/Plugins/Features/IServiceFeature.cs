using MyLife.App.Shared.Models.Plugins.Features;
using MyLife.App.Shared.Models.Plugins.Features.Services;


namespace MyLife.App.Shared.Services.Plugins.Features;


public interface IServiceFeature: IFeature
{
	public ServiceInfo ServiceInfo { get; }

	FeatureInfo IFeature.FeatureInfo => new()
	{
		FeatureId = $"service_{this.ServiceInfo.ServiceId}",
		FeatureType = FeatureType.FEATURE_SERVICE,
		FeatureName = $"Service Feature - {this.ServiceInfo.ServiceId} ({this.ServiceInfo.Capability})"
	};
}
