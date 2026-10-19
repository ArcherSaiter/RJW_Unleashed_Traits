using HarmonyLib;
using RimWorld;
using Verse;

namespace RJW_Unleashed_Traits
{
	/// <summary>
	/// Incel: bitter and charmless, they are far less likely to attempt
	/// romance and far more likely to be rejected when they do.
	/// </summary>
	[HarmonyPatch(typeof(InteractionWorker_RomanceAttempt))]
	public static class Patch_Incel
	{
		private const float ChanceFactor = 0.35f;
		private const float SuccessFactor = 0.4f;

		[HarmonyPostfix]
		[HarmonyPatch(nameof(InteractionWorker_RomanceAttempt.RandomSelectionWeight))]
		public static void RandomSelectionWeight(Pawn initiator, Pawn recipient, ref float __result)
		{
			if (__result <= 0f) return;
			if (!IsIncel(initiator)) return;
			__result *= ChanceFactor;
		}

		[HarmonyPostfix]
		[HarmonyPatch(nameof(InteractionWorker_RomanceAttempt.SuccessChance))]
		public static void SuccessChance(Pawn initiator, Pawn recipient, ref float __result)
		{
			if (__result <= 0f) return;
			if (!IsIncel(initiator)) return;
			__result *= SuccessFactor;
		}

		private static bool IsIncel(Pawn pawn)
		{
			return pawn?.story?.traits != null
				&& pawn.story.traits.HasTrait(RJW_Traits_DefOf.RJW_Traits_xxCel);
		}
	}
}
