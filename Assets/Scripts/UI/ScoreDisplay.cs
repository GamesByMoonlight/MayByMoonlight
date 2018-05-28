using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    // public int Bucks { get; set; }
    // public int Score { get; set; }
    public int Bucks;
    public int Score;

    public Text bucksText;
    public Text scoreText;

    private bool gameOverFlag = false;

    private Text SpeedNumberText ;
    private Text PatronsText;

    public void Start() {

    }

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


        if (Bucks < 0f && !gameOverFlag)
        {
            gameOverFlag = true;
            GameEventSystem.Instance.GameEnded.Invoke();
        }
    }
    public void SubtractScore(int scoreToSubtract)
    {
        Score -= scoreToSubtract;
        scoreText.text = Score.ToString();

    }
  
}
