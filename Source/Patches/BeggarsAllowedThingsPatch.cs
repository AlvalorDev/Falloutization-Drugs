using System.Collections.Generic;
using HarmonyLib;
using RimWorld.QuestGen;
using Verse;

namespace Falloutization.Drugs.Patches;

/// <summary>
/// Replaces Penoxycyline with FCP Radaway in the list of items beggars can request.
/// When FCP-Chems is not present, falls back to vanilla Penoxycyline.
/// </summary>
[HarmonyPatch(typeof(QuestNode_Root_Beggars), "get_AllowedThings")]
public static class BeggarsAllowedThingsPatch
{
    private static ThingDef _radaway;

    private static ThingDef Radaway =>
        _radaway ??= DefDatabase<ThingDef>.GetNamedSilentFail("FCP_Chem_Radaway");

    [HarmonyPrefix]
    public static bool Prefix(ref IEnumerable<ThingDef> __result)
    {
        ThingDef diseasePrevention = Radaway ?? ThingDefOf.Penoxycyline;
        __result = new[]
        {
            ThingDefOf.Silver,
            ThingDefOf.MedicineHerbal,
            ThingDefOf.MedicineIndustrial,
            diseasePrevention,
            ThingDefOf.Beer
        };
        return false;
    }
}
