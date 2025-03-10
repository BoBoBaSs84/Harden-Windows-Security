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

using System.Collections.Generic;
using System.Linq;
using AppControlManager.Others;
using AppControlManager.SiPolicyIntel;

namespace AppControlManager.SiPolicy;

internal static class Factory
{
	/// <summary>
	/// This is a context-aware method that collects all <Allow> elements or Allow rules in the policy from FileRules node/section.
	/// It de-duplicates them using a custom HashSet.
	/// </summary>
	/// <param name="siPolicies"></param>
	/// <returns></returns>
	internal static HashSet<AllowRule> CollectAllowRules(List<SiPolicy> siPolicies)
	{
		// HashSet to store the unique Allow rules
		HashSet<AllowRule> allowRules = new(new AllowRuleComparer());

		// Loop over each policy input data
		foreach (SiPolicy siPolicy in siPolicies)
		{

			// Index FileRules by their ID for quick lookup
			// ID will be key and AllowRule itself will be the value
			Dictionary<string, Allow>? fileRuleDictionary = siPolicy.FileRules?.OfType<Allow>()
				.ToDictionary(fileRule => fileRule.ID, fileRule => fileRule);

			// Skip if the policy doesn't have <FileRules> node
			if (fileRuleDictionary is null)
			{
				continue;
			}

			// Find all FileRuleRefs in SigningScenarios and map them to AllowRules
			foreach (SigningScenario signingScenario in siPolicy.SigningScenarios)
			{
				// Get all possible FileRuleRef items from the current signing scenario
				FileRuleRef[]? possibleFileRuleRef = signingScenario.ProductSigners?.FileRulesRef?.FileRuleRef;

				if (possibleFileRuleRef is { Length: > 0 })
				{
					foreach (FileRuleRef fileRuleRef in possibleFileRuleRef)
					{
						if (fileRuleDictionary.TryGetValue(fileRuleRef.RuleID, out Allow? allowElement))
						{

							#region ID Replacement
							string rand = $"ID_ALLOW_A_{GUIDGenerator.GenerateUniqueGUIDToUpper()}";
							allowElement.ID = rand;
							fileRuleRef.RuleID = rand;
							#endregion

							AllowRule allowRule = new()
							{
								AllowElement = allowElement,
								FileRuleRefElement = fileRuleRef,
								SigningScenario = signingScenario.Value == 12 ? SSType.UserMode : SSType.KernelMode
							};
							_ = allowRules.Add(allowRule);

						}
					}
				}
			}
		}

		return allowRules;
	}


	/// <summary>
	/// This is a context-aware method that collects all <Deny> elements or Deny rules in the policy from FileRules node/section.
	/// It de-duplicates them using a custom HashSet.
	/// </summary>
	/// <param name="siPolicies"></param>
	/// <returns></returns>
	internal static HashSet<DenyRule> CollectDenyRules(List<SiPolicy> siPolicies)
	{
		// HashSet to store the unique Deny rules
		HashSet<DenyRule> denyRules = new(new DenyRuleComparer());

		// Loop over each policy input data
		foreach (SiPolicy siPolicy in siPolicies)
		{
			// Index FileRules by their ID for quick lookup
			// ID will be key and DenyRule itself will be the value
			Dictionary<string, Deny>? fileRuleDictionary = siPolicy.FileRules?.OfType<Deny>()
				.ToDictionary(fileRule => fileRule.ID, fileRule => fileRule);

			// Skip if the policy doesn't have <FileRules> node
			if (fileRuleDictionary is null)
			{
				continue;
			}

			// Find all FileRuleRefs in SigningScenarios and map them to DenyRules
			foreach (SigningScenario signingScenario in siPolicy.SigningScenarios)
			{
				// Get all possible FileRuleRef items from the current signing scenario
				FileRuleRef[]? possibleFileRuleRef = signingScenario.ProductSigners?.FileRulesRef?.FileRuleRef;

				if (possibleFileRuleRef is { Length: > 0 })
				{
					foreach (FileRuleRef fileRuleRef in possibleFileRuleRef)
					{
						if (fileRuleDictionary.TryGetValue(fileRuleRef.RuleID, out Deny? denyElement))
						{

							#region ID Replacement
							string rand = $"ID_DENY_A_{GUIDGenerator.GenerateUniqueGUIDToUpper()}";
							denyElement.ID = rand;
							fileRuleRef.RuleID = rand;
							#endregion

							DenyRule allowRule = new()
							{
								DenyElement = denyElement,
								FileRuleRefElement = fileRuleRef,
								SigningScenario = signingScenario.Value == 12 ? SSType.UserMode : SSType.KernelMode
							};
							_ = denyRules.Add(allowRule);
						}
					}
				}
			}

		}

		return denyRules;
	}


	/// <summary>
	/// This is a context-aware method that collects all <Signer> elements or Signer rules in the policy from Signers node/section.
	/// Each signer is complete and has all of the elements that can be used in the policy file independently.
	/// </summary>
	/// <param name="siPolicies"></param>
	/// <returns></returns>
	internal static SignerCollection CollectSignerRules(List<SiPolicy> siPolicies)
	{

		// HashSets to store unique data
		HashSet<FilePublisherSignerRule> filePublisherSigners = new(new FilePublisherSignerRuleComparer());
		HashSet<SignerRule> signerRules = new(new PublisherSignerRuleComparer());
		HashSet<WHQLFilePublisher> whqlFilePublishers = new(new WHQLFilePublisherSignerRuleComparer());
		HashSet<WHQLPublisher> wHQLPublishers = new(new WHQLPublisherSignerRuleComparer());
		HashSet<UpdatePolicySignerRule> updatePolicySignerRules = new(new UpdatePolicySignerRuleComparer());
		HashSet<SupplementalPolicySignerRule> supplementalPolicySignerRules = new(new SupplementalPolicySignerRuleComparer());

		// Loop over each policy input data
		foreach (SiPolicy siPolicy in siPolicies)
		{

			// Index elements for efficient lookup
			Dictionary<string, FileAttrib>? fileAttribDictionary = siPolicy.FileRules?.OfType<FileAttrib>()
				.ToDictionary(fileAttrib => fileAttrib.ID, fileAttrib => fileAttrib);

			// Get all of the <Signer> elements from the policy
			Dictionary<string, Signer> signerDictionary = [];

			foreach (Signer signer in siPolicy.Signers)
			{
				if (!signerDictionary.TryAdd(signer.ID, signer))
				{
					Logger.Write($"One of the XML files has more than 1 Signer with the same ID `{signer.ID}`");
				}
			}


			// ID of all of the CiSigners if they exist
			HashSet<string> ciSignerSet = [.. siPolicy.CiSigners?.Select(ciSigner => ciSigner.SignerId) ?? []];

			// Dictionary to store all of the EKUs
			Dictionary<string, EKU> ekuDictionary = siPolicy.EKUs?.ToDictionary(eku => eku.ID, eku => eku) ?? [];

			// ID of all of the SupplementalPolicySigners if they exist
			HashSet<string> supplementalPolicySignersSet = [.. siPolicy.SupplementalPolicySigners?.Select(supplementalPolicySigner => supplementalPolicySigner.SignerId) ?? []];

			// ID of all of the UpdatePolicySigners if they exist
			HashSet<string> updatePolicySignersSet = [.. siPolicy.UpdatePolicySigners?.Select(updatePolicySigner => updatePolicySigner.SignerId) ?? []];


			// Collecting UpdatePolicySigners and SupplementalPolicySigners separately
			// Because they are not part of any SigningScenario and don't have Allowed/Denied signers
			ProcessSupplementalPolicySigners(supplementalPolicySignersSet, signerDictionary, supplementalPolicySignerRules);

			ProcessUpdatePolicySigners(updatePolicySignersSet, signerDictionary, updatePolicySignerRules);


			// Step 2: Process SigningScenarios
			foreach (SigningScenario signingScenario in siPolicy.SigningScenarios)
			{
				// If the signing scenario has product signers
				ProductSigners? possibleProdSigners = signingScenario.ProductSigners;

				if (possibleProdSigners is not null)
				{
					AllowedSigner[]? allowedSigners = possibleProdSigners.AllowedSigners?.AllowedSigner;
					DeniedSigner[]? deniedSigners = possibleProdSigners.DeniedSigners?.DeniedSigner;

					if (allowedSigners is { Length: > 0 })
					{
						// Process Allowed Signers
						foreach (AllowedSigner item in allowedSigners)
						{
							// Get the Signer element associated with the current AllowedSigner
							if (signerDictionary.TryGetValue(item.SignerId, out Signer? signer))
							{
								AddSignerRule(
									signer,
									signingScenario,
									Authorization.Allow,
									item,
									null,
									ciSignerSet,
									fileAttribDictionary,
									filePublisherSigners,
									signerRules,
									wHQLPublishers,
									whqlFilePublishers,
									ekuDictionary);
							}
						}
					}

					if (deniedSigners is { Length: > 0 })
					{
						// Process Denied Signers
						foreach (DeniedSigner item in deniedSigners)
						{
							if (signerDictionary.TryGetValue(item.SignerId, out Signer? signer))
							{
								AddSignerRule(
									signer,
									signingScenario,
									Authorization.Deny,
									null,
									item,
									ciSignerSet,
									fileAttribDictionary,
									filePublisherSigners,
									signerRules,
									wHQLPublishers,
									whqlFilePublishers,
									ekuDictionary);
							}
						}
					}
				}
			}

		}

		return new SignerCollection
		{
			FilePublisherSigners = filePublisherSigners,
			SignerRules = signerRules,
			WHQLPublishers = wHQLPublishers,
			WHQLFilePublishers = whqlFilePublishers,
			UpdatePolicySigners = updatePolicySignerRules,
			SupplementalPolicySigners = supplementalPolicySignerRules
		};
	}


	/// <summary>
	/// Helper method that categorizes each signer
	/// </summary>
	/// <param name="signer"></param>
	/// <param name="signingScenario"></param>
	/// <param name="auth"></param>
	/// <param name="allowedSigner"></param>
	/// <param name="deniedSigner"></param>
	/// <param name="ciSignerSet"></param>
	/// <param name="fileAttribDictionary"></param>
	/// <param name="filePublisherSigners"></param>
	/// <param name="signerRules"></param>
	/// <param name="WHQLPublishers"></param>
	/// <param name="WHQLFilePublishers"></param>
	/// <param name="ekuDictionary"></param>
	private static void AddSignerRule(
	Signer signer,
	SigningScenario signingScenario,
	Authorization auth,
	AllowedSigner? allowedSigner,
	DeniedSigner? deniedSigner,
	HashSet<string> ciSignerSet,
	Dictionary<string, FileAttrib>? fileAttribDictionary,
	HashSet<FilePublisherSignerRule> filePublisherSigners,
	HashSet<SignerRule> signerRules,
	HashSet<WHQLPublisher> WHQLPublishers,
	HashSet<WHQLFilePublisher> WHQLFilePublishers,
	Dictionary<string, EKU> ekuDictionary)
	{
		// Determine SigningScenario type
		SSType scenarioType = signingScenario.Value == 12 ? SSType.UserMode : SSType.KernelMode;

		// Check if the signer is also a CiSigner
		bool isCiSigner = ciSignerSet.Contains(signer.ID);

		// Gather all associated FileAttribs
		List<FileAttrib> associatedFileAttribs = signer.FileAttribRef?
			.Select(fileAttribRef => fileAttribDictionary?.GetValueOrDefault(fileAttribRef.RuleID))
			.Where(fileAttrib => fileAttrib is not null) // Ensure no nulls
			.Cast<FileAttrib>()                         // Safe cast to non-nullable type
			.ToList() ?? [];

		// Gather all associated EKUs
		List<EKU> associatedEKUs = signer.CertEKU?
			.Select(certEku => ekuDictionary.GetValueOrDefault(certEku.ID))
			.Where(eku => eku is not null)             // Ensure no nulls
			.Cast<EKU>()                               // Safe cast to non-nullable type
			.ToList() ?? [];

		// Classification
		if (associatedFileAttribs.Count != 0)
		{
			if (associatedEKUs.Count != 0)
			{

				#region ID Replacement
				string guid = GUIDGenerator.GenerateUniqueGUIDToUpper();
				string rand = $"ID_SIGNER_A_{guid}";

				signer.ID = rand;

				if (allowedSigner is not null)
				{
					allowedSigner.SignerId = rand;
				}

				if (deniedSigner is not null)
				{
					deniedSigner.SignerId = rand;
				}


				List<string> randCol1 = GUIDGenerator.GenerateUniqueGUIDToUpper(associatedFileAttribs.Count);

				for (int i = 0; i < associatedFileAttribs.Count; i++)
				{
					// Deep copy the FileAttrib object
					FileAttrib originalAttrib = associatedFileAttribs[i];
					FileAttrib copiedAttrib = new()
					{
						ID = $"ID_FILEATTRIB_A_{randCol1[i]}",
						FriendlyName = originalAttrib.FriendlyName,
						FileName = originalAttrib.FileName,
						InternalName = originalAttrib.InternalName,
						FileDescription = originalAttrib.FileDescription,
						ProductName = originalAttrib.ProductName,
						PackageFamilyName = originalAttrib.PackageFamilyName,
						PackageVersion = originalAttrib.PackageVersion,
						MinimumFileVersion = originalAttrib.MinimumFileVersion,
						MaximumFileVersion = originalAttrib.MaximumFileVersion,
						Hash = originalAttrib.Hash is null ? null : (byte[])originalAttrib.Hash.Clone(),
						AppIDs = originalAttrib.AppIDs,
						FilePath = originalAttrib.FilePath
					};
					associatedFileAttribs[i] = copiedAttrib;

					// Deep copy the FileAttribRef object
					FileAttribRef originalAttribRef = signer.FileAttribRef![i];
					FileAttribRef copiedAttribRef = new()
					{
						RuleID = $"ID_FILEATTRIB_A_{randCol1[i]}"
					};

					signer.FileAttribRef![i] = copiedAttribRef;
				}


				List<string> randCol2 = GUIDGenerator.GenerateUniqueGUIDToUpper(associatedEKUs.Count);

				for (int j = 0; j < associatedEKUs.Count; j++)
				{

					// Clone the EKU to avoid modifying the original object
					EKU clonedEKU = new()
					{
						ID = $"ID_EKU_E_{randCol2[j]}",
						Value = associatedEKUs[j].Value,
						FriendlyName = associatedEKUs[j].FriendlyName
					};

					CertEKU certEKU = new()
					{
						ID = $"ID_EKU_E_{randCol2[j]}"
					};

					// Assign the cloned EKU back to avoid affecting other references
					associatedEKUs[j] = clonedEKU;

					// Update the corresponding CertEKU reference
					signer.CertEKU![j] = certEKU;

				}

				#endregion

				// WHQLFilePublisher
				_ = WHQLFilePublishers.Add(new WHQLFilePublisher
				{
					FileAttribElements = associatedFileAttribs,
					AllowedSignerElement = allowedSigner,
					DeniedSignerElement = deniedSigner,
					CiSignerElement = isCiSigner ? new CiSigner { SignerId = signer.ID } : null,
					SignerElement = signer,
					Ekus = associatedEKUs,
					SigningScenario = scenarioType,
					Auth = auth
				});
			}
			else
			{


				#region ID Replacement
				string guid = GUIDGenerator.GenerateUniqueGUIDToUpper();
				string rand = $"ID_SIGNER_A_{guid}";

				signer.ID = rand;

				if (allowedSigner is not null)
				{
					allowedSigner.SignerId = rand;
				}

				if (deniedSigner is not null)
				{
					deniedSigner.SignerId = rand;
				}


				List<string> randCol1 = GUIDGenerator.GenerateUniqueGUIDToUpper(associatedFileAttribs.Count);

				for (int i = 0; i < associatedFileAttribs.Count; i++)
				{
					// Deep copy the FileAttrib object
					FileAttrib originalAttrib = associatedFileAttribs[i];
					FileAttrib copiedAttrib = new()
					{
						ID = $"ID_FILEATTRIB_A_{randCol1[i]}",
						FriendlyName = originalAttrib.FriendlyName,
						FileName = originalAttrib.FileName,
						InternalName = originalAttrib.InternalName,
						FileDescription = originalAttrib.FileDescription,
						ProductName = originalAttrib.ProductName,
						PackageFamilyName = originalAttrib.PackageFamilyName,
						PackageVersion = originalAttrib.PackageVersion,
						MinimumFileVersion = originalAttrib.MinimumFileVersion,
						MaximumFileVersion = originalAttrib.MaximumFileVersion,
						Hash = originalAttrib.Hash is null ? null : (byte[])originalAttrib.Hash.Clone(),
						AppIDs = originalAttrib.AppIDs,
						FilePath = originalAttrib.FilePath
					};
					associatedFileAttribs[i] = copiedAttrib;

					// Deep copy the FileAttribRef object
					FileAttribRef originalAttribRef = signer.FileAttribRef![i];
					FileAttribRef copiedAttribRef = new()
					{
						RuleID = $"ID_FILEATTRIB_A_{randCol1[i]}"
					};

					signer.FileAttribRef![i] = copiedAttribRef;
				}


				#endregion


				// FilePublisherSignerRule
				_ = filePublisherSigners.Add(new FilePublisherSignerRule
				{
					FileAttribElements = associatedFileAttribs,
					AllowedSignerElement = allowedSigner,
					DeniedSignerElement = deniedSigner,
					CiSignerElement = isCiSigner ? new CiSigner { SignerId = signer.ID } : null,
					SignerElement = signer,
					SigningScenario = scenarioType,
					Auth = auth
				});
			}
		}
		else if (associatedEKUs.Count != 0)
		{


			#region ID Replacement
			string guid = GUIDGenerator.GenerateUniqueGUIDToUpper();
			string rand = $"ID_SIGNER_A_{guid}";


			signer.ID = rand;

			if (allowedSigner is not null)
			{
				allowedSigner.SignerId = rand;
			}

			if (deniedSigner is not null)
			{
				deniedSigner.SignerId = rand;
			}

			List<string> randCol2 = GUIDGenerator.GenerateUniqueGUIDToUpper(associatedEKUs.Count);

			for (int j = 0; j < associatedEKUs.Count; j++)
			{


				// Clone the EKU to avoid modifying the original object
				EKU clonedEKU = new()
				{
					ID = $"ID_EKU_E_{randCol2[j]}",
					Value = associatedEKUs[j].Value,
					FriendlyName = associatedEKUs[j].FriendlyName
				};

				CertEKU certEKU = new()
				{
					ID = $"ID_EKU_E_{randCol2[j]}"
				};

				// Assign the cloned EKU back to avoid affecting other references
				associatedEKUs[j] = clonedEKU;

				// Update the corresponding CertEKU reference
				signer.CertEKU![j] = certEKU;


			}

			#endregion


			// WHQLPublisher
			_ = WHQLPublishers.Add(new WHQLPublisher
			{
				AllowedSignerElement = allowedSigner,
				DeniedSignerElement = deniedSigner,
				CiSignerElement = isCiSigner ? new CiSigner { SignerId = signer.ID } : null,
				SignerElement = signer,
				Ekus = associatedEKUs,
				SigningScenario = scenarioType,
				Auth = auth
			});
		}
		else
		{


			#region ID Replacement
			string guid = GUIDGenerator.GenerateUniqueGUIDToUpper();
			string rand = $"ID_SIGNER_A_{guid}";

			signer.ID = rand;

			if (allowedSigner is not null)
			{
				allowedSigner.SignerId = rand;
			}

			if (deniedSigner is not null)
			{
				deniedSigner.SignerId = rand;
			}

			#endregion


			// Generic SignerRule
			_ = signerRules.Add(new SignerRule
			{
				SignerElement = signer,
				AllowedSignerElement = allowedSigner,
				DeniedSignerElement = deniedSigner,
				CiSignerElement = isCiSigner ? new CiSigner { SignerId = signer.ID } : null,
				SigningScenario = scenarioType,
				Auth = auth
			});
		}
	}


	/// <summary>
	/// Processes SupplementalPolicySigners
	/// </summary>
	/// <param name="supplementalPolicySignerIDs"></param>
	/// <param name="Signers"></param>
	/// <param name="supplementalPolicySignersSet"></param>
	private static void ProcessSupplementalPolicySigners(
		HashSet<string> supplementalPolicySignerIDs,
		Dictionary<string, Signer> Signers,
		HashSet<SupplementalPolicySignerRule> supplementalPolicySignersSet)
	{
		foreach (string ID in supplementalPolicySignerIDs)
		{
			if (Signers.TryGetValue(ID, out Signer? possibleSupplementalPolicySigner))
			{

				// Create random ID for the signer and its corresponding SupplementalPolicySigner element
				string guid = GUIDGenerator.GenerateUniqueGUIDToUpper();
				string rand = $"ID_SIGNER_A_{guid}";

				// Replace the Signer's ID
				possibleSupplementalPolicySigner.ID = rand;

				// Create a new SupplementalPolicySigner element with the new ID
				SupplementalPolicySigner suppRule = new()
				{
					SignerId = rand
				};

				_ = supplementalPolicySignersSet.Add(new SupplementalPolicySignerRule
				{
					SignerElement = possibleSupplementalPolicySigner,
					SupplementalPolicySigner = suppRule
				});
			}
		}
	}


	/// <summary>
	/// Processes UpdatePolicySigners
	/// </summary>
	/// <param name="updatePolicySignerIDs"></param>
	/// <param name="Signers"></param>
	/// <param name="updatePolicySignersSet"></param>
	private static void ProcessUpdatePolicySigners(
		HashSet<string> updatePolicySignerIDs,
		Dictionary<string, Signer> Signers,
		HashSet<UpdatePolicySignerRule> updatePolicySignersSet)
	{
		foreach (string ID in updatePolicySignerIDs)
		{
			if (Signers.TryGetValue(ID, out Signer? possibleUpdatePolicySigner))
			{

				// Create random ID for the signer and its corresponding UpdatePolicySigner element
				string guid = GUIDGenerator.GenerateUniqueGUIDToUpper();
				string rand = $"ID_SIGNER_A_{guid}";

				// Replace the Signer's ID
				possibleUpdatePolicySigner.ID = rand;

				// Create a new UpdatePolicySigner element with the new ID
				UpdatePolicySigner uppRule = new()
				{
					SignerId = rand
				};

				_ = updatePolicySignersSet.Add(new UpdatePolicySignerRule
				{
					SignerElement = possibleUpdatePolicySigner,
					UpdatePolicySigner = uppRule
				});
			}
		}
	}

}
