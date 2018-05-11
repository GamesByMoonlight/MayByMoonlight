using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_levelManager : MonoBehaviour 
{
    public enum State
    {
        menu,
        mixing,
        serving
    };
    public State currentState;

    public int myMoney;
    public int myXp;

    public string drinkType;
    public string mixerType;
    public string garnishType;

    public bool addDrink;
    public bool addMixer;
    public bool hasGarnish;

    public float drinkAmount;
    public float mixerAmount;

    public Text drinkTypeText;
    public Text drinkAmountText;
    public Text mixerAmountText;

	// Use this for initialization
	void Start () 
    {
        addDrink = false;
        addMixer = false;
        hasGarnish = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (mixerType != string.Empty)
        {
            if (hasGarnish != true)
                drinkTypeText.text = "Current Drink: " + drinkType + " and " + mixerType;
            else
                drinkTypeText.text = "Current Drink: " + drinkType + " and " + mixerType + " with " + garnishType;
        }
        else
            drinkTypeText.text = "Current Drink: " + drinkType;
        
        drinkAmountText.text = "Alcohol: " + drinkAmount.ToString() + "%";
        mixerAmountText.text = "Mixer: " + mixerAmount.ToString() + "%";

        if (addDrink)
        {
            if (Input.GetMouseButton(0))
                drinkAmount += 5;
            if (drinkAmount >= 100)
                drinkAmount = 100;
            if (drinkAmount + mixerAmount >= 100)
                mixerAmount = 100 - drinkAmount;
        }

        if (addMixer)
        {
            if (Input.GetMouseButton(0))
                mixerAmount += 5;
            if (mixerAmount >= 100)
                mixerAmount = 100;
            if (drinkAmount + mixerAmount >= 100)
                drinkAmount = 100 - mixerAmount;
        }
	}

    void BuildDrink()
    {
        
    }

    void StartRound()
    {
    }
}
