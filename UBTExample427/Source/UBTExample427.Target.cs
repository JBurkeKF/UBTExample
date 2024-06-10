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

		System.Reflection.Assembly buildAssembly = System.Reflection.Assembly.GetExecutingAssembly();
		System.Type ubtExamplePluginExampleModuleType = null;

		try
		{
			ubtExamplePluginExampleModuleType = buildAssembly.GetType("UBTExamplePluginExampleModule");
		}
		catch
		{
			Log.TraceInformation("UBTExample: could not get UBTExamplePluginExampleModule type information");
		}

		if (ubtExamplePluginExampleModuleType != null)
		{
			System.Reflection.MethodInfo getExampleDataMethodInfo = ubtExamplePluginExampleModuleType.GetMethod("GetExampleData", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

			if (getExampleDataMethodInfo != null)
			{
				object result = getExampleDataMethodInfo.Invoke(null, null);

				if (result != null && result is string)
				{
					Log.TraceInformation(string.Format("UBTExample: target command line data value - [{0}]", (string)result));
				}
				else
				{
					Log.TraceInformation("UBTExample: target could not access command line data value");
				}
			}
		}
	}
}
