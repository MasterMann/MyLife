using MyLife.App.Shared.UI.Services.Navigation;

namespace MyLife.App.Shared.UI.Models.Features.ContentProvider;

public record UIContentProviderInfo
{
	public required string ProviderID { get; init; }
	public string ProviderName { get; init; } = string.Empty;
	public required Lazy<IUIViewLocator> ViewLocator { get; init; }
	public required Lazy<IUIViewModelFactory> ViewModelFactory { get; init; }
}