using Verse;

namespace BadMeatCategory;

[StaticConstructorOnStartup]
public class Startup
{
    static Startup()
    {
        BadMeatCategory.SetupBadMeatCategory();
    }
}