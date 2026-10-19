using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using rjw;
using rjw.Modules.Attraction;
using rjw.Modules.Attraction.StandardPreferences;

namespace RJW_Unleashed_Traits
{
	/// <summary>
	/// Homewrecker (attraction): RJW's standard homewrecking preference zeroes
	/// attraction toward partnered pawns. A homewrecker simply doesn't care,
	/// so the preference is skipped for them.
	/// </summary>
	[HarmonyPatch(typeof(R_Homewrecking), nameof(R_Homewrecking.ApplyTo))]
	public static class Patch_Homewrecker_Attraction
	{
		[HarmonyPrefix]
		public static bool Prefix(ref AttractionRequest request)
		{
			if (request.Pawn?.story?.traits == null) return true;
			if (!request.Pawn.story.traits.HasTrait(RJW_Traits_DefOf.RJW_Traits_Homewrecker)) return true;
			return false;
		}
	}

	/// <summary>
	/// Homewrecker (romance): their advances on partnered pawns are far more
	/// likely and far more successful.
	/// </summary>
	[HarmonyPatch(typeof(InteractionWorker_RomanceAttempt))]
	public static class Patch_Homewrecker_Romance
	{
		[HarmonyPostfix]
		[HarmonyPatch(nameof(InteractionWorker_RomanceAttempt.RandomSelectionWeight))]
		public static void RandomSelectionWeight(Pawn initiator, Pawn recipient, ref float __result)
		{
			if (__result <= 0f) return;
			if (!IsHomewrecker(initiator)) return;
			if (!xxx.HasNonPolyPartner(recipient)) return;
			__result *= 2.5f;
		}

		[HarmonyPostfix]
		[HarmonyPatch(nameof(InteractionWorker_RomanceAttempt.SuccessChance))]
		public static void SuccessChance(Pawn initiator, Pawn recipient, ref float __result)
		{
			if (!IsHomewrecker(initiator)) return;
			if (!xxx.HasNonPolyPartner(recipient)) return;
			__result = Mathf.Clamp01(__result * 2f + 0.1f);
		}

		private static bool IsHomewrecker(Pawn pawn)
		{
			return pawn?.story?.traits != null
				&& pawn.story.traits.HasTrait(RJW_Traits_DefOf.RJW_Traits_Homewrecker);
		}
	}

}
