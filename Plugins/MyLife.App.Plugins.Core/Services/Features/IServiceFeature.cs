using MyLife.App.Plugins.Core.Models.Features;
using MyLife.App.Plugins.Core.Models.Features.Services;


namespace MyLife.App.Plugins.Core.Services.Features;


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
