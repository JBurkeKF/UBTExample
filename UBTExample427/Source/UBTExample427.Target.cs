// Copyright Kittehface Software 2024

using UnrealBuildTool;
using System.Collections.Generic;

// Required for CommandLine attribute
using Tools.DotNETCommon;

public class UBTExample427Target : TargetRules
{
	[CommandLine("-targetsetting")]
	public bool bTargetSetting = false;

	public UBTExample427Target( TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;
		DefaultBuildSettings = BuildSettingsVersion.V2;
		ExtraModuleNames.AddRange( new string[] { "UBTExample427" } );

		Log.TraceInformation(string.Format("UBTExample: target setting value is set - {0}", bTargetSetting));
	}
}
