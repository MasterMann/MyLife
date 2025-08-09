using System.ComponentModel;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

using MyLife.App.Shared.UI.Tabs.ViewModels.Components.TabNavigation;


namespace MyLife.App.Shared.UI.Tabs.Views.Components.TabNavigation;


public partial class TabNavigationItemView: UserControl
{
	static int DefaultTabIconSize = 20;
	static int SelectedTabIconSize = 24;

	static FontWeight DefaultTabNameLabelWeight = FontWeight.Regular;
	static FontWeight SelectedTabNameLabelWeight = FontWeight.Bold;

	public static readonly StyledProperty<int> TabIconSizeProperty =
		AvaloniaProperty.Register<TabNavigationItemView, int>(nameof(TabIconSize), defaultValue: DefaultTabIconSize);

	public static readonly StyledProperty<FontWeight> TabNameLabelWeightProperty =
		AvaloniaProperty.Register<TabNavigationItemView, FontWeight>(nameof(TabNameLabelWeight), defaultValue: DefaultTabNameLabelWeight);

	public int TabIconSize
	{
		get => this.GetValue(TabIconSizeProperty);
		set => this.SetValue(TabIconSizeProperty, value);
	}

	public FontWeight TabNameLabelWeight
	{
		get => this.GetValue(TabNameLabelWeightProperty);
		set => this.SetValue(TabNameLabelWeightProperty, value);
	}

	TabNavigationItemViewModel _vm;

	public TabNavigationItemView()
    {
        this.InitializeComponent();

		this.Loaded += this.OnLoaded;
	}

	void OnLoaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		var vm = (TabNavigationItemViewModel)this.DataContext;
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
			case nameof(TabNavigationItemViewModel.IsSelected):
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