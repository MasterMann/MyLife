using CommunityToolkit.Mvvm.ComponentModel;

using MyLife.App.Common.ViewModels;


namespace MyLife.App.Android.UI.Mobile.ViewModels.Content.Todo;


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
