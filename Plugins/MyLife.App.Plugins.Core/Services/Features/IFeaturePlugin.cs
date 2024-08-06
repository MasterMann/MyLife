using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLife.App.Plugins.Core.Models.Features;


namespace MyLife.App.Plugins.Core.Services.Features;


public interface IFeaturePlugin
{
	public FeaturePluginInfo FeatureInfo { get; }

	public abstract void Initialize();
	public abstract void Shutdown();
}
