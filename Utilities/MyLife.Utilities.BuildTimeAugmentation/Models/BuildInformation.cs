using System;
using System.Collections.Generic;
using System.Text;


namespace MyLife.Utilities;


public class BuildInformation
{
	/// <summary>
	/// Returns the build date timestamp, in Unix seconds (UTC).
	/// </summary>
	public uint BuildTimestamp { get; set; } = 0;

	/// <summary>
	/// Returns the build version number (X.X.X.X) of the assembly.
	/// </summary>
	public string BuildVersion { get; set; } = string.Empty;

	/// <summary>
	/// Returns the build configuration (debug/release).
	/// </summary>
	public string BuildConfig { get; set; } = string.Empty;

	/// <summary>
	/// Returns the target platform of the assembly.
	/// </summary>
	public string TargetPlatform { get; set; } = string.Empty;
}
