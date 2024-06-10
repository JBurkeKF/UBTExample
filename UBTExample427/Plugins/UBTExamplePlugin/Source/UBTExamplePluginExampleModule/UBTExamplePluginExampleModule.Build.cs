// Copyright Kittehface Software 2024

using UnrealBuildTool;

// Required for CommandLine attribute and CommandLineArguments
using Tools.DotNETCommon;

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

		Log.TraceInformation(string.Format("UBTExamplePlugin: command line data value - [{0}]", GetExampleData()));
	}

	public static string GetExampleData()
	{
		UBTExampleCommandLineData ubtExampleCommandLineData = new UBTExampleCommandLineData();

		CommandLineArguments commandLineArguments = new CommandLineArguments(System.Environment.GetCommandLineArgs());
		commandLineArguments.ApplyTo(ubtExampleCommandLineData);

		return ubtExampleCommandLineData.ExampleData;
	}
}
