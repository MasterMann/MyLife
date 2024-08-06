using MyLife.App.Android.UI.Mobile.ViewModels.Content.Todo;
using MyLife.App.Android.UI.Mobile.Views.Content.Todo;
using MyLife.App.Plugins.Core.Models.Features.TabContent;
using MyLife.App.Plugins.Core.Services.Features;


namespace MyLife.App.Android.UI.Mobile.Services.Features.Content.Todo;


public class TodoContentTabFeature: ITabContentFeaturePlugin
{
	public TabContentInfo TabInfo => new()
	{
		TabId = "todo",
		TabName = "TODO"
	};

	public void Initialize() { }
	public void Shutdown() { }

	public Type GetTabContentViewType() => typeof(TodoTabContentView);
	public Type GetTabContentViewModelType() => typeof(TodoTabContentViewModel);
}
