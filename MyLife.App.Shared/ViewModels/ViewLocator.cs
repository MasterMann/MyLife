using System;

using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;


namespace MyLife.App.Shared.ViewModels;


public class ViewLocator: IDataTemplate
{
	public Control? Build(object? data)
	{
		var viewModelTypeName = data?.GetType().FullName;

		var viewName = viewModelTypeName?.Replace("ViewModel", "View");
		try
		{
			var type = Type.GetType(viewName);

			if (type != null) return (Control?)Activator.CreateInstance(type);
			else
			{
				return new TextBlock
				{
					Text = $"[View not found for VM: {viewModelTypeName}]",
					VerticalAlignment = VerticalAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Center,
					TextWrapping = Avalonia.Media.TextWrapping.Wrap
				};
			}
		}
		catch (Exception ex)
		{
			return new TextBlock
			{
				Text = $"[Internal exception: {ex.GetType().Name} (${ex.Message})\nView model type: ${viewModelTypeName ?? "<unknown>"}]",
				VerticalAlignment = VerticalAlignment.Center,
				HorizontalAlignment = HorizontalAlignment.Center,
				TextWrapping = Avalonia.Media.TextWrapping.Wrap
			};
		}
	}

	public bool Match(object? data) => data is ViewModelBase;
}
