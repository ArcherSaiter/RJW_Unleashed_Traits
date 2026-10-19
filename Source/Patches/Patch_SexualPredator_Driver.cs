using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using rjw;

namespace RJW_Unleashed_Traits
{
	/// <summary>
	/// Sexual predator driver.
	/// All the actual numbers (capacity boosts, work-speed penalty) live in the
	/// RJW_SexualPredator_Instinct HediffDef stages. This hook only keeps that
	/// hediff present on predators and scales its severity with how pent-up the
	/// pawn is - sex need 0.5 or above means no effect, 0 means maximum effect.
	/// </summary>
	[HarmonyPatch(typeof(Need_Sex), nameof(Need_Sex.NeedInterval))]
	public static class Patch_SexualPredator_Driver
	{
		private static readonly AccessTools.FieldRef<Need, Pawn> PawnField =
			AccessTools.FieldRefAccess<Need, Pawn>("pawn");

		[HarmonyPostfix]
		public static void Postfix(Need_Sex __instance)
		{
			Pawn pawn = PawnField(__instance);
			if (pawn?.health?.hediffSet == null) return;

			HediffDef def = RJW_Traits_DefOf.RJW_SexualPredator_Instinct;
			if (def == null) return;

			bool isPredator = pawn.story?.traits != null
				&& pawn.story.traits.HasTrait(RJW_Traits_DefOf.RJW_Traits_Sexual_Predator);

			Hediff existing = pawn.health.hediffSet.GetFirstHediffOfDef(def);

			if (!isPredator)
			{
				if (existing != null) pawn.health.RemoveHediff(existing);
				return;
			}

			if (existing == null)
			{
				existing = HediffMaker.MakeHediff(def, pawn);
				pawn.health.AddHediff(existing);
			}

			existing.Severity = Mathf.InverseLerp(0.5f, 0f, __instance.CurLevel);
		}
	}
}
