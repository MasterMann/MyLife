using System;
using System.ComponentModel;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;


namespace MyLife.App.Shared.UI.Utilities;


//public class ContentEnumValueSelector<TEnum>: DataTemplate, IDataTemplate
//	where TEnum: Enum
//{
//	[TypeConverter(typeof(EnumConverter))]
//	public TEnum Value { get; init; }

//	protected ContentEnumValueSelector(TEnum value) => this.Value = value;

//	bool IDataTemplate.Match(object? data)
//	{
//		var enumValue = (TEnum)Enum.Parse(typeof(TEnum), data?.ToString() ?? string.Empty);
//		return this.Value == enumValue;
//	}
//}
