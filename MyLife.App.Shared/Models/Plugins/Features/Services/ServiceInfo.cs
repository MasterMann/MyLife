using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyLife.App.Shared.Models.Plugins.Features.Services;


public record ServiceInfo
{
	public string ServiceId { get; init; } = string.Empty;
	public string Capability { get; init; } = string.Empty;
}
