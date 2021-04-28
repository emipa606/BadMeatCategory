using System.Collections.Generic;
using RimWorld;
using Verse;

namespace BadMeatCategory
{
    [StaticConstructorOnStartup]
    public class BadMeatCategory
    {
        static BadMeatCategory()
        {
            var MeatRawCategory = DefDatabase<ThingCategoryDef>.GetNamedSilentFail("MeatRaw");
            if (MeatRawCategory == null)
            {
                Log.ErrorOnce("[BadMeatCategory]: Could not find the MeatRaw-category. Will not sort bad meat.", "MeatRawCategory".GetHashCode());
                return;
            }

            var MeatBadCategory = DefDatabase<ThingCategoryDef>.GetNamedSilentFail("MeatBad");
            if (MeatBadCategory == null)
            {
                Log.ErrorOnce("[BadMeatCategory]: Could not find the MeatBad-category. Will not sort bad meat.", "MeatBadCategory".GetHashCode());
                return;
            }

            var thingsToMove = new List<ThingDef>();
            foreach (var descendantThingDef in MeatRawCategory.DescendantThingDefs)
            {
                if (FoodUtility.IsHumanlikeMeat(descendantThingDef))
                {
                    thingsToMove.Add(descendantThingDef);
                    continue;
                }

                if (descendantThingDef.ingestible.sourceDef?.race != null && descendantThingDef.ingestible.sourceDef.race.FleshType == FleshTypeDefOf.Insectoid)
                {
                    thingsToMove.Add(descendantThingDef);
                    continue;
                }

                if (descendantThingDef.defName == "MeatRotten")
                {
                    thingsToMove.Add(descendantThingDef);
                }
            }

            foreach (var thingDef in thingsToMove)
            {
                MeatRawCategory.childThingDefs.Remove(thingDef);
                thingDef.thingCategories.Remove(MeatRawCategory);
                MeatBadCategory.childThingDefs.Add(thingDef);
                thingDef.thingCategories.Add(MeatBadCategory);
                if (thingDef.defName != "MeatRotten")
                {
                    continue;
                }

                // Support for Rotted Meat-mod
                var rottenCategoryDef = DefDatabase<ThingCategoryDef>.GetNamedSilentFail("MeatRawRotten");
                if (rottenCategoryDef == null)
                {
                    continue;
                }

                rottenCategoryDef.childThingDefs.Remove(thingDef);
                thingDef.thingCategories.Remove(rottenCategoryDef);
                rottenCategoryDef.ClearCachedData();
            }

            MeatRawCategory.ClearCachedData();
            MeatBadCategory.ClearCachedData();
            Log.Message($"[BadMeatCategory]: Moved {thingsToMove.Count} meat to the Bad Meat-category");
        }
    }
}