using System;

using CommunityToolkit.Mvvm.ComponentModel;

using MyLife.App.Shared.UI.ViewModels;
using MyLife.App.Shared.ViewModels;


namespace MyLife.App.Plugins.Content.Todo.ViewModels;


public partial class TodoItemViewModel : ViewModelBase
{
	[ObservableProperty]
	public string _id = Guid.NewGuid().ToString();

	[ObservableProperty]
	public string _text = string.Empty;

	[ObservableProperty]
	public bool _isChecked;

	[ObservableProperty]
	public bool _isEditModeEnabled;
}
