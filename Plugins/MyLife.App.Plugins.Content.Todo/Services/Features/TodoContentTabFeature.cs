using MyLife.App.Plugins.Content.Todo.ViewModels;
using MyLife.App.Plugins.Content.Todo.Views;
using MyLife.App.Plugins.Core.Models.Features.TabContent;
using MyLife.App.Plugins.Core.Services.Features;


namespace MyLife.App.Plugins.Content.Todo.Services.Features;


public class TodoContentTabFeature: ITabContentFeaturePlugin
{
	public TabContentInfo TabInfo => new()
	{
		TabId = "todo",
		TabName = "TODO",
		TabIconId = "FormatListChecks"
	};

	public void Initialize() { }
	public void Shutdown() { }

	public Type GetTabContentViewType() => typeof(TodoTabContentView);
	public Type GetTabContentViewModelType() => typeof(TodoTabContentViewModel);
}
