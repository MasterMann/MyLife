﻿using System.Globalization;
using System;

using Avalonia.Data.Converters;
using System.Collections;
using MyLife.App.Shared.Utilities.Extensions;
using System.Linq;


namespace MyLife.App.Shared.Utilities.Converters.UI;


public sealed class MathAddValueConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
		return value is double input
			? double.TryParse(parameter!.ToString(), out var operand)
				? input + operand
				: (object)input
			: 0;
	}

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
