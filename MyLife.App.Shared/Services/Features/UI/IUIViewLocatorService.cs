using System;

using MyLife.App.Plugins.Core.Services.Features;


namespace MyLife.App.Shared.Services.Features.UI;


public interface IUIViewLocatorService: IServiceFeaturePlugin
{
	public Type? FindViewByViewModel(string viewModelTypeName);
}
