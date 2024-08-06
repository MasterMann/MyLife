using CommunityToolkit.Mvvm.ComponentModel;

using MyLife.App.Shared.Models.UI.Components.Buttons;


namespace MyLife.App.Shared.ViewModels.Components.Buttons;


public partial class IconButtonViewModel : ButtonViewModel
{
	[ObservableProperty]
	string? _iconId;

	[ObservableProperty]
	IconButtonStyle _style = IconButtonStyle.DEFAULT;
}
