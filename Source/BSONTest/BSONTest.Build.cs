// Fill out your copyright notice in the Description page of Project Settings.

using UnrealBuildTool;
using System;
using System.IO;

public class BSONTest : ModuleRules
{

    private string ModulePath
    {
        get { return ModuleDirectory; }
    }

    private string ThirdPartyPath
    {
        get { return Path.GetFullPath(Path.Combine(ModulePath, "../../ThirdParty/")); }
    }

    public BSONTest(TargetInfo Target)
	{
		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore" });

		PrivateDependencyModuleNames.AddRange(new string[] {  });

        string BSONPath = Path.Combine(ThirdPartyPath, "bson");

        // Console.WriteLine("");
        Console.WriteLine("BSONPath: " + BSONPath);

        Definitions.Add("BSON_COMPILATION"); // Necessary to avoid linker errors to missing bson symbols
        // Switch between the different target platforms 
        // to include the correct lib and header files
        // Header files are platform specific in libbson, 
        // so we have to need to add different include paths
        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            Console.WriteLine("Using Win64 BSON files");
            PublicAdditionalLibraries.Add(Path.Combine(BSONPath, "lib", "bson-static-1.0.lib"));
            PublicIncludePaths.Add(Path.Combine(BSONPath, "include", "win64"));
        }
        else if(Target.Platform == UnrealTargetPlatform.Linux)
        {
            Console.WriteLine("Using Linux BSON files");
            PublicAdditionalLibraries.Add(Path.Combine(BSONPath, "lib", "libbson-1.0.a"));
            PublicIncludePaths.Add(Path.Combine(BSONPath, "include", "linux"));
        }
        else
        {
            Console.WriteLine("Unsupported OS - Only win64 and Linux are currently supported");
        }

        // Uncomment if you are using Slate UI
        // PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

        // Uncomment if you are using online features
        // PrivateDependencyModuleNames.Add("OnlineSubsystem");

        // To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true
    }
}
