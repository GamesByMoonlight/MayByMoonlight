using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkMakerUI : MonoBehaviour {
    public GameObject DrinkToDisplay;

    public Slider Alcohol;
    public Image AlcoholFill;
    public Slider Mixer;
    public Image MixerFill;
    public Text LaneValue;
    public Text GarnishValue;

    IMixedDrink theDrink;

	// Use this for initialization
	void Start () {
        if(DrinkToDisplay != null)
        {
            theDrink = DrinkToDisplay.GetComponent<IMixedDrink>();
            if (theDrink != null)
            {
                return;
            }
        }
        Debug.Log("Could not find IMixedDrink implemented on DrinkToDisplay GameObject.  Can not display.");
	}
	
	// Update is called once per frame
	void Update () {
        AlcoholFill.color = new Color(theDrink.Rum, theDrink.Whiskey, theDrink.Vodka);
        MixerFill.color = new Color(theDrink.Coke, theDrink.Soda, theDrink.Vermouth);
        Alcohol.value = theDrink.Rum + theDrink.Whiskey + theDrink.Vodka;
        Mixer.value = theDrink.Coke + theDrink.Soda + theDrink.Vermouth;
        LaneValue.text = theDrink.Lane.ToString();
        GarnishValue.text = "(previous) " + theDrink.TheGarnish;
	}
}
