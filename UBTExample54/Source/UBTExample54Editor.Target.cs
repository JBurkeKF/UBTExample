// Copyright Kittehface Software 2024

using UnrealBuildTool;
using System.Collections.Generic;

public class UBTExample54EditorTarget : TargetRules
{
	public UBTExample54EditorTarget( TargetInfo Target) : base(Target)
	{
		Type = TargetType.Editor;
		DefaultBuildSettings = BuildSettingsVersion.V5;
		IncludeOrderVersion = EngineIncludeOrderVersion.Unreal5_4;
		ExtraModuleNames.Add("UBTExample54");
	}
}
