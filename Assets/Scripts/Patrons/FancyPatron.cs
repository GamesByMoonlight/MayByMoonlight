﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyPatron : MonoBehaviour, IPatron {

    public float WhiskeyValue = 0f;
    public float VodkaValue = 0f;
    public float RumValue = 0f;
    public float SodaValue = 0f;
    public float CokeValue = 0f;
    public float VermouthValue = 0f;
    public Garnish TypeOfGarnish = Garnish.Lime;

    public int tipRate = 25;
    public int scoreRate = 100;

    public bool bigTipper = false;

    public float advanceSpeed = 4;

    public GameObject grabbedDrinkDisplay;

    public float MoveSpeed { get { return advanceSpeed; } set { advanceSpeed = value; } }
    public int TipRate { get { return tipRate; } }
    public int ScoreRate { get { return scoreRate; } }

    // Update is called once per frame
    void Update () {
        var xPos = transform.position.x;
        xPos += advanceSpeed * Time.deltaTime;

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    public void ReceiveDrink(GameObject myDrink)
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
