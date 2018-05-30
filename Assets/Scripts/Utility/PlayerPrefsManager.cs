using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MUSIC_VOLUME_KEY = "music_volume";
    const string SFX_VOLUME_KEY = "sfx_volume";
    const string SCORE_KEY = "score_";
	const string PLAYER_KEY = "playerName_";

	private static void ArrangeHighScores()
    {
        int[] scores = new int[5];
        string[] players = new string[5];

        for (int i = 0; i < 5; i++)
        {
            players[i] = PlayerPrefs.GetString(PLAYER_KEY + i.ToString());
            scores[i] = PlayerPrefs.GetInt(SCORE_KEY + i.ToString());
        }

        int highestScore = 0;
        int position = 0;
        int count = 0;

        while (count <= players.Length)
        {
            highestScore = 0;
            position = 0;

            for (int i = 0; i < players.Length; i++)
            {
                if (scores[i] > highestScore)
                {
                    highestScore = scores[i];
                    position = i;
                }
            }

            PlayerPrefs.SetString(PLAYER_KEY + count.ToString(), players[position]);
            PlayerPrefs.SetInt(SCORE_KEY + count.ToString(), scores[position]);

            scores[position] = 0;

            count++;
        }

    }

    public static bool CheckForHighScore(int newScore)
    {
        if (newScore > PlayerPrefs.GetInt(SCORE_KEY + "4"))
        {
            return true;
        }

        return false;
    }

    public static void AddHighScore(string playerToAdd, int scoreToAdd)
    {
        ArrangeHighScores();
        PlayerPrefs.SetString(PLAYER_KEY + "4", playerToAdd);
        PlayerPrefs.SetInt(SCORE_KEY + "4", scoreToAdd);
        ArrangeHighScores();
    }

    public static string GetPlayerName(int index)
    {
        return PlayerPrefs.GetString(PLAYER_KEY + index.ToString());
    }

    public static int GetPlayerScore(int index)
    {
        return PlayerPrefs.GetInt(SCORE_KEY + index.ToString());
    }


    public static void SetMusicVolume(float volume)
    {
        if (volume >= 0f && volume <= 100f)
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
        }
        else Debug.LogError("Master volume out of range, set between 0 and 100");

    }

    public static float GetMusicVoume()
    {
        return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
    }

    public static void SetSFXVolume(float volume)
    {
        if (volume >= 0f && volume <= 100f)
        {
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
        }
        else Debug.LogError("SFX volume out of range, set between 0 and 100");

    }

    public static float GetSFXVoume()
    {
        return PlayerPrefs.GetFloat(SFX_VOLUME_KEY);
    }
}
