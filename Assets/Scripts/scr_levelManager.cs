using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_levelManager : MonoBehaviour, IMixedDrink
{
    public enum State
    {
        menu,
        mixing,
        serving
    };
    public State currentState;

    public GameObject DrinkPrefab;
    public GameObject[] lanes;

    public string drinkType;
    public string mixerType;
    public string garnishType;

    public bool addDrink;
    public bool addMixer;
    public bool hasGarnish;

    public float drinkAmount;
    public float mixerAmount;

    // Better to separate UI logic from drink making logic
    //public Text drinkTypeText;
    //public Text drinkAmountText;
    //public Text mixerAmountText;

    private int laneValue;

    // IMixedDrink interface ---------------------------------
    public float Whiskey { get { return drinkType == "Whiskey" ? drinkAmount / 100f : 0f; } }
    public float Rum { get { return drinkType == "Rum" ? drinkAmount / 100f : 0f; } }
    public float Vodka { get { return drinkType == "Vodka" ? drinkAmount / 100f : 0f; } }
    public float Soda { get { return mixerType == "Soda" ? mixerAmount / 100f : 0f; } }
    public float Coke { get { return mixerType == "Cola" ? mixerAmount / 100f : 0f; } }
    public float Vermouth { get { return mixerType == "Vermouth" ? mixerAmount / 100f : 0f; } }
    public Garnish TheGarnish { get { return garnishType == "Cherry" ? Garnish.Cherry : garnishType == "Lime" ? Garnish.Lime : Garnish.Olive; } }
    public bool IsJustWater { get { return false; } }
    public int Lane { get { return laneValue; } }
    //----------------------------------------------------------

    // Use this for initialization
    void Start () 
    {
        ResetDrink();
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Better to separate UI logic from drink making logic
        //if (mixerType != string.Empty)
        //{
        //    if (hasGarnish != true)
        //        drinkTypeText.text = "Current Drink: " + drinkType + " and " + mixerType;
        //    else
        //        drinkTypeText.text = "Current Drink: " + drinkType + " and " + mixerType + " with " + garnishType;
        //}
        //else
        //    drinkTypeText.text = "Current Drink: " + drinkType;
        
        //drinkAmountText.text = "Alcohol: " + drinkAmount.ToString() + "%";
        //mixerAmountText.text = "Mixer: " + mixerAmount.ToString() + "%";

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

    public void MakeDrinkAtLane(int lane)
    {
        lanes[lane].GetComponent<DrinkCreator>().InputDrink(MakeDrink(lane).gameObject);
        ResetDrink();
    }

    GameObject MakeDrink(int lane)
    {
        laneValue = lane;
        var drink = Instantiate(DrinkPrefab).GetComponent<Drink>();
        drink.WhiskeyValue = Whiskey;
        drink.RumValue = Rum;
        drink.VodkaValue = Vodka;
        drink.SodaValue = Soda;
        drink.CokeValue = Coke;
        drink.VermouthValue = Vermouth;
        drink.TypeOfGarnish = TheGarnish;
        drink.LaneValue = lane;

        return drink.gameObject;
    }

    void ResetDrink()
    {
        addDrink = false;
        addMixer = false;
        hasGarnish = false;

        drinkAmount = 0f;
        mixerAmount = 0f;
    }
}
