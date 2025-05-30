// MIT License
//
// Copyright (c) 2023-Present - Violet Hansen - (aka HotCakeX on GitHub) - Email Address: spynetgirl@outlook.com
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// See here for more information: https://github.com/HotCakeX/Harden-Windows-Security/blob/main/LICENSE
//

using System;
using System.Management.Automation;

namespace HardenWindowsSecurity;

internal static class ForceRelocateImagesForFiles
{

	/// <summary>
	/// Method that accepts a string array and disables Mandatory ASLR for them
	/// </summary>
	/// <param name="items">program names to disable mandatory ASLR for</param>
	internal static void SetProcessMitigationForFiles(string[] items)
	{
		// Initialize PowerShell instance
		using PowerShell powerShell = PowerShell.Create();

		foreach (string item in items)
		{
			// Create a command to set process mitigation
			powerShell.Commands.Clear();
			_ = powerShell.AddCommand("Set-ProcessMitigation")
					   .AddParameter("Name", item)
					   .AddParameter("Disable", "ForceRelocateImages");

			// Execute the command and get the result
			try
			{
				_ = powerShell.Invoke();

				// Check for errors
				if (powerShell.Streams.Error.Count > 0)
				{
					foreach (ErrorRecord error in powerShell.Streams.Error)
					{
						Logger.LogMessage($"Error: {error.Exception.Message}", LogTypeIntel.Error);
					}
				}
				else
				{
					Logger.LogMessage($"Excluding {item} from mandatory ASLR.", LogTypeIntel.Information);
				}
			}
			catch (Exception ex)
			{
				Logger.LogMessage($"An exception occurred: {ex.Message}", LogTypeIntel.Error);
			}
		}
	}
}
