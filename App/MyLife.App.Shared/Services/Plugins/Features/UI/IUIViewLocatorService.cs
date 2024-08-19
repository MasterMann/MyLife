using System;

using MyLife.App.Shared.Services.Plugins.Features;


namespace MyLife.App.Shared.Services.Plugins.Features.UI;


public interface IUIViewLocatorService: IServiceFeature
{
	public Type? FindViewByViewModel(string viewModelTypeName);
}
