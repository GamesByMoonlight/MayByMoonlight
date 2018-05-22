using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabbedDrinkDisplay : MonoBehaviour {

    public GameObject scoreDisplayPrefab;
    public GameObject tipDisplayPrefab;
    public GameObject satisfactionHeartsPrefab;

    public void AssignScore(DrinkScore drinkScore)
    {
        scoreDisplayPrefab.GetComponentInChildren<Text>().text = drinkScore.Score.ToString();

        tipDisplayPrefab.GetComponentInChildren<Text>().text = drinkScore.Bucks.ToString();

        satisfactionHeartsPrefab.GetComponent<Animator>().SetInteger("MatchCount", drinkScore.PreferenceMatches);


        if (FindObjectOfType<ScoreDisplay>())
        {
            ScoreDisplay uiDisplay = FindObjectOfType<ScoreDisplay>();
            uiDisplay.UpdateScoreboard(drinkScore);
        }
    }

}
