using System;
using System.IO;

namespace HardenWindowsSecurity;

public static partial class LockScreen
{
	/// <summary>
	/// Will require CTRL + ALT + DEL keys to be pressed on lock screen during logon
	/// </summary>
	/// <exception cref="ArgumentNullException"></exception>
	public static void LockScreen_CtrlAltDel()
	{
		Logger.LogMessage("Applying the Enable CTRL + ALT + DEL policy", LogTypeIntel.Information);
		LGPORunner.RunLGPOCommand(Path.Combine(GlobalVars.path, "Resources", "Security-Baselines-X", "Lock Screen Policies", "Enable CTRL + ALT + DEL", "GptTmpl.inf"), LGPORunner.FileType.INF);
	}
}
