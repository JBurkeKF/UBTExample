// Copyright Kittehface Software 2024

using UnrealBuildTool;
using System.Collections.Generic;

// Required for CommandLine attribute
using Tools.DotNETCommon;

public class UBTExample427EditorTarget : TargetRules
{
	[CommandLine("-editortargetsetting")]
	public bool bEditorTargetSetting = false;

	public UBTExample427EditorTarget( TargetInfo Target) : base(Target)
	{
		Type = TargetType.Editor;
		DefaultBuildSettings = BuildSettingsVersion.V2;
		ExtraModuleNames.AddRange( new string[] { "UBTExample427" } );

		Log.TraceInformation(string.Format("UBTExampleEditor: target setting value is set - {0}", bEditorTargetSetting));
	}
}
