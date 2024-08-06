using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;


namespace MyLife.App.Shared.ViewModels.Components.TabHeader;


public partial class TabHeaderViewModel : ViewModelBase
{
	[ObservableProperty]
	string _titleLabel = "[Unknown]";

	[ObservableProperty]
	ViewModelBase? _titleContent;

	[ObservableProperty]
	ObservableCollection<TabHeaderActionViewModel> _actions = [];
}
