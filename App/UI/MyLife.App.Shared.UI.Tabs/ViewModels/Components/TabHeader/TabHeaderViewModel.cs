using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using MyLife.App.Shared.Models.Plugins.Features.TabContent;
using MyLife.App.Shared.ViewModels;


namespace MyLife.App.Shared.UI.Tabs.ViewModels.Components.TabHeader;


public partial class TabHeaderViewModel : ViewModelBase
{
	[ObservableProperty]
	string _titleLabel = "[Unknown]";

	[ObservableProperty]
	ViewModelBase? _titleContent;

	[ObservableProperty]
	ObservableCollection<TabHeaderActionViewModel> _actions = [];

	public TabHeaderViewModel(TabHeaderConfig initialConfig)
	{
		this.TitleLabel = initialConfig.TitleLabel;
		this.TitleContent = initialConfig.TitleContent;
		this.Actions = new(
			initialConfig.Actions.Select(actionModel => new TabHeaderActionViewModel(actionModel))
		);
	}
}
