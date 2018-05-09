using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patron : MonoBehaviour, IPatron     {

    /* This class is used in conjunction with PatronSpawner to spawn.
    *  Valuable improvement would be to adjust spawn rate based on a difficulty that is adjusted on the fly
    *  
    *  Could be a base class, IPatron?  I'm not the best with interfaces but I do know they exist.
    */

    public float advanceSpeed;
    public float seenEverySeconds;
    public AlcoholPref preferredAlcohol = AlcoholPref.Whiskey;
    public MixerPref preferredMixer = MixerPref.Coke;
    public GarnishPref preferredGarnish = GarnishPref.Lime;
    public int tipRate = 25;
    public int scoreRate = 100;
    public GameObject scoreDisplayPrefab;
    public GameObject tipDisplayPrefab;
    public GameObject satisfactionHeartsPrefab;



    // Update is called once per frame
    void Update () {
        // Just to make the objects move to the left, for demo purposes

        var xPos = transform.position.x;
        xPos += advanceSpeed * Time.deltaTime;

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
	}

    public void ReceiveDrink (GameObject myDrink)
    {
        Debug.Log("ReceiveDrink");

        if (myDrink.GetComponent<Drink>())
        {
            DrinkScore thisScore = new DrinkScore();
            thisScore = CalculateDrinkScore(myDrink.GetComponent<Drink>(), this);

            Debug.Log("Drink Collected");
            Debug.Log("Drink scored at " + thisScore.Bucks + " Bucks, " + thisScore.Score + " Points, and matched " + thisScore.PreferenceMatches + " preferences");

            GameObject scoreDisplay = Instantiate(scoreDisplayPrefab);
            scoreDisplay.transform.position = transform.position;
            scoreDisplay.GetComponentInChildren<Text>().text = thisScore.Score.ToString();

            GameObject tipDisplay = Instantiate(tipDisplayPrefab);
            tipDisplay.transform.position = transform.position;
            tipDisplay.GetComponentInChildren<Text>().text = thisScore.Bucks.ToString();

            GameObject satisfactionHearts = Instantiate(satisfactionHeartsPrefab);
            satisfactionHearts.transform.position = transform.position;
            satisfactionHearts.GetComponent<Animator>().SetInteger("MatchCount", thisScore.PreferenceMatches);

            Destroy(myDrink.gameObject);  // likely something else should be done with the drink, just cleaning it up
        }
    }



    private DrinkScore CalculateDrinkScore(Drink drinkToScore, Patron patron)
    {
        DrinkScore thisScore = new DrinkScore();

        switch (patron.preferredAlcohol)
        {
            case AlcoholPref.Whiskey:
                thisScore.Bucks += Mathf.RoundToInt(tipRate * drinkToScore.Whiskey);
                thisScore.Score += Mathf.RoundToInt(scoreRate * drinkToScore.Whiskey);
                if (drinkToScore.Whiskey > 0)
                    thisScore.PreferenceMatches += 1;
                break;
            case AlcoholPref.Vodka:
                thisScore.Bucks += Mathf.RoundToInt(tipRate * drinkToScore.Vodka);
                thisScore.Score += Mathf.RoundToInt(scoreRate * drinkToScore.Vodka);
                if (drinkToScore.Vodka > 0)
                    thisScore.PreferenceMatches += 1;
                break;
            case AlcoholPref.Rum:
                thisScore.Bucks += Mathf.RoundToInt(tipRate * drinkToScore.Rum);
                thisScore.Score += Mathf.RoundToInt(scoreRate * drinkToScore.Rum);
                if (drinkToScore.Rum > 0)
                    thisScore.PreferenceMatches += 1;
                break;
        }

        switch (patron.preferredMixer)
        {
            case MixerPref.Soda:
                thisScore.Bucks += Mathf.RoundToInt(tipRate * drinkToScore.Soda);
                thisScore.Score += Mathf.RoundToInt(scoreRate * drinkToScore.Soda);
                if (drinkToScore.Soda > 0)
                    thisScore.PreferenceMatches += 1;
                break;
            case MixerPref.Coke:
                thisScore.Bucks += Mathf.RoundToInt(tipRate * drinkToScore.Coke);
                thisScore.Score += Mathf.RoundToInt(scoreRate * drinkToScore.Coke);
                if (drinkToScore.Coke > 0)
                    thisScore.PreferenceMatches += 1;
                break;
            case MixerPref.Vermouth:
                thisScore.Bucks += Mathf.RoundToInt(tipRate * drinkToScore.Vermouth);
                thisScore.Score += Mathf.RoundToInt(scoreRate * drinkToScore.Vermouth);
                if (drinkToScore.Vermouth > 0)
                        thisScore.PreferenceMatches += 1;
                break;
        }
        
        if (drinkToScore.TypeOfGarnish == Garnish.Cherry && patron.preferredGarnish == GarnishPref.Cherry)
        {
            thisScore.Bucks += thisScore.Bucks;
            thisScore.Score += thisScore.Score;
            thisScore.PreferenceMatches += 1;
        }

        if (drinkToScore.TypeOfGarnish == Garnish.Lime && patron.preferredGarnish == GarnishPref.Lime)
        {
            thisScore.Bucks += thisScore.Bucks;
            thisScore.Score += thisScore.Score;
            thisScore.PreferenceMatches += 1;
        }

        if (drinkToScore.TypeOfGarnish == Garnish.Olive && patron.preferredGarnish == GarnishPref.Olive)
        {
            thisScore.Bucks += thisScore.Bucks;
            thisScore.Score += thisScore.Score;
            thisScore.PreferenceMatches += 1;
        }


        return thisScore;
    }


    public class DrinkScore
    {
        public DrinkScore()
        {
            Bucks = 0;
            Score = 0;
            PreferenceMatches = 0;
        }

        public int Bucks { get; set;  }
        public int Score { get; set;  }
        public int PreferenceMatches { get; set;}
        
    }
}
