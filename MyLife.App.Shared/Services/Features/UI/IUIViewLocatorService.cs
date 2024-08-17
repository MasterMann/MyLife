using System;

using MyLife.App.Plugins.Core.Services.Features;


namespace MyLife.App.Shared.Services.Features.UI;


public interface IUIViewLocatorService: IServiceFeature
{
	public Type? FindViewByViewModel(string viewModelTypeName);
}
