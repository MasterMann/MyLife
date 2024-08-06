using System.Globalization;
using System;

using Avalonia.Data.Converters;
using System.Collections;
using MyLife.App.Shared.Utilities.Extensions;
using System.Linq;


namespace MyLife.App.Shared.Utilities.UI.Converters;


public sealed class DictionaryToKeyArrayConverter: IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> value is IDictionary dict
			? dict.Keys
			: null;

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		=> throw new NotSupportedException();
}
