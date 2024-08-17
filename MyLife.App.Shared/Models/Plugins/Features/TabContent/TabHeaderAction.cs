using CommunityToolkit.Mvvm.Input;

namespace MyLife.App.Shared.Models.Plugins.Features.TabContent;


public class TabHeaderAction
{
	public TabActionPriority Priority { get; init; }
	public string ActionId { get; init; } = Guid.NewGuid().ToString();
	public string DisplayName { get; init; } = "[Unknown]";
	public string IconId { get; init; } = string.Empty;
	public bool IsEnabled { get; init; } = true;
	public IRelayCommand<object?>? TriggerCommand { get; init; }
}
