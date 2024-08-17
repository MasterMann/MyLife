using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyLife.App.Plugins.Core.Models.Features;


public record FeatureInfo
{
	public string FeatureId { get; init; } = string.Empty;
	public string FeatureName { get; init; } = string.Empty;
	public FeatureType FeatureType { get; init; }
	public bool IsEnabled { get; init; } = true;
}
