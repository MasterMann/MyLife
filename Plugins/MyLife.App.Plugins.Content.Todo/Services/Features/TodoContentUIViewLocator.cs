using System.Reflection;

using MyLife.App.Plugins.Content.Todo.Views;
using MyLife.App.Plugins.Core.Models.Features.Services;
using MyLife.App.Shared.Models.Features.Services;
using MyLife.App.Shared.Services.Features.UI;


namespace MyLife.App.Plugins.Content.Todo.Services.Features;


public class TodoContentUIViewLocator: IUIViewLocatorService
{
	static readonly string ViewRootNamespace = typeof(TodoTabContentView).Namespace!;

	IReadOnlyList<Type> _uiViewTypes = new List<Type>();

	public ServiceInfo ServiceInfo => new()
	{
		ServiceId = nameof(TodoContentUIViewLocator),
		Capability = DefaultServiceCapabilities.UI_VIEW_LOCATOR
	};

	public Type? FindViewByViewModel(string viewModelTypeName)
	{
		var viewTypeName = viewModelTypeName.Replace("ViewModel", "View");

		return this._uiViewTypes.FirstOrDefault(t => t.FullName!.Equals(viewTypeName));
	}
	public void Initialize()
	{
		var test = Assembly.GetExecutingAssembly().GetExportedTypes().Where(x => x.Namespace!.StartsWith(ViewRootNamespace));

		this._uiViewTypes = new List<Type>(test);
	}
	public void Shutdown()
	{

	}
}
