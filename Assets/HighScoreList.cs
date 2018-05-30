using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreList : MonoBehaviour {

    List<Text> texts = new List<Text>();
    
	// Use this for initialization
	void Start () {
        foreach (Transform child in transform)
        {
            texts.Add(child.GetComponent<Text>());
        }

        int i = 0;

        foreach (Text childText in texts)
        {
            childText.text = PlayerPrefsManager.GetPlayerName(i) + " - " + PlayerPrefsManager.GetPlayerScore(i).ToString();
            i++;
        }
	}
	
}
