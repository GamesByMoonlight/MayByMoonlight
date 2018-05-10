using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyPatron : MonoBehaviour, IPatron {

    [Tooltip("Percent amount in the final drink to earn 1 Tip and Score")]
    public float WhiskeyValue = 1f;
    public float VodkaValue = 1f;
    public float RumValue = 1f;
    public float SodaValue = 1f;
    public float CokeValue = 1f;
    public float VermouthValue = 1f;
    public Garnish TypeOfGarnish = Garnish.Lime;

    public int tipRate = 25;
    public int scoreRate = 100;

    [Tooltip("If true, the patron will tip double for double strong drinks")]
    public bool bigTipper = false;

    public float advanceSpeed = 4;
    public float seenEverySeconds = 6;

    public GameObject grabbedDrinkDisplay;

    public float MoveSpeed { get { return advanceSpeed; } set { advanceSpeed = value; } }
    public int TipRate { get { return tipRate; } }
    public int ScoreRate { get { return scoreRate; } }
    public float SeenEverySeconds { get { return seenEverySeconds; } }

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
