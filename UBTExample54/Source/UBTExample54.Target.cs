// Copyright Kittehface Software 2024

using UnrealBuildTool;
using System.Collections.Generic;

public class UBTExample54Target : TargetRules
{
	public UBTExample54Target(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;
		DefaultBuildSettings = BuildSettingsVersion.V5;
		IncludeOrderVersion = EngineIncludeOrderVersion.Unreal5_4;
		ExtraModuleNames.Add("UBTExample54");
	}
}
