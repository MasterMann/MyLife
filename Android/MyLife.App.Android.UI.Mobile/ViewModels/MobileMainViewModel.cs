using MyLife.App.Android.UI.Mobile.ViewModels.Components.BottomNavigation;
using MyLife.App.Shared.ViewModels;


namespace MyLife.App.Android.UI.Mobile.ViewModels;


public partial class MobileMainViewModel : ViewModelBase
{
    public BottomNavigationViewModel BottomNav { get; init; } = new();
}
