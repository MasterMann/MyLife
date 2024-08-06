using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyLife.App.Plugins.Core.Models.Features.TabContent;


public record TabContentInfo
{
	public string TabId { get; init; } = Guid.NewGuid().ToString();
	public string TabName { get; init; } = "[Unknown]";
}
