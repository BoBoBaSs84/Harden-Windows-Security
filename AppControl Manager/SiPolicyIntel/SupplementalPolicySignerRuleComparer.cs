﻿using System;
using System.Collections.Generic;
using AppControlManager.SiPolicy;

namespace AppControlManager.SiPolicyIntel;

/// <summary>
/// Provides comparison logic for SupplementalPolicySignerRule objects based on their SignerElement.
/// This comparer supports two matching rules to determine equality.
/// </summary>
internal sealed class SupplementalPolicySignerRuleComparer : IEqualityComparer<SupplementalPolicySignerRule>
{
	/// <summary>
	/// Determines whether two SupplementalPolicySignerRule objects are equal based on their SignerElement.
	/// </summary>
	/// <param name="x">First SupplementalPolicySignerRule object.</param>
	/// <param name="y">Second SupplementalPolicySignerRule object.</param>
	/// <returns>True if the objects are considered equal, otherwise false.</returns>
	public bool Equals(SupplementalPolicySignerRule? x, SupplementalPolicySignerRule? y)
	{
		// Null checks
		if (x is null || y is null)
		{
			return false;
		}

		// Extract signer elements for comparison
		Signer signerX = x.SignerElement;
		Signer signerY = y.SignerElement;

		// Rule 1: Check if Name, CertRoot.Value, and CertPublisher.Value are equal
		if (IsSignerRule1Match(signerX, signerY))
		{
			return true;
		}

		// Rule 2: Check if Name and CertRoot.Value are equal
		if (IsSignerRule2Match(signerX, signerY))
		{
			return true;
		}

		// If none of the rules match, return false
		return false;
	}

	/// <summary>
	/// Generates a hash code for a SupplementalPolicySignerRule based on its SignerElement.
	/// </summary>
	/// <param name="obj">The SupplementalPolicySignerRule object.</param>
	/// <returns>A hash code for the object.</returns>
	public int GetHashCode(SupplementalPolicySignerRule obj)
	{
		ArgumentNullException.ThrowIfNull(obj);

		Signer signer = obj.SignerElement;
		long hash = 17;  // Initial hash value
		const long modulus = 0x7FFFFFFF; // Maximum positive integer

		// Include Name in hash calculation if present
		if (!string.IsNullOrWhiteSpace(signer.Name))
		{
			hash = (hash * 31 + signer.Name.GetHashCode(StringComparison.OrdinalIgnoreCase)) % modulus;
		}

		// Include CertRoot.Value in hash calculation if present
		if (signer.CertRoot?.Value != null)
		{
			hash = (hash * 31 + CustomMethods.GetByteArrayHashCode(signer.CertRoot.Value)) % modulus;
		}

		// Include CertPublisher.Value in hash calculation if present
		if (!string.IsNullOrWhiteSpace(signer.CertPublisher?.Value))
		{
			hash = (hash * 31 + signer.CertPublisher.Value.GetHashCode(StringComparison.OrdinalIgnoreCase)) % modulus;
		}

		return (int)(hash & 0x7FFFFFFF); // Ensure non-negative hash
	}

	/// <summary>
	/// Rule 1: Name, CertRoot.Value, and CertPublisher.Value must match.
	/// </summary>
	private static bool IsSignerRule1Match(Signer signerX, Signer signerY)
	{
		return !string.IsNullOrWhiteSpace(signerX.Name) &&
			   !string.IsNullOrWhiteSpace(signerY.Name) &&
			   string.Equals(signerX.Name, signerY.Name, StringComparison.OrdinalIgnoreCase) &&
			   BytesArrayComparer.AreByteArraysEqual(signerX.CertRoot?.Value, signerY.CertRoot?.Value) &&
			   string.Equals(signerX.CertPublisher?.Value, signerY.CertPublisher?.Value, StringComparison.OrdinalIgnoreCase);
	}

	/// <summary>
	/// Rule 2: Name and CertRoot.Value must match.
	/// </summary>
	private static bool IsSignerRule2Match(Signer signerX, Signer signerY)
	{
		return !string.IsNullOrWhiteSpace(signerX.Name) &&
			   !string.IsNullOrWhiteSpace(signerY.Name) &&
			   string.Equals(signerX.Name, signerY.Name, StringComparison.OrdinalIgnoreCase) &&
			   BytesArrayComparer.AreByteArraysEqual(signerX.CertRoot?.Value, signerY.CertRoot?.Value);
	}
}