using System.Reflection;

using MyLife.App.Android.UI.Mobile.Views;
using MyLife.App.Shared.Models.Plugins.Features.Services;
using MyLife.App.Shared.Services.Plugins.Features.UI;


namespace MyLife.App.Android.UI.Mobile.Services.Features.Services;


public class AndroidMobileUIViewLocator: IUIViewLocatorService
{
	static readonly string ViewRootNamespace = typeof(MobileMainView).Namespace!;

	IReadOnlyList<Type> _uiViewTypes = new List<Type>();

	public ServiceInfo ServiceInfo => new()
	{
		ServiceId = nameof(AndroidMobileUIViewLocator),
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
