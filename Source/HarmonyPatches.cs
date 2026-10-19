//using System;
//using System.Collections.Generic;
//using HarmonyLib;
//using RimWorld;
//using Verse;

//namespace RJW_Unleashed_Traits
//{
//	[StaticConstructorOnStartup]
//	public class HarmonyPatches
//	{
//		static readonly Type patchType = typeof(HarmonyPatches);

//		static HarmonyPatches()
//		{
//            //var harmony = new Harmony("RJW_Unleashed_Traits.main");

//            //harmony.PatchAll(Assembly.GetExecutingAssembly());

//            // Add a custom back compatibility to the conversion chain
//            List<BackCompatibilityConverter> compatibilityConverters =
//				AccessTools.StaticFieldRefAccess<List<BackCompatibilityConverter>>(typeof(BackCompatibility),
//					"conversionChain");

//			compatibilityConverters.Add(new BackCompatibilityConverter_Rename());
//		}
//	}
//}