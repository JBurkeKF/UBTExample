// Copyright Kittehface Software 2024

using UnrealBuildTool;
using System.Collections.Generic;

// Required for CommandLine attribute
using EpicGames.Core;

// Required for logging
using Microsoft.Extensions.Logging;

public class UBTExample54EditorTarget : TargetRules
{
	[CommandLine("-editortargetsetting")]
	public bool bEditorTargetSetting = false;

	public UBTExample54EditorTarget( TargetInfo Target) : base(Target)
	{
		Type = TargetType.Editor;
		DefaultBuildSettings = BuildSettingsVersion.V5;
		IncludeOrderVersion = EngineIncludeOrderVersion.Unreal5_4;
		ExtraModuleNames.Add("UBTExample54");

		Logger.LogInformation(string.Format("UBTExampleEditor: target setting value is set - {0}", bEditorTargetSetting));
	}
}
