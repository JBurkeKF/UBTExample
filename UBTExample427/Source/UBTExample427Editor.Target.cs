// Copyright Kittehface Software 2024

using UnrealBuildTool;
using System.Collections.Generic;

public class UBTExample427EditorTarget : TargetRules
{
	public UBTExample427EditorTarget( TargetInfo Target) : base(Target)
	{
		Type = TargetType.Editor;
		DefaultBuildSettings = BuildSettingsVersion.V2;
		ExtraModuleNames.AddRange( new string[] { "UBTExample427" } );
	}
}
