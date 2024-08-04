using Avalonia.Controls;
using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using MyLife.App.Android.UI.Mobile.ViewModels.Content;
using MyLife.App.Common.ViewModels;
using MyLife.App.Android.UI.Mobile.Models.Containers.Tabs;


namespace MyLife.App.Android.UI.Mobile.ViewModels.Components.TabHeader;


public partial class TabHeaderViewModel : ViewModelBase
{
	[ObservableProperty]
	string _titleLabel = "[Unknown]";

	[ObservableProperty]
	ViewModelBase? _titleContent;

	[ObservableProperty]
	ObservableCollection<TabHeaderActionViewModel> _actions = [];
}
