using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    // This class is temporary just so that there's a UI on screen.  

    public int bucks;
    public int score;

    public Text bucksText;
    public Text scoreText;

    public int bucksLossPerMinute = 500;

    private float buckLossAccumulator = 0;
    private bool gameOverFlag = false;

	public void UpdateScoreboard(DrinkScore drinkScore)
    {
        bucks += drinkScore.Bucks;
        score += drinkScore.Score;

        bucksText.text = bucks.ToString();
        scoreText.text = score.ToString();
    }

    void Update()
    {
        buckLossAccumulator += bucksLossPerMinute / 60 * Time.deltaTime;

        if (Mathf.RoundToInt(buckLossAccumulator) > 1)
        {
            bucks -= Mathf.RoundToInt(buckLossAccumulator);
            buckLossAccumulator -= Mathf.RoundToInt(buckLossAccumulator);
            bucksText.text = bucks.ToString();
        }

        if(bucks < 0f && !gameOverFlag)
        {
            gameOverFlag = true;
            GameEventSystem.Instance.GameEnded.Invoke();
        }
    }


}
