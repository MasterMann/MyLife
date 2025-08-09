using MyLife.App.Shared.UI.Models.Navigation;
using MyLife.App.Shared.UI.ViewModels.Navigation;
using MyLife.App.Shared.ViewModels;

namespace MyLife.App.Shared.UI.Services.Navigation;

public interface IUIViewModelFactory
{
	public ActivityViewModel? GetOrCreateActivityViewModel(UIResourcePath viewModelPath, IUIRouter router);
	public ActivityViewModel? CreateActivityViewModel(UIResourcePath viewModelPath, IUIRouter router);
	public TViewModel? CreateViewModel<TViewModel>(UIResourcePath viewModelPath) where TViewModel : ViewModelBase;
}
