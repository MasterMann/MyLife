using MyLife.App.Shared.ViewModels;

namespace MyLife.App.Shared.Models.Plugins.Features.TabContent;


public class TabHeaderConfig
{
	public string TitleLabel { get; init; } = "[Unknown]";
	public ViewModelBase? TitleContent { get; init; }
	public IEnumerable<TabHeaderAction> Actions { get; init; } = [];
}
