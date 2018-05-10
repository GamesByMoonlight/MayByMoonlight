using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbedDrinkDisplay : MonoBehaviour {

    public GameObject scoreDisplayPrefab;
    public GameObject tipDisplayPrefab;
    public GameObject satisfactionHeartsPrefab;

    public void AssignScore(DrinkScore drinkScore)
    {
        scoreDisplay.GetComponentInChildren<Text>().text = drinkScore.Score.ToString();

        tipDisplay.GetComponentInChildren<Text>().text = drinkScore.Bucks.ToString();

        satisfactionHearts.GetComponent<Animator>().SetInteger("MatchCount", drinkScore.PreferenceMatches);
    }

}
