using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class MyEditorScript
{
	public static void PerformBuild ()
	{
        string[] scenes = {""};
		BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
		buildPlayerOptions.scenes = scenes;
		buildPlayerOptions.locationPathName = "Build/windows/MayByMoonlight.exe";
		buildPlayerOptions.target = BuildTarget.StandaloneWindows;
		buildPlayerOptions.options = BuildOptions.None;
		BuildPipeline.BuildPlayer(buildPlayerOptions);
	}

	public static void PerformOSXBuild ()
	{
        string[] scenes = {""};
		BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
		buildPlayerOptions.scenes = scenes;
		buildPlayerOptions.locationPathName = "Build/osx/MayByMoonlight.app";
		buildPlayerOptions.target = BuildTarget.StandaloneOSX;
		buildPlayerOptions.options = BuildOptions.None;
		BuildPipeline.BuildPlayer(buildPlayerOptions);
	}
}