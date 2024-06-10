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

		System.Reflection.Assembly buildAssembly = System.Reflection.Assembly.GetExecutingAssembly();
		System.Type ubtExamplePluginExampleModuleType = null;

		try
		{
			ubtExamplePluginExampleModuleType = buildAssembly.GetType("UBTExamplePluginExampleModule");
		}
		catch
		{
			Logger.LogInformation("UBTExample: could not get UBTExamplePluginExampleModule type information");
		}

		if (ubtExamplePluginExampleModuleType != null)
		{
			System.Reflection.MethodInfo getExampleDataMethodInfo = ubtExamplePluginExampleModuleType.GetMethod("GetExampleData", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

			if (getExampleDataMethodInfo != null)
			{
				object result = getExampleDataMethodInfo.Invoke(null, null);

				if (result != null && result is string)
				{
					Logger.LogInformation(string.Format("UBTExample: target command line data value - [{0}]", (string)result));
				}
				else
				{
					Logger.LogInformation("UBTExample: target could not access command line data value");
				}
			}
		}
	}
}
