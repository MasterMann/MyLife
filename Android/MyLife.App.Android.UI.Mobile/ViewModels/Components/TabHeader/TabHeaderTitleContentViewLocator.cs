using Avalonia.Controls;
using Avalonia.Controls.Templates;

using MyLife.App.Shared.ViewModels;


namespace MyLife.App.Android.UI.Mobile.ViewModels.Components.TabHeader;


public class TabHeaderTitleContentViewLocator: IDataTemplate
{
	public Control? Build(object? data)
	{
		var viewModelTypeName = data?.GetType().FullName;

		var viewName = viewModelTypeName?.Replace("ViewModel", "View");
		try
		{
			var type = Type.GetType(viewName);

			// TODO: Log if type == null

			return type != null
				? (Control?)Activator.CreateInstance(type)
				: null;
		}
		catch (Exception ex)
		{
			// TODO: Log exception

			return null;
		}
	}

	public bool Match(object? data) => data is ViewModelBase;
}
