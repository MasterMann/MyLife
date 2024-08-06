using System;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;

using MyLife.App.Shared.UI.Models.Components.Buttons;


namespace MyLife.App.Shared.UI.ViewModels.Components.Buttons;


public class IconButtonStyleSelector: DataTemplate, IDataTemplate
{
	public IconButtonStyle Value { get; init; }

	bool IDataTemplate.Match(object? data)
	{
		var enumValue = Enum.Parse<IconButtonStyle>(data?.ToString() ?? string.Empty);
		return this.Value == enumValue;
	}
}
