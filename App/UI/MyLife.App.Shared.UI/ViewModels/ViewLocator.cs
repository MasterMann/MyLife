using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;

using MyLife.App.Shared.ViewModels;


namespace MyLife.App.Shared.UI.ViewModels;


public class ViewLocator: IDataTemplate
{
	public Control? Build(object? data)
	{
		var viewModelTypeName = data?.GetType().FullName;

		var viewName = viewModelTypeName?.Replace("ViewModel", "View");
		try
		{
			var type = Type.GetType(viewName);

			return (type != null)
				? (Control?)Activator.CreateInstance(type)
				: new TextBlock
					{
						Text = $"[View not found for VM: {viewModelTypeName}]",
						VerticalAlignment = VerticalAlignment.Center,
						HorizontalAlignment = HorizontalAlignment.Center,
						TextWrapping = Avalonia.Media.TextWrapping.Wrap
					};
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
