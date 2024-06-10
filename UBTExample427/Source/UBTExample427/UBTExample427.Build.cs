// Copyright Kittehface Software 2024

using UnrealBuildTool;

public class UBTExample427 : ModuleRules
{
	public UBTExample427(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
	
		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore" });
	}
}
