// Copyright Kittehface Software 2024

using UnrealBuildTool;

// Required for CommandLine attribute and CommandLineArguments
using Tools.DotNETCommon;

public class UBTExample427 : ModuleRules
{
	[CommandLine("-modulesetting")]
	public bool bModuleSetting = false;

	public UBTExample427(ReadOnlyTargetRules Target) : base(Target)
	{
		CommandLineArguments commandLineArguments = new CommandLineArguments(System.Environment.GetCommandLineArgs());
		commandLineArguments.ApplyTo(this);

		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
	
		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore" });

		Log.TraceInformation(string.Format("UBTExample: module setting value is set - {0}", bModuleSetting));
	}
}
