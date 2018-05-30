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

        int maxScore = 0;
        int position = 0;

        string movingPlayer;
        int movingScore;

        for (int j = 0; j < 5; j++)
        {
            maxScore = 0;
            position = 0;

            for (int i = j; i < 5; i++)
            {
                if (scores[i] > maxScore)
                {
                    maxScore = scores[i];
                    position = i;
                }
            }

            movingPlayer = players[position];
            movingScore = scores[position];

            players[position] = players[j];
            scores[position] = scores[j];

            players[j] = movingPlayer;
            scores[j] = movingScore;
        }

        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetString(PLAYER_KEY + i.ToString(), players[i]);
            PlayerPrefs.SetInt(SCORE_KEY + i.ToString(), scores[i]);
        }
    }

    public static bool CheckForHighScore(int newScore)
    {
        if (newScore > PlayerPrefs.GetFloat(SCORE_KEY + "4"))
        {
            return true;
        }

        return false;
    }

    public static void AddHighScore(string playerToAdd, int scoreToAdd)
    {
        PlayerPrefs.SetString(PLAYER_KEY + "4", playerToAdd);
        PlayerPrefs.SetFloat(SCORE_KEY + "4", scoreToAdd);
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
