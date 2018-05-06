using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MUSIC_VOLUME_KEY = "music_volume";
	const string SFX_VOLUME_KEY = "sfx_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";   // level_unlocked_1, level_unlocked_2, etc

	public static void SetMusicVolume (float volume)
	{
		if (volume >= 0f && volume <= 100f) {
			PlayerPrefs.SetFloat (MUSIC_VOLUME_KEY, volume);
		} else Debug.LogError("Master volume out of range, set between 0 and 100");

	}

	public static float GetMusicVoume (){
		return PlayerPrefs.GetFloat (MUSIC_VOLUME_KEY);
	}

	public static void SetSFXVolume (float volume)
	{
		if (volume >= 0f && volume <= 100f) {
			PlayerPrefs.SetFloat (SFX_VOLUME_KEY, volume);
		} else Debug.LogError("SFX volume out of range, set between 0 and 100");

	}

	public static float GetSFXVoume (){
		return PlayerPrefs.GetFloat (SFX_VOLUME_KEY);
	}

	public static void UnlockLevel (int level)
	{
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {	
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1);  // use 1 for true
		} else {
			Debug.LogError ("Failed to unlock scene, scene index outside of maximum range");
		}
	}

	public static bool IsLevelUnlocked (int level)
	{
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);

		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			Debug.LogError("Checking for possible level outside of maximum range");
			return false;
		}

		return isLevelUnlocked;
	}

	public static void SetDifficulty (float difficulty)
	{
		if (difficulty < 0 || difficulty > 10) {
			Debug.LogError("Attempted to set difficulty outside of available range, must be from 0 to 10");
			return;
		}

		PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
	}


	public static float GetDifficulty (){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}

}
