using System.Collections.ObjectModel;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;


namespace MyLife.App.Shared.UI.ViewModels.Components.Buttons;


public partial class FloatingActionButtonViewModel : ButtonViewModel
{
	[ObservableProperty]
	ObservableCollection<IconButtonViewModel> _actions = new();

	[ObservableProperty]
	string _initialIcon = string.Empty;

	public void UpdateActionIcon(int targetIndex, string iconID)
		=> this.Actions = new(this.Actions.Select((item, index) =>
		{
			if (index == targetIndex)
			{
				item.IconId = iconID;
			}

			return item;
		}));
}
