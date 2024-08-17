using MyLife.App.Plugins.Content.Todo.ViewModels;
using MyLife.App.Plugins.Content.Todo.Views;
using MyLife.App.Shared.Models.Plugins.Features.TabContent;
using MyLife.App.Shared.Services.Plugins.Features;


namespace MyLife.App.Plugins.Content.Todo.Services.Features;


public class TodoContentTabFeature: ITabContentFeature
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

	public TabHeaderConfig? GetTabHeaderConfig()
		=> new()
		{
			TitleLabel = this.TabInfo.TabName,
			TitleContent = new TodoListSelectorViewModel(),
			Actions =
			[
				new()
				{
					ActionId = "sync",
					DisplayName = "Sync to server",
					IconId = "CloudArrowUp",
					IsEnabled = true,
					Priority = TabActionPriority.DEFAULT
				}
			]
		};
}
