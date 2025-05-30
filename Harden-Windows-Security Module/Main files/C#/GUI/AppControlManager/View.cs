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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Management.Deployment;

#pragma warning disable IDE0063

namespace HardenWindowsSecurity;

public partial class GUIMain
{
	public partial class NavigationVM : ViewModelBase
	{

		// Method to handle the AppControlManager view, including loading
		private void AppControlManagerView(object? obj)
		{

			// Check if the view is already cached
			if (_viewCache.TryGetValue("AppControlManagerView", out var cachedView))
			{
				CurrentView = cachedView;
				return;
			}

			// if Admin privileges are not available, return and do not proceed any further
			// Will prevent the page from being loaded since the CurrentView won't be set/changed
			if (!Environment.IsPrivilegedProcess)
			{
				Logger.LogMessage("AppControl Manager section can only be used when running the Harden Windows Security Application with Administrator privileges", LogTypeIntel.ErrorInteractionRequired);
				return;
			}

			// Read the XAML content from the file
			string xamlContent = File.ReadAllText(Path.Combine(GlobalVars.path, "Resources", "XAML", "AppControlManager.xaml"));

			// Parse the XAML content to create a UserControl
			GUIAppControlManager.View = (UserControl)XamlReader.Parse(xamlContent);

			// Find the elements
			GUIAppControlManager.ParentGrid = (Grid)GUIAppControlManager.View.FindName("ParentGrid");
			Button InstallAppControlManagerButton = (Button)GUIAppControlManager.ParentGrid.FindName("InstallAppControlManagerButton");
			Button ViewDemoOnYouTubeButton = (Button)GUIAppControlManager.ParentGrid.FindName("ViewDemoOnYouTubeButton");
			Button AccessTheGuideOnGitHubButton = (Button)GUIAppControlManager.ParentGrid.FindName("AccessTheGuideOnGitHubButton");
			Button InstallAppControlManagerFromMicrosoftStoreButton = (Button)GUIAppControlManager.ParentGrid.FindName("InstallAppControlManagerFromMicrosoftStoreButton");
			Image ViewDemoOnYouTubeButtonIcon = (Image)GUIAppControlManager.ParentGrid.FindName("ViewDemoOnYouTubeButtonIcon");
			Image AccessTheGuideOnGitHubButtonIcon = (Image)GUIAppControlManager.ParentGrid.FindName("AccessTheGuideOnGitHubButtonIcon");
			Image InstallAppControlManagerButtonIcon = (Image)GUIAppControlManager.ParentGrid.FindName("InstallAppControlManagerButtonIcon");
			Image InstallAppControlManagerFromMicrosoftStoreButtonIcon = (Image)GUIAppControlManager.ParentGrid.FindName("InstallAppControlManagerFromMicrosoftStoreButtonIcon");
			ProgressBar MainProgressBar = (ProgressBar)GUIAppControlManager.ParentGrid.FindName("MainProgressBar");

			#region Assigning icon images for the buttons

			BitmapImage BitmapImage1 = new();
			BitmapImage1.BeginInit();
			BitmapImage1.UriSource = new Uri(Path.Combine(GlobalVars.path, "Resources", "Media", "YouTubeIcon.png"));
			BitmapImage1.CacheOption = BitmapCacheOption.OnLoad;
			BitmapImage1.EndInit();
			ViewDemoOnYouTubeButtonIcon.Source = BitmapImage1;

			BitmapImage BitmapImage2 = new();
			BitmapImage2.BeginInit();
			BitmapImage2.UriSource = new Uri(Path.Combine(GlobalVars.path, "Resources", "Media", "GitHubIcon.png"));
			BitmapImage2.CacheOption = BitmapCacheOption.OnLoad;
			BitmapImage2.EndInit();
			AccessTheGuideOnGitHubButtonIcon.Source = BitmapImage2;

			BitmapImage BitmapImage3 = new();
			BitmapImage3.BeginInit();
			BitmapImage3.UriSource = new Uri(Path.Combine(GlobalVars.path, "Resources", "Media", "InstallAppControlManagerIcon.png"));
			BitmapImage3.CacheOption = BitmapCacheOption.OnLoad;
			BitmapImage3.EndInit();
			InstallAppControlManagerButtonIcon.Source = BitmapImage3;

			BitmapImage BitmapImage4 = new();
			BitmapImage4.BeginInit();
			BitmapImage4.UriSource = new Uri(Path.Combine(GlobalVars.path, "Resources", "Media", "MicrosoftStore.png"));
			BitmapImage4.CacheOption = BitmapCacheOption.OnLoad;
			BitmapImage4.EndInit();
			InstallAppControlManagerFromMicrosoftStoreButtonIcon.Source = BitmapImage4;

			#endregion

			// Register the elements that will be enabled/disabled based on current activity
			ActivityTracker.RegisterUIElement(InstallAppControlManagerButton);

			// Event handler for the Install button
			InstallAppControlManagerButton.Click += async (sender, e) =>
			{
				// Only continue if there is no activity other places
				if (ActivityTracker.IsActive)
				{
					return;
				}

				try
				{

					// mark as activity started
					ActivityTracker.IsActive = true;


					#region Ensure the app is not already installed

					bool alreadyInstalled = false;
					Package? PossibleExistingPackage = null;

					await Task.Run(() =>
					{
						IEnumerable<Package> PossibleExistingApp = GUIAppControlManager.packageMgr.FindPackages("AppControlManager", "CN=SelfSignedCertForAppControlManager");

						PossibleExistingPackage = PossibleExistingApp.FirstOrDefault();

						alreadyInstalled = PossibleExistingPackage is not null;
					});

					if (alreadyInstalled)
					{
						Logger.LogMessage($"AppControl Manager version {PossibleExistingPackage?.Id.Version.Major}.{PossibleExistingPackage?.Id.Version.Minor}.{PossibleExistingPackage?.Id.Version.Build}.{PossibleExistingPackage?.Id.Version.Revision} is already installed. If you want to update it, please start the AppControl Manager then navigate to the Update page to update it. If you want to reinstall it, please uninstall it first.", LogTypeIntel.InformationInteractionRequired);
						return;
					}

					#endregion


					using HttpClient client1 = new();

					Logger.LogMessage("Getting the download link from GitHub", LogTypeIntel.Information);

					// Store the download link to the latest available version
					Uri onlineDownloadURL = new(await client1.GetStringAsync(GUIAppControlManager.AppUpdateDownloadLinkURL));

					// The Uri will be used to detect the version and architecture of the MSIXBundle being installed
					string sourceForRegex = onlineDownloadURL.ToString();

					Logger.LogMessage("Downloading the AppControl Manager MSIXBundle...", LogTypeIntel.Information);

					string AppControlManagerSavePath = Path.Combine(GlobalVars.WorkingDir, "AppControlManager.msixbundle");

					MainProgressBar.Visibility = Visibility.Visible;

					using (HttpClient client = new())
					{
						// Send an Async get request to the url and specify to stop reading after headers are received for better efficiently
						using (HttpResponseMessage response = await client.GetAsync(onlineDownloadURL, HttpCompletionOption.ResponseHeadersRead))
						{
							// Ensure that the response is successful (status code 2xx); otherwise, throw an exception
							_ = response.EnsureSuccessStatusCode();

							// Retrieve the total file size from the Content-Length header (if available)
							long? totalBytes = response.Content.Headers.ContentLength;

							// Open a stream to read the response content asynchronously
							await using (Stream contentStream = await response.Content.ReadAsStreamAsync())
							{
								// Open a file stream to save the downloaded data locally
								await using (FileStream fileStream = new(
									AppControlManagerSavePath,       // Path to save the file
									FileMode.Create,                 // Create a new file or overwrite if it exists
									FileAccess.Write,                // Write-only access
									FileShare.None,                  // Do not allow other processes to access the file
									bufferSize: 8192,                // Set buffer size to 8 KB
									useAsync: true))                 // Enable asynchronous operations for the file stream
								{
									// Define a buffer to hold data chunks as they are read
									byte[] buffer = new byte[8192];
									long totalReadBytes = 0;         // Track the total number of bytes read
									int readBytes;                   // Holds the count of bytes read in each iteration
									double lastReportedProgress = 0; // Tracks the last reported download progress

									// Loop to read from the content stream in chunks until no more data is available
									while ((readBytes = await contentStream.ReadAsync(buffer)) > 0)
									{
										// Write the buffer to the file stream
										await fileStream.WriteAsync(buffer.AsMemory(0, readBytes));
										totalReadBytes += readBytes;  // Update the total bytes read so far

										// If the total file size is known, calculate and report progress
										if (totalBytes.HasValue)
										{
											// Calculate the current download progress as a percentage
											double progressPercentage = (double)totalReadBytes / totalBytes.Value * 100;

											// Only update the ProgressBar if progress has increased by at least 1% to avoid constantly interacting with the UI thread
											if (progressPercentage - lastReportedProgress >= 1)
											{
												// Update the last reported progress
												lastReportedProgress = progressPercentage;

												// Update the UI ProgressBar value on the dispatcher thread

												Application.Current.Dispatcher.Invoke(() =>
											   {
												   MainProgressBar.Value = progressPercentage;
											   });
											}
										}
									}
								}
							}
						}
					}

					Logger.LogMessage($"The AppControl Manager MSIXBundle has been successfully downloaded to {AppControlManagerSavePath}", LogTypeIntel.Information);

					MainProgressBar.Visibility = Visibility.Collapsed;

					Logger.LogMessage("Detecting/Downloading the SignTool.exe from the Microsoft servers", LogTypeIntel.Information);

					string signToolPath = await Task.Run(() => SignToolHelper.GetSignToolPath());

					Logger.LogMessage("All Downloads finished, installing the new AppControl Manager version", LogTypeIntel.Information);

					await Task.Run(() =>
					{

						string randomPassword = Guid.CreateVersion7().ToString("N");

						// Common name of the certificate
						string commonName = "SelfSignedCertForAppControlManager";

						// Path where the .cer file will be saved
						string CertificateOutputPath = Path.Combine(GlobalVars.WorkingDir, $"{commonName}.cer");

						// Remove any certificates with the specified common name that may already exist on the system form previous attempts
						CertificateGenerator.DeleteCertificateByCN(commonName);

						// Generate a new certificate
						X509Certificate2 generatedCert = CertificateGenerator.GenerateSelfSignedCertificate(
						subjectName: commonName,
						validityInYears: 100,
						keySize: 4096,
						hashAlgorithm: HashAlgorithmName.SHA512,
						storeLocation: CertificateGenerator.CertificateStoreLocation.Machine,
						cerExportFilePath: CertificateOutputPath,
						friendlyName: commonName,
						UserProtectedPrivateKey: false,
						ExportablePrivateKey: false);

						// Signing the App Control Manager MSIXBundle
						// In this step the SignTool detects the cert to use based on Common name + ThumbPrint + Hash Algo + Store Type + Store Name
						ProcessStarter.RunCommand(signToolPath, $"sign /debug /n \"{commonName}\" /fd Sha512 /sm /s Root /sha1 {generatedCert.Thumbprint} \"{AppControlManagerSavePath}\"");

						// Remove any certificates with the specified common name again
						// Because the existing one contains private keys and don't want that
						CertificateGenerator.DeleteCertificateByCN(commonName);

						// Adding the certificate to the 'Local Machine/Trusted Root Certification Authorities' store with public key only. This safely stores the certificate on your device, ensuring its private key does not exist so cannot be used to sign anything else
						CertificateGenerator.StoreCertificateInStore(generatedCert, CertificateGenerator.CertificateStoreLocation.Machine, true);

						try
						{

							// Get the current Defender configurations
							GlobalVars.MDAVPreferencesCurrent = MpPreferenceHelper.GetMpPreference();

							// Get the current ASR Rules Exclusions lists
							string[]? currentAttackSurfaceReductionExclusions = PropertyHelper.GetPropertyValue(GlobalVars.MDAVPreferencesCurrent, "AttackSurfaceReductionOnlyExclusions");

							// If there are ASR rule exclusions, find ones that belong to AppControl Manager and remove them
							// Before adding new ones for the new version
							if (currentAttackSurfaceReductionExclusions is not null)
							{

								List<string> asrRulesToRemove = [];

								// Find all the rules that belong to the AppControl Manager
								foreach (string item in currentAttackSurfaceReductionExclusions)
								{
									if (Regex.Match(item, "__sadt7br7jpt02").Success)
									{
										asrRulesToRemove.Add(item);
									}
								}

								// If any of the rules belong to the AppControl Manager
								if (asrRulesToRemove.Count > 0)
								{
									string[] stringArrayRepo = [.. asrRulesToRemove];

									// Remove ASR rule exclusions that belong to the previous app version
									using ManagementClass managementClass = new(@"root\Microsoft\Windows\Defender", "MSFT_MpPreference", null);
									ManagementBaseObject inParams = managementClass.GetMethodParameters("Remove");
									inParams["AttackSurfaceReductionOnlyExclusions"] = stringArrayRepo;
									_ = managementClass.InvokeMethod("Remove", inParams, null);
								}
							}
						}

						catch (Exception ex)
						{
							Logger.LogMessage($"An error occurred while trying to remove the ASR rule exclusions which you can ignore: {ex.Message}", LogTypeIntel.Information);
						}


						Logger.LogMessage("Installing AppControl Manager MSIXBundle", LogTypeIntel.Information);

						// https://learn.microsoft.com/en-us/uwp/api/windows.management.deployment.addpackageoptions
						AddPackageOptions options = new()
						{
							DeferRegistrationWhenPackagesAreInUse = false,
							ForceUpdateFromAnyVersion = true
						};

						IAsyncOperationWithProgress<DeploymentResult, DeploymentProgress> deploymentOperation = GUIAppControlManager.packageMgr.AddPackageByUriAsync(new Uri(AppControlManagerSavePath), options);

						// This event is signaled when the operation completes
						ManualResetEvent opCompletedEvent = new(false);

						// Define the delegate using a statement lambda
						deploymentOperation.Completed = (depProgress, status) => { _ = opCompletedEvent.Set(); };

						// Wait until the operation completes
						_ = opCompletedEvent.WaitOne();

						// Check the status of the operation
						if (deploymentOperation.Status == AsyncStatus.Error)
						{
							DeploymentResult deploymentResult = deploymentOperation.GetResults();
							throw new InvalidOperationException("Installation failed with the code: " + deploymentOperation.ErrorCode + " And error message: " + deploymentResult.ErrorText);
						}
						else if (deploymentOperation.Status == AsyncStatus.Canceled)
						{
							Logger.LogMessage("AppControl Manager installation has been cancelled.", LogTypeIntel.Warning);
						}
						else if (deploymentOperation.Status == AsyncStatus.Completed)
						{
							Logger.LogMessage($"AppControl Manager installation has been successful.", LogTypeIntel.InformationInteractionRequired);
						}
						else
						{
							throw new InvalidOperationException("An unknown error occurred during AppControl Manager installation.");
						}


						try
						{

							#region Add new exclusions

							Package AppControlManagerPackage = GUIAppControlManager.packageMgr.FindPackages("AppControlManager_sadt7br7jpt02").First();

							string AppControlInstallFolder = AppControlManagerPackage.EffectivePath;

							// Construct the paths to the .exe and .dll files of the AppControl Manager
							string path1 = Path.Combine(AppControlInstallFolder, "AppControlManager.exe");
							string path2 = Path.Combine(AppControlInstallFolder, "AppControlManager.dll");

							ConfigDefenderHelper.ManageMpPreference("AttackSurfaceReductionOnlyExclusions", new string[] { path1, path2 }, false);

							#endregion

						}

						catch (Exception ex)
						{
							Logger.LogMessage($"An error occurred while trying to add the ASR rule exclusions which you can ignore: {ex.Message}", LogTypeIntel.Information);
						}


						#region Check for incompatible policy
						try
						{
							using (RegistryKey? key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"))
							{
								if (key is not null)
								{
									// Get the registry value
									object? registryValue = key.GetValue("ValidateAdminCodeSignatures");

									if (registryValue is not null && string.Equals(registryValue.ToString(), "1", StringComparison.OrdinalIgnoreCase))
									{

										Logger.LogMessage("A policy named 'Only elevate executables that are signed and validated' " +
											"is conflicting with the AppControl Manager app and won't let it start because it's self-signed " +
											"with your on-device keys. Please disable the policy. It can be found in Group Policy Editor -> " +
											"Computer Configuration -> Windows Settings -> Security Settings -> Local Policies -> Security Options -> " +
											"'User Account Control: Only elevate executable files that are signed and validated'", LogTypeIntel.WarningInteractionRequired);
									}
								}
							}
						}
						catch
						{
							Logger.LogMessage("Could not verify that 'Only Elevate signed' policy is not active.", LogTypeIntel.Warning);
						}
						#endregion

					});
				}

				finally
				{
					// mark as activity completed
					ActivityTracker.IsActive = false;
				}
			};


			ViewDemoOnYouTubeButton.Click += (sender, e) =>
			{
				_ = Process.Start(new ProcessStartInfo
				{
					FileName = "https://youtu.be/SzMs13n7elE?si=S70QiB5ZlYdhMk9r",
					UseShellExecute = true // Ensure the link opens in the default browser
				});
			};

			AccessTheGuideOnGitHubButton.Click += (sender, e) =>
			{
				_ = Process.Start(new ProcessStartInfo
				{
					FileName = "https://github.com/HotCakeX/Harden-Windows-Security/wiki/AppControl-Manager",
					UseShellExecute = true // Ensure the link opens in the default browser
				});
			};


			// Event handler that opens Microsoft Store
			InstallAppControlManagerFromMicrosoftStoreButton.Click += (sender, e) =>
			{
				_ = Process.Start(new ProcessStartInfo
				{
					FileName = "https://apps.microsoft.com/detail/9png1jddtgp8",
					UseShellExecute = true
				});
			};


			// Cache the view before setting it as the CurrentView
			_viewCache["AppControlManagerView"] = GUIAppControlManager.View;

			CurrentView = GUIAppControlManager.View;
		}
	}
}
