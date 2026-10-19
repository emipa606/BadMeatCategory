# GitHub Copilot Instructions for Bad Meat Category Mod Development

## Overview and Purpose

The **Bad Meat Category** mod is designed to enhance the organization of RimWorld's inventory system by categorizing various types of meats that are undesirable due to their source or potential negative effects when consumed. This includes meat obtained from different factions or creatures that would cause bad thoughts or have unique properties. The mod introduces distinct categories for these meats, making it easier for players to manage their resources and avoid accidental consumption by their colonists.

## Key Features and Systems

- **Custom Meat Categories**: The mod separates meats into specific categories based on origin or effect, such as:
  - Humanlike race meats that cause negative moodlets.
  - Insectoid meats.
  - Chaomeat from the Pawnmorpher mod.
  - Rotten and toxic meats from various mods.
  - Synthmeat and necro meat from other RimWorld expansions.
- **Russian Localization**: The mod features a Russian translation, thanks to the contributions of Tkhakiro.
- **Seamless Integration**: The mod integrates with existing categories and remains compatible with popular RimWorld expansions that introduce new meat types.

## Coding Patterns and Conventions

- **Consistent Naming**: Use PascalCase for class and method names, and camelCase for local variables within methods.
- **Clear Method Functionality**: Methods like `getExtraThingDefs` and `SetupBadMeatCategory` should explicitly state their purpose through names and comments where necessary.
- **XML Integration**: Utilize XML files to define custom categories, keeping them separate from code logic to allow easy localization and customization.

## XML Integration

- **XML Structure**:
  - Use XML files to define custom meat categories. The mod’s XML definition resides in `ThingCategories.xml`.
  - Follow RimWorld's XML schema for ThingCategoryDef to ensure proper integration.

Example Snippet:
xml
<ThingCategoryDef>
  <defName>BadMeatCategory</defName>
  <label>bad meat</label>
  <description>Meat that causes negative effects when consumed.</description>
  ...
</ThingCategoryDef>


## Harmony Patching

- **Usage of Harmony**: Employ Harmony to patch the necessary methods in RimWorld to introduce new categories without modifying the original game files directly.
- **Target Specific Methods**: Focus on methods handling meat classification and inventory management.
- **Safety in Patching**: Ensure patches perform existence checks to prevent runtime errors.

## Suggestions for Copilot

- **Autocomplete Feature**: Utilize GitHub Copilot to generate stubs for new methods such as category management functions.
- **Refactoring Suggestions**: Consider using Copilot to refactor repetitive code patterns, making the code base cleaner and more efficient.
- **Documentation Generation**: Use Copilot to help generate XML documentation comments for public methods and classes to improve code readability.
- **Localization Assistance**: Leverage Copilot to automate string conversion for new category labels to ensure consistent localization support.
- **Harmony Examples**: Request Copilot to provide examples of Harmony patches, specifically for targeting methods in `ThingCategory` manipulations.

By following these guidelines and utilizing the tools mentioned, the development and maintenance of the **Bad Meat Category** mod should be streamlined and effective, providing an enhanced modding experience for the RimWorld community.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

