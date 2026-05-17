# .github/copilot-instructions.md

## Mod Overview and Purpose

**Mod Name:** Bad Meat Category

**Description:**  
The Bad Meat Category mod categorizes different types of meat that would typically generate negative moods or thoughts when consumed in RimWorld. By sorting these meats into unique categories, players can manage and handle them more effectively in the game. It enhances gameplay by refining how meat types are identified and processed, improving the overall colony management experience.

The mod also includes a Russian translation courtesy of Tkhakiro, and it was inspired by an idea from Rasutei.

## Key Features and Systems

1. **Humanlike Race Meat Categorization:**  
   Categorizes all types of meat derived from humanlike races to avoid negative mood impacts when consumed by colonists.

2. **Specialized Meat Categories:**  
   - **Insectoids Meat**
   - **Rotten Meat** including Biotech xenotype expanded from - Rotfish
   - **Chaomeat** from Pawnmorpher
   - **Synthmeat** from Replimat
   - **Toxic Meat** from Vanilla Animals Expanded - Waste Animals
   - **Twisted Meat** from the Anomaly DLC
   - **Necro Meat** from The Army Of Fetid Corpses

3. **Seamless Integration:**  
   Integrates with existing systems and mod structures to work effortlessly within the game's framework.

## Coding Patterns and Conventions

- **Consistent Naming:**  
  Use CamelCase for class names and methods in C#. Ensure the names provide clear understanding of the functionality.

- **Single Responsibility Principle:**  
  Ensure each class and method has a single responsibility to maintain clarity and facilitate easy debugging and maintenance.

- **Comments and Documentation:**  
  Use XML documentation comments for classes and methods, providing descriptions of their purposes and any parameters.

- **Error Handling:**  
  Implement try-catch blocks where necessary to handle potential exceptions gracefully.

## XML Integration

- Incorporate XML definitions for categories and translations.
- Use XML to define new item categories and integrate them with existing game assets.
- Ensure correct linking between C# logic and XML definitions to maintain functionality and ensure compatibility.

## Harmony Patching

- Use Harmony to apply Postfix and Prefix patches where necessary to modify existing methods in the base game.
- Adhere to non-destructive modifications, ensuring compatibility with other mods by avoiding method replacement unless absolutely necessary.
- Before deploying patches, test thoroughly in a modded environment to ensure no conflicts or unexpected behaviors arise.

## Suggestions for Copilot

1. **Code Generation:**  
   Use Copilot to assist with boilerplate code generation for class structures, method skeletons, and XML definitions.

2. **Code Suggestions:**  
   Enable Copilot to provide real-time code suggestions to improve efficiency while writing C# and XML.

3. **Translation Management:**  
   Use Copilot to suggest translations based on existing content to streamline multi-language support.

4. **Harmony Patch Guidance:**  
   Employ Copilot to help identify potential points for patching and to suggest suitable Harmony code patterns.

5. **Error Checking:**  
   Utilize Copilot to identify potential logical errors and suggest corrections, improving code robustness.

Incorporating these guidelines will ensure that the Bad Meat Category mod is both functional and easy to maintain, while allowing for future enhancements and compatibility with other mods.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.
