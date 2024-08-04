using System;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;

using MyLife.App.Common.Models.UI.Components.Buttons;


namespace MyLife.App.Common.ViewModels.Components.Buttons;


public class IconButtonStyleSelector: DataTemplate, IDataTemplate
{
	public IconButtonStyle Value { get; init; }

	bool IDataTemplate.Match(object? data)
	{
		var enumValue = Enum.Parse<IconButtonStyle>(data?.ToString() ?? string.Empty);
		return this.Value == enumValue;
	}
}
