using System.Reflection;
using HarmonyLib;
using Verse;

namespace Falloutization.Drugs;

[StaticConstructorOnStartup]
internal static class HarmonyInit
{
    static HarmonyInit()
    {
        new Harmony("Falloutization.Drugs").PatchAll(Assembly.GetExecutingAssembly());
    }
}
