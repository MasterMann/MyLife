using System.Collections.ObjectModel;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using MyLife.App.Shared.UI.ViewModels;


namespace MyLife.App.Plugins.Content.Todo.ViewModels;


public readonly struct TodoListSelectorItem
{
	public string Id { get; init; }
	public string DisplayName { get; init; }
}

public partial class TodoListSelectorViewModel: ViewModelBase
{
	[ObservableProperty]
	ObservableCollection<TodoListSelectorItem> _lists = 
	[
		new() { Id = "265901C2-E3E5-47E1-9E58-F168E13BF11F", DisplayName = "Default" },
		new() { Id = "531F5C42-CDBE-4FE1-A126-7C823BAC3C45", DisplayName = "Default 2" }
	];

	[ObservableProperty]
	string _selectedListId;

	public TodoListSelectorViewModel()
	{
		this.SelectedListId = this.Lists.First().Id;
	}
}
