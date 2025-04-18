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
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AppControlManager.Main;
using AppControlManager.Others;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace AppControlManager.Pages;

/// <summary>
/// Handles the file selection and computes various cryptographic hashes for the selected file. Displays the results in
/// the UI.
/// </summary>
internal sealed partial class GetCIHashes : Page
{
	private AppSettings.Main AppSettings { get; } = App.AppHost.Services.GetRequiredService<AppSettings.Main>();

	/// <summary>
	/// Initializes the component and sets the navigation cache mode to required for the GetCIHashes class.
	/// </summary>
	internal GetCIHashes()
	{
		this.InitializeComponent();
		this.NavigationCacheMode = NavigationCacheMode.Required;
	}

	/// <summary>
	/// Event handler for the browse button
	/// </summary>
	private async void PickFile_Click()
	{
		try
		{
			PickFileButton.IsEnabled = false;

			string? selectedFile = FileDialogHelper.ShowFilePickerDialog(GlobalVars.AnyFilePickerFilter);

			if (string.IsNullOrWhiteSpace(selectedFile))
			{
				return;
			}

			// Clear the UI text boxes
			Sha1PageTextBox.Text = null;
			Sha256PageTextBox.Text = null;
			Sha1AuthenticodeTextBox.Text = null;
			Sha256AuthenticodeTextBox.Text = null;
			SHA3384FlatHash.Text = null;
			SHA3512FlatHash.Text = null;

			Sha1PageProgressRing.Visibility = Visibility.Visible;
			Sha256PageProgressRing.Visibility = Visibility.Visible;
			Sha1AuthenticodeProgressRing.Visibility = Visibility.Visible;
			Sha256AuthenticodeProgressRing.Visibility = Visibility.Visible;

			CodeIntegrityHashes hashes = await Task.Run(() => CiFileHash.GetCiFileHashes(selectedFile));

			// Display the hashes in the UI
			Sha1PageTextBox.Text = hashes.SHA1Page ?? "N/A";
			Sha256PageTextBox.Text = hashes.SHA256Page ?? "N/A";
			Sha1AuthenticodeTextBox.Text = hashes.SHa1Authenticode ?? "N/A";
			Sha256AuthenticodeTextBox.Text = hashes.SHA256Authenticode ?? "N/A";

			Sha1PageProgressRing.Visibility = Visibility.Collapsed;
			Sha256PageProgressRing.Visibility = Visibility.Collapsed;
			Sha1AuthenticodeProgressRing.Visibility = Visibility.Collapsed;
			Sha256AuthenticodeProgressRing.Visibility = Visibility.Collapsed;

			string? SHA3_512Hash = null;
			string? SHA3_384Hash = null;

			if (GlobalVars.IsOlderThan24H2)
			{
				SHA3_512Hash = "Requires Windows 11 24H2 or later";
				SHA3_384Hash = "Requires Windows 11 24H2 or later";
			}
			else
			{

				SHA3384FlatHashProgressRing.Visibility = Visibility.Visible;
				SHA3512FlatHashProgressRing.Visibility = Visibility.Visible;

				await Task.Run(() =>
				{

					// Initializing the hash algorithms for SHA3-512 and SHA3-384
					using SHA3_512 sha3_512 = SHA3_512.Create();
					using SHA3_384 sha3_384 = SHA3_384.Create();

					// Opening the file as a stream to read it in chunks, this way we can handle large files
					using (FileStream fs = new(selectedFile, FileMode.Open, FileAccess.Read))
					{
						// Defining a buffer size of 4MB to read the file in manageable chunks
						byte[] buffer = new byte[4 * 1024 * 1024];

						int bytesRead;

						// Read the file in chunks and update the hash algorithms with the chunk data
						while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
						{
							// Update SHA3-512 hash with the current chunk
							_ = sha3_512.TransformBlock(buffer, 0, bytesRead, null, 0);

							// Update SHA3-384 hash with the current chunk
							_ = sha3_384.TransformBlock(buffer, 0, bytesRead, null, 0);
						}

						// Finalize the SHA3-512 hash computation
						_ = sha3_512.TransformFinalBlock([], 0, 0);

						// Finalize the SHA3-384 hash computation
						_ = sha3_384.TransformFinalBlock([], 0, 0);
					}

					if (sha3_512.Hash is not null)

					{   // Convert the SHA3-512 hash bytes to a hexadecimal string
						SHA3_512Hash = Convert.ToHexString(sha3_512.Hash);
					}

					if (sha3_384.Hash is not null)
					{
						// Convert the SHA3-384 hash bytes to a hexadecimal string
						SHA3_384Hash = Convert.ToHexString(sha3_384.Hash);
					}

				});

				SHA3384FlatHashProgressRing.Visibility = Visibility.Collapsed;
				SHA3512FlatHashProgressRing.Visibility = Visibility.Collapsed;
			}

			// Display the rest of the hashes in the UI
			SHA3384FlatHash.Text = SHA3_384Hash ?? "N/A";
			SHA3512FlatHash.Text = SHA3_512Hash ?? "N/A";

		}
		finally
		{
			PickFileButton.IsEnabled = true;
		}
	}

}
