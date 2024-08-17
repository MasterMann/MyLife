using MyLife.App.Shared.Models.Plugins.Features;


namespace MyLife.App.Shared.Services.Plugins.Features;


public interface IFeature
{
	public FeatureInfo FeatureInfo { get; }

	public abstract void Initialize();
	public abstract void Shutdown();
}
