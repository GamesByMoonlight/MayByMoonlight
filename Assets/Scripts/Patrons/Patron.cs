﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patron : MonoBehaviour, IPatron {

    /* This class is used in conjunction with PatronSpawner to spawn.
    *  Valuable improvement would be to adjust spawn rate based on a difficulty that is adjusted on the fly
    *  
    *  Could be a base class, IPatron?  I'm not the best with interfaces but I do know they exist.
    */

    public float advanceSpeed = 4;
    public float seenEverySeconds;
    public AlcoholPref preferredAlcohol = AlcoholPref.Whiskey;
    public MixerPref preferredMixer = MixerPref.Coke;
    public GarnishPref preferredGarnish = GarnishPref.Lime;

    public int tipRate = 25;
    public int scoreRate = 100;

    public GameObject grabbedDrinkDisplay;
    
    public float MoveSpeed { get { return advanceSpeed; } }
    public int TipRate { get { return tipRate; } }
    public int ScoreRate { get { return scoreRate; } }


    // Update is called once per frame
    void Update () {
        // Just to make the objects move to the left, for demo purposes

        var xPos = transform.position.x;
        xPos += advanceSpeed * Time.deltaTime;

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
	}

    public void ReceiveDrink (GameObject myDrink)
    {
        
        if (myDrink.GetComponent<Drink>())
        {
            DrinkScore thisScore = new DrinkScore(myDrink.GetComponent<Drink>(), this);

            GameObject scoreDisplay = (Instantiate(grabbedDrinkDisplay));
            GrabbedDrinkDisplay gDD = scoreDisplay.GetComponent<GrabbedDrinkDisplay>();
            gDD.AssignScore(thisScore);
            scoreDisplay.transform.position = transform.position;
            
            Destroy(myDrink.gameObject);  // likely something else should be done with the drink, just cleaning it up
            Destroy(this.gameObject);
        }
    }
}


public enum AlcoholPref
{
    Whiskey, Vodka, Rum
}

public enum MixerPref
{
    Soda, Coke, Vermouth
}

public enum GarnishPref
{
    Lime, Cherry, Olive
}
