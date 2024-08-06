using System.Globalization;

using Avalonia.Data.Converters;
using MyLife.App.Android.UI.Mobile.ViewModels.Components.TabHeader;
using MyLife.App.Shared.ViewModels.Components.Buttons;
using MyLife.App.Shared.Models.UI.Components.Buttons;
using CommunityToolkit.Mvvm.Input;


namespace MyLife.App.Android.UI.Mobile.Utilities.Converters.Components.TabHeader;


public sealed class TabHeaderActionButtonVMConverter: IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	=> value is TabHeaderActionViewModel action
		? new IconButtonViewModel
		{
			Id = action.ActionId,
			IconId = action.IconId,
			IsEnabled = action.IsEnabled,
			Label = action.DisplayName,
			Style = IconButtonStyle.ICON,
			Command = action.TriggerCommand
		}
		: null;

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();
}
