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

		// The target is created multiple times at different stages of the Unreal build process, and
		// depending on the stage, it may or may not have full context to access the contents of
		// the various modules.  It will not compile correctly with direct references to code in
		// other modules, so if we really want to access that code, we must use reflection.
		System.Reflection.Assembly buildAssembly = System.Reflection.Assembly.GetExecutingAssembly();
		System.Type ubtExamplePluginExampleModuleType = null;

		// Under most circumstances, trying to get the module type will just result in a null value
		// that we can check against.  However, if this is running in an Unreal Engine that is in
		// source code format (instead of a built engine like those provided in the Epic Games
		// Launcher), the .GetType() call will actually throw an exception trying to access
		// the type.  We must wrap this in a try/catch so the Unreal build process can proceed.
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
