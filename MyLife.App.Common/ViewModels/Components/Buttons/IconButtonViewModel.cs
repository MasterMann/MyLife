using CommunityToolkit.Mvvm.ComponentModel;

using MyLife.App.Common.Models.UI.Components.Buttons;


namespace MyLife.App.Common.ViewModels.Components.Buttons;


public partial class IconButtonViewModel : ButtonViewModel
{
	[ObservableProperty]
	string? _iconId;

	[ObservableProperty]
	IconButtonStyle _style = IconButtonStyle.DEFAULT;
}
