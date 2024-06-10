// Copyright Kittehface Software 2024

using UnrealBuildTool;

public class UBTExampleProjectModule : ModuleRules
{
	public UBTExampleProjectModule(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
	
		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore", "EnhancedInput" });

		PrivateDependencyModuleNames.AddRange(new string[] {  });
	}
}
