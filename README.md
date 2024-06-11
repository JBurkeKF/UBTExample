Unreal Build Tool (UBT) Example

We've been exploring some of the ways we can use command line parameters to allow different types of builds on the same platform in Unreal.  If you're building from the command line or using the Project Launcher, you can specify extra build arguments with the `-ubtargs` switch.  There's a very good explanation of how to set things up here:

[PACKAGING UNREAL PROJECTS WITH UAT](https://greenforestgames.eu/article/Building-Unreal-projects-with-UAT-1605886728)

In brief, you can create a class member in your game's `Target.cs` build file and give it the `[CommandLine]` attribute.  If you run the build with -ubtargs=-customarg, that class member will be set appropriately, and you can read it and respond to it as desired.

`using UnrealBuildTool;

// Required for CommandLine attribute
// (if UE4.27, using Tools.DotNETCommon;)
using EpicGames.Core;

public class UBTExampleTarget : TargetRules
{
    [CommandLine("-targetsetting")]
    public bool bTargetSetting = false;

    public UBTExampleTarget(TargetInfo Target) : base(Target)
    {
        // ...
        // Existing code
        // ...

        if (bTargetSetting)
            // Do something if command line arg is present
    }
}`

Then run the command line with `-ubtargs` (the argument must match the value in the `[CommandLine]` attribute):

`<Unreal Engine location>\Engine\Build\BatchFiles\RunUAT.bat BuildCookRun -project=<project path> -platform=Win64 -clientconfig=Development -build -cook -pak -stage -ubtargs=-targetsetting -archive -archivedirectory=<archive path>`



The limitation here is that you can only get the command line arguments in a `Target.cs` file.  You have to use other means to communicate that information to individual module `Build.cs` files where it may actually be useful for setting preprocessor defines or including specific libraries.  However, you can actually access the command line arguments in a module `Build.cs` file by using .NET and Unreal Build Tool systems.  Specifically, you must create a `CommandLineArguments` object and pass it `System.Environment.GetCommandLineArgs()`, then call `.ApplyTo()` on the module.

`using UnrealBuildTool;

// Required for CommandLine attribute and CommandLineArguments
// (if UE4.27, using Tools.DotNETCommon;)
using EpicGames.Core;

public class UBTExample : ModuleRules
{
    [CommandLine("-modulesetting")]
    public bool bModuleSetting = false;

    public UBTExample(ReadOnlyTargetRules Target) : base(Target)
    {
        CommandLineArguments commandLineArguments =
            new CommandLineArguments(System.Environment.GetCommandLineArgs());
        commandLineArguments.ApplyTo(this);


        // ...
        // Existing code
        // ...

        if (bModuleSetting)
            // Do something if command line arg is present
    }
}`

This technique will work in module `Build.cs` files that are in the main game, and it will also work for modules in plugins, in case you want your plugin to read the command line and respond to it without having to do extra work in each project you add it to.

You also do not have to apply the command line arguments to a target or module.  You can create a custom object and apply values directly to it.

`using UnrealBuildTool;

// Required for CommandLine attribute and CommandLineArguments
// (if UE4.27, using Tools.DotNETCommon;)
using EpicGames.Core;

public class UBTExample : ModuleRules
{
    private class UBTExampleCommandLineData
    {
        [CommandLine("-examplesetting")]
        public bool bExampleSetting = false;
    }

    public UBTExample(ReadOnlyTargetRules Target) : base(Target)
    {
        UBTExampleCommandLineData ubtExampleCommandLineData =
            new UBTExampleCommandLineData();

        CommandLineArguments commandLineArguments =
            new CommandLineArguments(System.Environment.GetCommandLineArgs());
        commandLineArguments.ApplyTo(ubtExampleCommandLineData);

        // ...
        // Existing code
        // ...

        if (ubtExampleCommandLineData.bExampleSetting)
            // Do something if command line arg is present
    }
}`