// Copyright Kittehface Software 2024

using UnrealBuildTool;

// Required for CommandLine attribute and CommandLineArguments
using EpicGames.Core;

// Required for logging
using Microsoft.Extensions.Logging;

public class UBTExamplePlugin : ModuleRules
{
	[CommandLine("-pluginsetting")]
	public bool bPluginSetting = false;

	public UBTExamplePlugin(ReadOnlyTargetRules Target) : base(Target)
	{
		CommandLineArguments commandLineArguments = new CommandLineArguments(System.Environment.GetCommandLineArgs());
		commandLineArguments.ApplyTo(this);

		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
		PublicDependencyModuleNames.AddRange(new string[] { "Core" });
		
		PrivateDependencyModuleNames.AddRange(new string[] { "CoreUObject", "Engine", "Slate", "SlateCore" });

		Logger.LogInformation(string.Format("UBTExamplePlugin: plugin setting value is set - {0}", bPluginSetting));
	}
}
