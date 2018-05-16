using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public int Bucks { get; set; }
    public int Score { get; set; }

    public Text bucksText;
    public Text scoreText;
    
	public void UpdateScoreboard(DrinkScore drinkScore)
    {
        Bucks += drinkScore.Bucks;
        Score += drinkScore.Score;

        bucksText.text = Bucks.ToString();
        scoreText.text = Score.ToString();
    }

    public void SubtractBucks(int bucksToSubtract)
    {
        Bucks -= bucksToSubtract;
        bucksText.text = Bucks.ToString();
    }

}
