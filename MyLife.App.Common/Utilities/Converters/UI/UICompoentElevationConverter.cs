using System.Globalization;
using System;

using Avalonia.Data.Converters;

namespace MyLife.App.Common.Utilities.Converters.UI;


public sealed class UICompoentElevationConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is string elevationValue && targetType.IsAssignableTo(typeof(string))
            ? $"0 0 10 {elevationValue} LightGray"
            : $"0 0 0 0 LightGray";

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
