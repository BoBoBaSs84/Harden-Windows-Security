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
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation.Host;

namespace HardenWindowsSecurity;

public static class GlobalVars
{
	// Minimum required OS build number
	internal const decimal requiredBuild = 22621.4169M;

	// Current OS build version
	internal static readonly decimal OSBuildNumber = Environment.OSVersion.Version.Build;

	// Update Build Revision (UBR) number
	internal static int UBR;

	// Create full OS build number as seen in Windows Settings
	internal static string? FullOSBuild;

#pragma warning disable CS8618
	// Stores the value of $PSScriptRoot in a global variable to allow the internal functions to use it when navigating the module structure
	// The check for being empty or whitespace is performed in the Initializer class.
	public static string path;
#pragma warning restore

	// Stores the MpComputerStatus CIM results
	public static dynamic? MDAVConfigCurrent;

	// Stores the MpPreference CIM results
	public static dynamic? MDAVPreferencesCurrent;

	// Total number of Compliant values
	public static int TotalNumberOfTrueCompliantValues;

	// The working directory used by the Protect-WindowsSecurity cmdlet
	internal static string WorkingDir = Path.Combine(Path.GetTempPath(), "HardeningXStuff");

	// Defining a boolean variable to determine whether optional diagnostic data should be enabled for Smart App Control or not
	public static bool ShouldEnableOptionalDiagnosticData;

	// Variable indicating whether user launched the module with Offline parameter or not
	public static bool Offline;

	// To track whether the header has been added to the log file
	internal static bool LogHeaderHasBeenWritten;

	// Path to the Microsoft Security Baselines directory after extraction
	internal static string? MicrosoftSecurityBaselinePath;

	// The path to the Microsoft 365 Security Baseline directory after extraction
	internal static string? Microsoft365SecurityBaselinePath;

	// The path to the LGPO.exe utility
	internal static string? LGPOExe;

	// Initialize the RegistryCSVItems list so that the HardeningRegistryKeys.ReadCsv() method can write to it
	internal static readonly List<HardeningRegistryKeys.CsvRecord> RegistryCSVItems = [];

	// To store the Process mitigations CSV parse output used by all cmdlets - ProcessMitigations.csv
	// Initialize the ProcessMitigations list so that the ProcessMitigationsParser.ReadCsv() method can write to it
	internal static readonly List<ProcessMitigationsParser.ProcessMitigationsRecords> ProcessMitigations = [];

	// a global variable to save the output of the [HardenWindowsSecurity.ProtectionCategoriex]::New().GetValidValues() in
	public static string[] HardeningCategorieX = ProtectionCategoriex.GetValidValues();

	// the explicit path to save the security_policy.inf file
	internal static string securityPolicyInfPath = Path.Combine(WorkingDir, "security_policy.inf");

	// Backup of the current Controlled Folder Access List
	// Used to be restored at the end of the operation
	internal static string[]? CFABackup;

	// The value of the automatic variable $HOST from the PowerShell session
	// Stored from the module root .psm1 file
	public static PSHost? Host;

	// The value of the VerbosePreference variable of the PowerShell session
	// stored at the beginning of each cmdlet in the begin block through the Initialize() method
	public static string? VerbosePreference;

	// To track the load of the DLLs in the module that occurs at the beginning of each cmdlet
	public static bool RequiredDLLsLoaded;

	public const string ReRunText = "Re-running the module because of a possible dependency conflict with other modules such as CommandNotFound in PowerToys";

	// Create an empty ConcurrentDictionary to store the final results of the cmdlets
	public static readonly ConcurrentDictionary<ComplianceCategories, List<IndividualResult>> FinalMegaObject = [];

	// Create an empty dictionary to store the System Security Policies from the security_policy.inf file
	internal static Dictionary<string, Dictionary<string, string>> SystemSecurityPoliciesIniObject = [];

	// To store the security policies CSV file parse output
	internal static List<SecurityPolicyRecord>? SecurityPolicyRecords;

	// The explicit path to save the CurrentlyAppliedMitigations.xml file
	internal static string CurrentlyAppliedMitigations = Path.Combine(WorkingDir, "CurrentlyAppliedMitigations.xml");

	// Contains the results of all of the related MDM CimInstances that can be interacted with using Administrator privilege
	internal static List<MDMClassProcessor>? MDMResults;

	// To store the Firewall Domain MDM profile parsed JSON output
	internal static Hashtable? MDM_Firewall_DomainProfile02;

	// To store the Firewall Private MDM profile parsed JSON output
	internal static Hashtable? MDM_Firewall_PrivateProfile02;

	// To store the Firewall Public MDM profile parsed JSON output
	internal static Hashtable? MDM_Firewall_PublicProfile02;

	// To store the Windows Update MDM parsed JSON output
	internal static Hashtable? MDM_Policy_Result01_Update02;

	// To store the System MDM parsed JSON output
	internal static Hashtable? MDM_Policy_Result01_System02;

	// To store the path to the system drive
	internal static readonly string SystemDrive = Environment.GetEnvironmentVariable("SystemDrive") ?? "C:";
}
