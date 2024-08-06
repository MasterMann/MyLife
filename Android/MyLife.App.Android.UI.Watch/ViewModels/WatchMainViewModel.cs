using System.Collections.ObjectModel;

using MyLife.App.Shared.ViewModels;
using MyLife.App.Shared.ViewModels.Components.Buttons;


namespace MyLife.App.Android.UI.Watch.ViewModels;


public partial class WatchMainViewModel : ViewModelBase
{
    public ObservableCollection<PillButtonViewModel> Buttons { get; init; } = new();
}
