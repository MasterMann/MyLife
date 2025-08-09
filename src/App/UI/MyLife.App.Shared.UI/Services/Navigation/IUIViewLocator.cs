using MyLife.App.Shared.UI.Models.Navigation;

namespace MyLife.App.Shared.UI.Services.Navigation;

public interface IUIViewLocator
{
	public Type? FindViewByViewModel(UIResourcePath viewModelPath);
}
