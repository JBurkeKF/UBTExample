// Copyright Kittehface Software 2024

using UnrealBuildTool;
using System.Collections.Generic;

public class UBTExample427Target : TargetRules
{
	public UBTExample427Target( TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;
		DefaultBuildSettings = BuildSettingsVersion.V2;
		ExtraModuleNames.AddRange( new string[] { "UBTExample427" } );
	}
}
