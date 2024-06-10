// Copyright Kittehface Software 2024

using UnrealBuildTool;

// Required for CommandLine attribute and CommandLineArguments
using EpicGames.Core;

// Required for logging
using Microsoft.Extensions.Logging;

public class UBTExample54 : ModuleRules
{
	[CommandLine("-modulesetting")]
	public bool bModuleSetting = false;

	public UBTExample54(ReadOnlyTargetRules Target) : base(Target)
	{
		CommandLineArguments commandLineArguments = new CommandLineArguments(System.Environment.GetCommandLineArgs());
		commandLineArguments.ApplyTo(this);

		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
	
		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore", "EnhancedInput" });

		PrivateDependencyModuleNames.AddRange(new string[] {  });

		Logger.LogInformation(string.Format("UBTExample: module setting value is set - {0}", bModuleSetting));
	}
}
