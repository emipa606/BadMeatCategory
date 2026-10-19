using Verse;

namespace BadMeatCategory;

[StaticConstructorOnStartup]
public static class Startup
{
    static Startup()
    {
        BadMeatCategory.SetupBadMeatCategory();
    }
}