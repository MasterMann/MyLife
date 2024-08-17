using System;
using System.Collections.Generic;
using System.Text;

namespace MyLife.Utilities.BuildTimeAugmentation.Augmentations
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public sealed class AugmentBuildInfoAttribute: Attribute
	{
	}
}
