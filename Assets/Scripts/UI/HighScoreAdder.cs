using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreAdder : MonoBehaviour {

    public ScoreDisplay scoreDisplay;
    public InputField inputField;

	public void SaveHighScoreAndRestart()
    {
        PlayerPrefsManager.AddHighScore(inputField.text, scoreDisplay.Score);
        FindObjectOfType<GameManager>().Restart();
    }
}
