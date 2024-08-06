using MyLife.App.Shared.UI.ViewModels;
using MyLife.App.Shared.UI.ViewModels.Components.TabNavigation;


namespace MyLife.App.Android.UI.Mobile.ViewModels;


public partial class MobileMainViewModel : ViewModelBase
{
    public TabNavigationViewModel Navigation { get; init; } = new();
}
