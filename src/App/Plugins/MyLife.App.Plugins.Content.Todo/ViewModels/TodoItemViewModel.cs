using CommunityToolkit.Mvvm.ComponentModel;

using MyLife.App.Shared.ViewModels;

namespace MyLife.App.Plugins.Content.Todo.ViewModels;

public partial class TodoItemViewModel : ViewModelBase
{
	[ObservableProperty]
	string _id = Guid.NewGuid().ToString();

	[ObservableProperty]
	string _text = string.Empty;

	[ObservableProperty]
	bool _isChecked;

	[ObservableProperty]
	bool _isEditing;
}
