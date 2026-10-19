using HarmonyLib;
using RimWorld;
using Verse;

namespace RJW_Unleashed_Traits
{
	/// <summary>
	/// Degradee: being insulted doesn't hurt - it delights them, and they
	/// grow fond of whoever put them in their place. The vanilla insult
	/// thought is swapped for a positive one.
	/// </summary>
	[HarmonyPatch(typeof(Pawn_InteractionsTracker), nameof(Pawn_InteractionsTracker.AddInteractionThought))]
	public static class Patch_Degradee
	{
		[HarmonyPrefix]
		public static void Prefix(Pawn pawn, Pawn otherPawn, ref ThoughtDef thoughtDef)
		{
			if (thoughtDef?.defName != "Insulted") return;
			if (pawn?.story?.traits == null) return;
			if (!pawn.story.traits.HasTrait(RJW_Traits_DefOf.RJW_Traits_Degradee)) return;

			thoughtDef = RJW_Traits_DefOf.RJW_Degradee_Praised;
		}
	}
}
