using MyLife.App.Shared.ViewModels.Components.TabNavigation;
using MyLife.App.Shared.ViewModels;


namespace MyLife.App.Android.UI.Mobile.ViewModels;


public partial class MobileMainViewModel : ViewModelBase
{
    public TabNavigationViewModel Navigation { get; init; } = new();
}
