using System.ComponentModel;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

using MyLife.App.Android.UI.Mobile.ViewModels.Components.BottomNavigation;


namespace MyLife.App.Android.UI.Mobile.Views.Components.BottomNavigation;


public partial class BottomNavigationItemView : UserControl
{
	static int DefaultTabIconSize = 20;
	static int SelectedTabIconSize = 24;

	static FontWeight DefaultTabNameLabelWeight = FontWeight.Regular;
	static FontWeight SelectedTabNameLabelWeight = FontWeight.Bold;

	public static readonly StyledProperty<int> TabIconSizeProperty =
		AvaloniaProperty.Register<BottomNavigationItemView, int>(nameof(TabIconSize), defaultValue: DefaultTabIconSize);

	public static readonly StyledProperty<FontWeight> TabNameLabelWeightProperty =
		AvaloniaProperty.Register<BottomNavigationItemView, FontWeight>(nameof(TabNameLabelWeight), defaultValue: DefaultTabNameLabelWeight);

	public int TabIconSize
	{
		get => GetValue(TabIconSizeProperty);
		set => SetValue(TabIconSizeProperty, value);
	}

	public FontWeight TabNameLabelWeight
	{
		get => GetValue(TabNameLabelWeightProperty);
		set => SetValue(TabNameLabelWeightProperty, value);
	}

	BottomNavigationItemViewModel _vm;

	public BottomNavigationItemView()
    {
        this.InitializeComponent();

		this.Loaded += this.OnLoaded;
	}

	void OnLoaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		var vm = (BottomNavigationItemViewModel)this.DataContext;
		if (vm != null)
		{
			this._vm = vm;
			this._vm.PropertyChanged += this.OnViewModelPropertyChanged;

			this.UpdateTabIconSize(this._vm.IsSelected);
			this.UpdateTabNameLabelWeight(this._vm.IsSelected);
		}
	}

	void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
			case nameof(BottomNavigationItemViewModel.IsSelected):
			{
				this.UpdateTabIconSize(this._vm.IsSelected);
				this.UpdateTabNameLabelWeight(this._vm.IsSelected);

				break;
			}
		}
	}

	void UpdateTabIconSize(bool isSelected)
	{
		this.TabIconSize = isSelected
			? SelectedTabIconSize
			: DefaultTabIconSize;
	}
	void UpdateTabNameLabelWeight(bool isSelected)
	{
		this.TabNameLabelWeight = isSelected
			? SelectedTabNameLabelWeight
			: DefaultTabNameLabelWeight;
	}
}