using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

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


}
