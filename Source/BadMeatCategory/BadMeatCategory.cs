using System.Collections.Generic;
using RimWorld;
using Verse;

namespace BadMeatCategory;

public class BadMeatCategory
{
    private static List<string> getExtraThingDefs()
    {
        return
        [
            "Meat_Chaocow", //Pawnmorpher
            "DankPyon_DriedMeat_Human", //Medieval Overhaul
            "DankPyon_DriedMeat_Insect", //Medieval Overhaul
            "MeatRotten", //Rotten Meat
            "Replimat_Synthmeat", //Replimat
            "RF_RottenMeat", //Biotech xenotype expanded - Rotfish
            "VAEWaste_ToxicMeat", //Vanilla Animals Expanded - Waste Animals
            "Meat_Twisted", //Anomaly
            "Necro_Meat" //The Army Of Fetid Corpses
        ];
    }

    internal static void SetupBadMeatCategory()
    {
        var meatRawCategory = DefDatabase<ThingCategoryDef>.GetNamedSilentFail("MeatRaw");
        if (meatRawCategory == null)
        {
            Log.ErrorOnce("[BadMeatCategory]: Could not find the MeatRaw-category. Will not sort bad meat.",
                "MeatRawCategory".GetHashCode());
            return;
        }

        var meatBadCategory = DefDatabase<ThingCategoryDef>.GetNamedSilentFail("MeatBad");
        if (meatBadCategory == null)
        {
            Log.ErrorOnce("[BadMeatCategory]: Could not find the MeatBad-category. Will not sort bad meat.",
                "MeatBadCategory".GetHashCode());
            return;
        }

        var extraThingDefs = getExtraThingDefs();
        var thingsToMove = new List<ThingDef>();
        foreach (var descendantThingDef in meatRawCategory.DescendantThingDefs)
        {
            if (FoodUtility.GetMeatSourceCategory(descendantThingDef) == MeatSourceCategory.Humanlike ||
                descendantThingDef.ingestible.sourceDef?.race != null &&
                descendantThingDef.ingestible.sourceDef.race.FleshType == FleshTypeDefOf.Insectoid)
            {
                thingsToMove.Add(descendantThingDef);
                continue;
            }

            if (extraThingDefs.Contains(descendantThingDef.defName))
            {
                thingsToMove.Add(descendantThingDef);
            }
        }

        foreach (var thingDef in thingsToMove)
        {
            meatRawCategory.childThingDefs.Remove(thingDef);
            thingDef.thingCategories.Remove(meatRawCategory);
            meatBadCategory.childThingDefs.Add(thingDef);
            thingDef.thingCategories.Add(meatBadCategory);
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

        meatRawCategory.ClearCachedData();
        meatBadCategory.ClearCachedData();
        meatRawCategory.ResolveReferences();
        meatBadCategory.ResolveReferences();
        Log.Message($"[BadMeatCategory]: Moved {thingsToMove.Count} meat to the Bad Meat-category");
    }
}