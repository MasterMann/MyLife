using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;


namespace MyLife.App.Android.UI.Mobile.Views.Content.Todo;


public partial class TodoItemView : UserControl
{
    public TodoItemView()
    {
        this.InitializeComponent();

		this.Loaded += this.OnLoaded;
    }

	void OnLoaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var vm = this.DataContext;
    }
}