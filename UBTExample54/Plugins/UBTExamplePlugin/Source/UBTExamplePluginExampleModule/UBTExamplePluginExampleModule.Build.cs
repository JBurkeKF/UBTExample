// Copyright Kittehface Software 2024

using UnrealBuildTool;

// Required for CommandLine attribute and CommandLineArguments
using EpicGames.Core;

// Required for logging
using Microsoft.Extensions.Logging;

public class UBTExamplePluginExampleModule : ModuleRules
{
	private class UBTExampleCommandLineData
	{
		[CommandLine("-exampledata")]
		public string ExampleData = null;
	}

	public UBTExamplePluginExampleModule(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
		PublicDependencyModuleNames.AddRange(new string[] { "Core" });
		
		PrivateDependencyModuleNames.AddRange(new string[] { "CoreUObject", "Engine", "Slate", "SlateCore" });

		Logger.LogInformation(string.Format("UBTExamplePlugin: command line data value - [{0}]", GetExampleData()));
	}

	public static string GetExampleData()
	{
		UBTExampleCommandLineData ubtExampleCommandLineData = new UBTExampleCommandLineData();

		CommandLineArguments commandLineArguments = new CommandLineArguments(System.Environment.GetCommandLineArgs());
		commandLineArguments.ApplyTo(ubtExampleCommandLineData);

		return ubtExampleCommandLineData.ExampleData;
	}
}
