using System;
using HarmonyLib;
using Verse;

namespace RJW_Unleashed_Traits
{
    [StaticConstructorOnStartup]
    public static class Startup
    {
        static Startup()
        {
            Harmony harmony = new Harmony("RJW_Unleashed_Traits_main");

            foreach (Type type in typeof(Startup).Assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(HarmonyPatch), true).Length == 0) continue;

                try
                {
                    harmony.CreateClassProcessor(type).Patch();
                }
                catch (Exception e)
                {
                    Log.Error($"[RJW_Unleashed_Traits] Failed to apply patches from {type.FullName}: {e}");
                }
            }
        }
    }
}
