// Copyright Kittehface Software 2024

using UnrealBuildTool;
using System.Collections.Generic;

// Required for CommandLine attribute
using EpicGames.Core;

// Required for logging
using Microsoft.Extensions.Logging;

public class UBTExample54Target : TargetRules
{
	[CommandLine("-targetsetting")]
	public bool bTargetSetting = false;

	public UBTExample54Target(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;
		DefaultBuildSettings = BuildSettingsVersion.V5;
		IncludeOrderVersion = EngineIncludeOrderVersion.Unreal5_4;
		ExtraModuleNames.Add("UBTExample54");

		Logger.LogInformation(string.Format("UBTExample: target setting value is set - {0}", bTargetSetting));
	}
}
