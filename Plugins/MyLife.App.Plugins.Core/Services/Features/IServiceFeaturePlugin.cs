using MyLife.App.Plugins.Core.Models.Features;
using MyLife.App.Plugins.Core.Models.Features.Services;


namespace MyLife.App.Plugins.Core.Services.Features;


public interface IServiceFeaturePlugin: IFeaturePlugin
{
	public ServiceInfo ServiceInfo { get; }

	FeaturePluginInfo IFeaturePlugin.FeatureInfo => new()
	{
		FeatureId = $"service_{this.ServiceInfo.ServiceId}",
		FeatureType = FeatureType.FEATURE_SERVICE,
		FeatureName = $"Service Feature Plugin - {this.ServiceInfo.ServiceId} ({this.ServiceInfo.Capability})"
	};
}
