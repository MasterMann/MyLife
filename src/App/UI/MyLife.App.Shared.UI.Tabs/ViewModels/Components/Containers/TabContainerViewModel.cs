using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using MyLife.App.Shared.ViewModels;
using MyLife.App.Shared.UI.Tabs.ViewModels.Components.TabHeader;
using MyLife.App.Shared.UI.Tabs.ViewModels.Content;


namespace MyLife.App.Shared.UI.Tabs.ViewModels.Components.Containers;


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
					this.HeaderConfig = new(new()
					{
						TitleLabel = this.TabName
					});
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
