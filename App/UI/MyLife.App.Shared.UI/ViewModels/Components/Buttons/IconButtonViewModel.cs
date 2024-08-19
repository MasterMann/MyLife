using CommunityToolkit.Mvvm.ComponentModel;

using MyLife.App.Shared.UI.Models.Components.Buttons;


namespace MyLife.App.Shared.UI.ViewModels.Components.Buttons;


public partial class IconButtonViewModel : ButtonViewModel
{
	[ObservableProperty]
	string? _iconId;

	[ObservableProperty]
	IconButtonStyle _style = IconButtonStyle.DEFAULT;
}
