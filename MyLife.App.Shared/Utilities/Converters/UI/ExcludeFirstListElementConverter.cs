using System.Globalization;
using System;

using Avalonia.Data.Converters;
using System.Collections;
using MyLife.App.Shared.Utilities.Extensions;
using System.Linq;


namespace MyLife.App.Shared.Utilities.Converters.UI;


public sealed class ExcludeFirstListElementConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is IEnumerable list && targetType.IsAssignableTo(typeof(IEnumerable))
            ? list.Cast<object>().Skip(1)
            : null;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
