using System.Globalization;

using Avalonia.Data.Converters;
using MyLife.App.Shared.UI.ViewModels.Components.Buttons;
using MyLife.App.Shared.UI.Models.Components.Buttons;
using MyLife.App.Shared.UI.Tabs.ViewModels.Components.TabHeader;


namespace MyLife.App.Shared.UI.Tabs.Utilities.Converters.Components.TabHeader;


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
