using System;
using RimWorld;
using Verse;
using rjw;

namespace RJW_Unleashed_Traits
{
    public class NeedCheck
    {
        public void SetCurLevel(Pawn pawn)
        {
           if (pawn.story.traits.HasTrait(RJW_Traits_DefOf.RJW_Traits_Sexually_Numb))
           {
               Need_Sex Need_SexInstance = new Need_Sex(pawn)
               {
                   CurLevel = (float)(pawn.needs.TryGetNeed(DefDatabase<NeedDef>.GetNamed("Sex"))?.CurLevel ?? 1f)
               };
           }
        }
    }
}