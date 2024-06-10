// Copyright Kittehface Software 2024

using UnrealBuildTool;

public class UBTExamplePluginExampleModule : ModuleRules
{
	public UBTExamplePluginExampleModule(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] { "Core" });

		PrivateDependencyModuleNames.AddRange(new string[] { "CoreUObject", "Engine", "Slate", "SlateCore" });
	}
}
