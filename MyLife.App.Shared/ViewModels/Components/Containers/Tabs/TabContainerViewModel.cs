using CommunityToolkit.Mvvm.ComponentModel;

using MyLife.App.Shared.ViewModels.Content;
using MyLife.App.Shared.ViewModels;
using MyLife.App.Shared.ViewModels.Components.TabHeader;
using System.ComponentModel;
using System;


namespace MyLife.App.Shared.ViewModels.Components.Containers.Tabs;


public partial class TabContainerViewModel : ViewModelBase
{
	[ObservableProperty]
	string _tabId = Guid.NewGuid().ToString();

	[ObservableProperty]
	string _tabName = "[Unknown]";

	[ObservableProperty]
	TabHeaderViewModel? _headerConfig;

	[ObservableProperty]
	TabContentViewModel? _content;

	protected override void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
			case nameof(this.TabName):
			{
				if (this.HeaderConfig == null)
				{
					this.HeaderConfig = new()
					{
						TitleLabel = this.TabName
					};
				}
				else this.HeaderConfig.TitleLabel = this.TabName;

				break;
			}
			default:
			{
				base.OnPropertyChanged(e);

				break;
			}
		}
	}
}
