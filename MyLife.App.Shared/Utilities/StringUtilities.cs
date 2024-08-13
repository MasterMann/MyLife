﻿namespace MyLife.App.Shared.Utilities;


internal static class StringUtilities
{
	public static string SplitLast(this string str, char separator)
		=> str[(str.LastIndexOf(separator) + 1)..str.Length];

	public static string SplitEnd(this string str, string value)
	{
		if (!str.EndsWith(value)) return str;

		var result = str.Split(value);
		return result[^2];
	}
}
