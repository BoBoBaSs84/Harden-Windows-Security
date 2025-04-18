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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppControlManager.Main;
using AppControlManager.Others;
using AppControlManager.ViewModels;
using CommunityToolkit.WinUI;
using CommunityToolkit.WinUI.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Navigation;
using Windows.ApplicationModel.DataTransfer;

namespace AppControlManager.Pages;

/// <summary>
/// Represents a simulation page that initializes components, manages file paths, and handles user interactions for
/// simulations.
/// </summary>
internal sealed partial class Simulation : Page
{

#pragma warning disable CA1822
	private SimulationVM ViewModel { get; } = App.AppHost.Services.GetRequiredService<SimulationVM>();
	private AppSettings.Main AppSettings { get; } = App.AppHost.Services.GetRequiredService<AppSettings.Main>();
#pragma warning restore CA1822

	/// <summary>
	/// Initializes a new instance of the Simulation class. Sets up the component, navigation cache mode, data context, and
	/// initializes file and folder path arrays.
	/// </summary>
	internal Simulation()
	{
		this.InitializeComponent();
		this.NavigationCacheMode = NavigationCacheMode.Required;

		this.DataContext = ViewModel;

		filePaths = [];
		folderPaths = [];
		catRootPaths = [];
	}



	#region ListView Stuff

	/// <summary>
	/// Converts the properties of a SimulationOutput row into a labeled, formatted string for copying to clipboard.
	/// </summary>
	/// <param name="row">The selected SimulationOutput row from the ListView.</param>
	/// <returns>A formatted string of the row's properties with labels.</returns>
	private static string ConvertRowToText(SimulationOutput row)
	{
		// Use StringBuilder to format each property with its label for easy reading
		return new StringBuilder()
			.AppendLine($"Path: {row.Path}")
			.AppendLine($"Source: {row.Source}")
			.AppendLine($"Is Authorized: {row.IsAuthorized}")
			.AppendLine($"Match Criteria: {row.MatchCriteria}")
			.AppendLine($"Specific File Name Criteria: {row.SpecificFileNameLevelMatchCriteria}")
			.AppendLine($"Signer ID: {row.SignerID}")
			.AppendLine($"Signer Name: {row.SignerName}")
			.AppendLine($"Signer Cert Root: {row.SignerCertRoot}")
			.AppendLine($"Signer Cert Publisher: {row.SignerCertPublisher}")
			.AppendLine($"Signer Scope: {row.SignerScope}")
			.AppendLine($"Cert Subject CN: {row.CertSubjectCN}")
			.AppendLine($"Cert Issuer CN: {row.CertIssuerCN}")
			.AppendLine($"Cert Not After: {row.CertNotAfter}")
			.AppendLine($"Cert TBS Value: {row.CertTBSValue}")
			.AppendLine($"File Path: {row.FilePath}")
			.ToString();
	}

	/// <summary>
	/// Copies the selected rows to the clipboard in a formatted manner, with each property labeled for clarity.
	/// </summary>
	/// <param name="sender">The event sender.</param>
	/// <param name="e">The event arguments.</param>
	private void ListViewFlyoutMenuCopy_Click(object sender, RoutedEventArgs e)
	{
		// Check if there are selected items in the ListView
		if (SimOutputListView.SelectedItems.Count > 0)
		{
			// Initialize StringBuilder to store all selected rows' data with labels
			StringBuilder dataBuilder = new();

			// Loop through each selected item in the ListView
			foreach (var selectedItem in SimOutputListView.SelectedItems)
			{
				if (selectedItem is SimulationOutput obj)

					// Append each row's formatted data to the StringBuilder
					_ = dataBuilder.AppendLine(ConvertRowToText(obj));

				// Add a separator between rows for readability in multi-row copies
				_ = dataBuilder.AppendLine(ListViewHelper.DefaultDelimiter);
			}

			// Create a DataPackage to hold the text data
			DataPackage dataPackage = new();

			// Set the formatted text as the content of the DataPackage
			dataPackage.SetText(dataBuilder.ToString());

			// Copy the DataPackage content to the clipboard
			Clipboard.SetContent(dataPackage);
		}
	}

	// Click event handlers for each property
	private void CopyPath_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.Path);
	private void CopySource_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.Source);
	private void CopyIsAuthorized_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.IsAuthorized.ToString());
	private void CopyMatchCriteria_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.MatchCriteria);
	private void CopySpecificFileNameLevelMatch_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.SpecificFileNameLevelMatchCriteria);
	private void CopySignerID_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.SignerID);
	private void CopySignerName_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.SignerName);
	private void CopySignerCertRoot_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.SignerCertRoot);
	private void CopySignerCertPublisher_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.SignerCertPublisher);
	private void CopySignerScope_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.SignerScope);
	private void CopyCertSubjectCN_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.CertSubjectCN);
	private void CopyCertIssuerCN_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.CertIssuerCN);
	private void CopyCertNotAfter_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.CertNotAfter);
	private void CopyCertTBSValue_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.CertTBSValue);
	private void CopyFilePath_Click(object sender, RoutedEventArgs e) => CopyToClipboard((item) => item.FilePath);

	/// <summary>
	/// Helper method to copy a specified property to clipboard without reflection
	/// </summary>
	/// <param name="getProperty">Function that retrieves the desired property value as a string</param>
	private void CopyToClipboard(Func<SimulationOutput, string?> getProperty)
	{
		if (SimOutputListView.SelectedItem is SimulationOutput selectedItem)
		{
			string? propertyValue = getProperty(selectedItem);
			if (propertyValue is not null)
			{
				DataPackage dataPackage = new();
				dataPackage.SetText(propertyValue);
				Clipboard.SetContent(dataPackage);
			}
		}
	}

	// Event handlers for each sort button
	private void ColumnSortingButton_Path_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.Path);
	}
	private void ColumnSortingButton_Source_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.Source);
	}
	private void ColumnSortingButton_IsAuthorized_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.IsAuthorized);
	}
	private void ColumnSortingButton_MatchCriteria_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.MatchCriteria);
	}
	private void ColumnSortingButton_SpecificFileNameLevelMatchCriteria_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.SpecificFileNameLevelMatchCriteria);
	}
	private void ColumnSortingButton_SignerID_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.SignerID);
	}
	private void ColumnSortingButton_SignerName_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.SignerName);
	}
	private void ColumnSortingButton_SignerCertRoot_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.SignerCertRoot);
	}
	private void ColumnSortingButton_SignerCertPublisher_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.SignerCertPublisher);
	}
	private void ColumnSortingButton_SignerScope_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.SignerScope);
	}
	private void ColumnSortingButton_CertSubjectCN_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.CertSubjectCN);
	}
	private void ColumnSortingButton_CertIssuerCN_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.CertIssuerCN);
	}
	private void ColumnSortingButton_CertNotAfter_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.CertNotAfter);
	}
	private void ColumnSortingButton_CertTBSValue_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.CertTBSValue);
	}
	private void ColumnSortingButton_FilePath_Click(object sender, RoutedEventArgs e)
	{
		SortColumn(SimOutput => SimOutput.FilePath);
	}

	/// <summary>
	/// Performs data sorting
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="keySelector"></param>
	private async void SortColumn<T>(Func<SimulationOutput, T> keySelector)
	{
		// Determine if a search filter is active.
		bool isSearchEmpty = string.IsNullOrWhiteSpace(SearchBox.Text);

		// If no search is active, use the full list (AllSimulationOutputs); otherwise, use a copy of the currently displayed list.
		List<SimulationOutput> collectionToSort = isSearchEmpty
			? ViewModel.AllSimulationOutputs
			: ViewModel.SimulationOutputs.ToList();

		// Prepare the sorted data in a temporary list.
		List<SimulationOutput> sortedData = SortingDirectionToggle.IsChecked
			? collectionToSort.OrderByDescending(keySelector).ToList()
			: collectionToSort.OrderBy(keySelector).ToList();

		// Clear the displayed collection and add the sorted items.
		await DispatcherQueue.EnqueueAsync(() =>
		{
			ViewModel.SimulationOutputs.Clear();
			foreach (SimulationOutput item in sortedData)
			{
				ViewModel.SimulationOutputs.Add(item);
			}
		});
	}


	#endregion


	private List<string> filePaths; // For selected file paths
	private readonly List<string> folderPaths; // For selected folder paths
	private string? xmlFilePath; // For selected XML file path
	private List<string> catRootPaths; // For selected Cat Root paths


	/// <summary>
	/// Event handler for the Begin Simulation button
	/// </summary>
	private async void BeginSimulationButton_Click()
	{
		try
		{
			// Collect values from UI elements
			bool noCatRootScanning = NoCatRootScanningToggle.IsChecked;
			double radialGaugeValue = ScalabilityRadialGauge.Value; // Value from radial gauge
			bool CSVOutput = CSVOutputToggle.IsChecked;

			BeginSimulationButton.IsEnabled = false;
			ScalabilityRadialGauge.IsEnabled = false;

			// Reset the progress bar value back to 0 if it was set from previous runs
			SimulationProgressBar.Value = 0;

			// Run the simulation
			ConcurrentDictionary<string, SimulationOutput> result = await Task.Run(() =>
			{
				return AppControlSimulation.Invoke(
					filePaths,
					folderPaths,
					xmlFilePath,
					noCatRootScanning,
					CSVOutput,
					catRootPaths,
					(ushort)radialGaugeValue,
					SimulationProgressBar
				);
			});

			// Clear the current ObservableCollection and backup the full data set
			ViewModel.SimulationOutputs.Clear();
			ViewModel.AllSimulationOutputs.Clear();

			// Update the TextBox with the total count of files
			TotalCountOfTheFilesTextBox.Text = result.Count.ToString(CultureInfo.InvariantCulture);

			ViewModel.AllSimulationOutputs.AddRange(result.Values);

			// Add to the ObservableCollection bound to the UI
			foreach (KeyValuePair<string, SimulationOutput> entry in result)
			{
				// Add a reference to the ViewModel class so we can use it for navigation in the XAML
				entry.Value.ParentViewModelSimulationVM = ViewModel;
				ViewModel.SimulationOutputs.Add(entry.Value);
			}

			ViewModel.CalculateColumnWidths();
		}
		finally
		{
			BeginSimulationButton.IsEnabled = true;
			ScalabilityRadialGauge.IsEnabled = true;
		}
	}


	/// <summary>
	/// Event handler for the Select XML File button
	/// </summary>
	private void SelectXmlFileButton_Click()
	{
		string? selectedFile = FileDialogHelper.ShowFilePickerDialog(GlobalVars.XMLFilePickerFilter);

		if (!string.IsNullOrEmpty(selectedFile))
		{
			// Store the selected XML file path
			xmlFilePath = selectedFile;

			// Update the TextBox with the selected XML file path
			SelectXmlFileButton_SelectedFilesTextBox.Text = selectedFile;
		}
	}

	/// <summary>
	/// Event handler for the Select Files button
	/// </summary>
	private void SelectFilesButton_Click()
	{
		List<string>? selectedFiles = FileDialogHelper.ShowMultipleFilePickerDialog(GlobalVars.AnyFilePickerFilter);

		if (selectedFiles is { Count: > 0 })
		{
			filePaths = [.. selectedFiles];

			foreach (string file in selectedFiles)
			{
				SelectFilesButton_SelectedFilesTextBox.Text += file + Environment.NewLine;
			}
		}
	}

	/// <summary>
	/// Event handler for the Select Folders button
	/// </summary>
	private void SelectFoldersButton_Click()
	{
		List<string>? selectedFolders = FileDialogHelper.ShowMultipleDirectoryPickerDialog();

		if (selectedFolders is { Count: > 0 })
		{
			foreach (string folder in selectedFolders)
			{
				folderPaths.Add(folder);

				SelectFoldersButton_SelectedFilesTextBox.Text += folder + Environment.NewLine;
			}
		}
	}


	/// <summary>
	/// Event handler for the Cat Root Paths button
	/// </summary>
	private void CatRootPathsButton_Click()
	{
		List<string>? selectedCatRoots = FileDialogHelper.ShowMultipleDirectoryPickerDialog();

		if (selectedCatRoots is { Count: > 0 })
		{
			catRootPaths = selectedCatRoots;
		}
	}


	// Event handler for RadialGauge ValueChanged
	private void ScalabilityRadialGauge_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
	{
		// Update the button content with the current value of the gauge
		ScalabilityButton.Content = $"Scalability: {((RadialGauge)sender).Value:N0}";
	}

	// Event handler for the Clear Data button
	private void ClearDataButton_Click(object sender, RoutedEventArgs e)
	{
		// Clear the ObservableCollection
		ViewModel.SimulationOutputs.Clear();
		// Clear the full data
		ViewModel.AllSimulationOutputs.Clear();

		// set the total count to 0 after clearing all the data
		TotalCountOfTheFilesTextBox.Text = "0";
	}

	/// <summary>
	/// Event handler for the SearchBox text change
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
	{
		string searchTerm = SearchBox.Text.Trim();

		// Perform a case-insensitive search in all relevant fields
		List<SimulationOutput> filteredResults = [.. ViewModel.AllSimulationOutputs.Where(output =>
			(output.Path is not null && output.Path.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
			(output.Source is not null && output.Source.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
			(output.MatchCriteria is not null && output.MatchCriteria.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
			(output.SpecificFileNameLevelMatchCriteria is not null && output.SpecificFileNameLevelMatchCriteria.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
			(output.CertSubjectCN is not null && output.CertSubjectCN.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
			(output.SignerName is not null && output.SignerName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
			(output.FilePath is not null && output.FilePath.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
		)];


		ViewModel.SimulationOutputs.Clear();

		foreach (SimulationOutput item in filteredResults)
		{
			ViewModel.SimulationOutputs.Add(item);
		}

	}


	private void SelectXmlFileButton_Holding(object sender, HoldingRoutedEventArgs e)
	{
		if (e.HoldingState is HoldingState.Started)
			if (!SelectXmlFileButton_Flyout.IsOpen)
				SelectXmlFileButton_Flyout.ShowAt(SelectXmlFileButton);
	}

	private void SelectXmlFileButton_RightTapped(object sender, RightTappedRoutedEventArgs e)
	{
		if (!SelectXmlFileButton_Flyout.IsOpen)
			SelectXmlFileButton_Flyout.ShowAt(SelectXmlFileButton);
	}

	private void SelectXmlFileButton_Flyout_Clear_Click(object sender, RoutedEventArgs e)
	{
		SelectXmlFileButton_SelectedFilesTextBox.Text = null;
		xmlFilePath = null;
	}

	private void SelectFilesButton_RightTapped(object sender, RightTappedRoutedEventArgs e)
	{
		if (!SelectFilesButton_Flyout.IsOpen)
			SelectFilesButton_Flyout.ShowAt(SelectFilesButton);
	}

	private void SelectFilesButton_Holding(object sender, HoldingRoutedEventArgs e)
	{
		if (e.HoldingState is HoldingState.Started)
			if (!SelectFilesButton_Flyout.IsOpen)
				SelectFilesButton_Flyout.ShowAt(SelectFilesButton);
	}

	private void SelectFilesButton_Flyout_Clear_Click(object sender, RoutedEventArgs e)
	{
		SelectFilesButton_SelectedFilesTextBox.Text = null;
		filePaths.Clear();
	}

	private void SelectFoldersButton_Flyout_Clear_Click(object sender, RoutedEventArgs e)
	{
		SelectFoldersButton_SelectedFilesTextBox.Text = null;
		folderPaths.Clear();
	}

	private void SelectFoldersButton_Holding(object sender, HoldingRoutedEventArgs e)
	{
		if (e.HoldingState is HoldingState.Started)
			if (!SelectFoldersButton_Flyout.IsOpen)
				SelectFoldersButton_Flyout.ShowAt(SelectFoldersButton);
	}

	private void SelectFoldersButton_RightTapped(object sender, RightTappedRoutedEventArgs e)
	{
		if (!SelectFoldersButton_Flyout.IsOpen)
			SelectFoldersButton_Flyout.ShowAt(SelectFoldersButton);
	}


	#region Ensuring right-click on rows behaves better and normally on ListView

	// When right-clicking on an unselected row, first it becomes selected and then the context menu will be shown for the selected row
	// This is a much more expected behavior. Without this, the right-click would be meaningless on the ListView unless user left-clicks on the row first

	private void ListView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
	{
		// When the container is being recycled, detach the handler.
		if (args.InRecycleQueue)
		{
			args.ItemContainer.RightTapped -= ListViewItem_RightTapped;
		}
		else
		{
			// Detach first to avoid multiple subscriptions, then attach the handler.
			args.ItemContainer.RightTapped -= ListViewItem_RightTapped;
			args.ItemContainer.RightTapped += ListViewItem_RightTapped;
		}
	}

	private void ListViewItem_RightTapped(object sender, RightTappedRoutedEventArgs e)
	{
		if (sender is ListViewItem item)
		{
			// If the item is not already selected, clear previous selections and select this one.
			if (!item.IsSelected)
			{
				// Set the counter so that the SelectionChanged event handler will ignore the next 2 events.
				_skipSelectionChangedCount = 2;

				//clear for exclusive selection
				SimOutputListView.SelectedItems.Clear();
				item.IsSelected = true;
			}
		}
	}

	#endregion


	/// <summary>
	/// CTRL + C shortcuts event handler
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	private void CtrlC_Invoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
	{
		ListViewFlyoutMenuCopy_Click(sender, new RoutedEventArgs());
		args.Handled = true;
	}

	// A counter to prevent SelectionChanged event from firing twice when right-clicking on an unselected row
	private int _skipSelectionChangedCount;

	private async void SimOutputListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		// Check if we need to skip this event.
		if (_skipSelectionChangedCount > 0)
		{
			_skipSelectionChangedCount--;
			return;
		}

		await ListViewHelper.SmoothScrollIntoViewWithIndexCenterVerticallyOnlyAsync(listViewBase: (ListView)sender, listView: (ListView)sender, index: ((ListView)sender).SelectedIndex, disableAnimation: false, scrollIfVisible: true, additionalHorizontalOffset: 0, additionalVerticalOffset: 0);
	}
}
