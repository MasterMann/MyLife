using System.Globalization;
using System;

using Avalonia.Data.Converters;
using System.Collections;
using MyLife.App.Shared.Utilities.Extensions;
using System.Linq;


namespace MyLife.App.Shared.Utilities.Converters.UI;


public sealed class DictionaryToValueArrayConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is IDictionary dict
            ? dict.Values
            : null;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
