namespace MyLife.App.Shared.Models.Plugins.Features.Services;

public record ServiceInfo
{
	public string ServiceID { get; init; } = string.Empty;
	public string Capability { get; init; } = string.Empty;
	public ServiceInitModel InitModel { get; init; } = ServiceInitModel.SIM_DEFAULT;
}
