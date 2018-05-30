using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreList : MonoBehaviour {

    List<Text> texts = new List<Text>();
    
	// Use this for initialization
	void Start () {
        RefreshHighScoreList();
	}
	
    public void ResetHighScores()
    {
        PlayerPrefsManager.ResetHighScores();
        RefreshHighScoreList();
    }

    private void RefreshHighScoreList()
    {
        foreach (Transform child in transform)
        {
            texts.Add(child.GetComponent<Text>());
        }

        int i = 0;

        foreach (Text childText in texts)
        {
            if (PlayerPrefsManager.GetPlayerScore(i) != 0)
            {
                childText.text = PlayerPrefsManager.GetPlayerName(i) + " - " + PlayerPrefsManager.GetPlayerScore(i).ToString();
            }
            i++;
        }
    }

}
