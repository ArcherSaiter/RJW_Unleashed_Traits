using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using rjw;
using rjw.Modules.Attraction;

namespace RJW_Unleashed_Traits
{
	/// <summary>
	/// Degrader: instead of typical random chat, a degrader will lash out
	/// with cruel insults at the pawns they are sexually attracted to. The
	/// more pent-up they are, the more likely they are to do so.
	/// </summary>
	[HarmonyPatch(typeof(Pawn_InteractionsTracker), "TryInteractRandomly")]
	public static class Patch_Degrader
	{
		private static readonly AccessTools.FieldRef<Pawn_InteractionsTracker, Pawn> PawnField =
			AccessTools.FieldRefAccess<Pawn_InteractionsTracker, Pawn>("pawn");

		[HarmonyPrefix]
		public static bool Prefix(Pawn_InteractionsTracker __instance)
		{
			Pawn pawn = PawnField(__instance);
			if (pawn?.story?.traits == null) return true;
			if (!pawn.story.traits.HasTrait(RJW_Traits_DefOf.RJW_Traits_Degrader)) return true;
			if (pawn.Map?.mapPawns == null) return true;

			float need = pawn.needs?.TryGetNeed<Need_Sex>()?.CurLevel ?? 0.5f;
			float chance = Mathf.InverseLerp(0.5f, 0f, need) * 0.6f;
			if (chance <= 0f || !Rand.Chance(chance)) return true;

			Pawn best = null;
			float bestAttraction = 0f;
			var candidates = pawn.Map.mapPawns.AllPawnsSpawned;
			for (int i = 0; i < candidates.Count; i++)
			{
				Pawn other = candidates[i];
				if (other == pawn) continue;
				if (!other.RaceProps.Humanlike) continue;
				if (pawn.HostileTo(other)) continue;
				if (!__instance.CanInteractNowWith(other)) continue;

				float attraction = AttractionUtility.Evaluate(pawn, other, AttractionPurpose.ForFucking);
				if (attraction > bestAttraction)
				{
					bestAttraction = attraction;
					best = other;
				}
			}

			if (best == null) return true;
			if (__instance.TryInteractWith(best, InteractionDefOf.Insult)) return false;
			return true;
		}
	}
}
