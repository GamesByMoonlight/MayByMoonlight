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

    // This is handled by scoring manager
    //public int myMoney;
    //public int myXp;

    public string drinkType;
    public string mixerType;
    public Garnish garnishType;

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
    public float Whiskey { get { return drinkType == "Whiskey" ? drinkAmount / 100f : 0f; } set { drinkType = "Whiskey"; drinkAmount = value; } }
    public float Rum { get { return drinkType == "Rum" ? drinkAmount / 100f : 0f; } set { drinkType = "Rum"; drinkAmount = value; } }
    public float Vodka { get { return drinkType == "Vodka" ? drinkAmount / 100f : 0f; } set { drinkType = "Vodka"; drinkAmount = value; } }
    public float Soda { get { return mixerType == "Soda" ? mixerAmount / 100f : 0f; } set { mixerType = "Soda"; drinkAmount = value; } }
    public float Coke { get { return mixerType == "Cola" ? mixerAmount / 100f : 0f; } set { mixerType = "Cola"; drinkAmount = value; } }
    public float Vermouth { get { return mixerType == "Vermouth" ? mixerAmount / 100f : 0f; } set { mixerType = "Vermouth"; drinkAmount = value; } }
    public Garnish TheGarnish { get { return garnishType; } set { garnishType = value; } }
    public bool IsJustWater { get { return false; } set { Debug.Log("Controller water value set (does nothing) " + value); } }
    public int Lane { get { return laneValue; } set { laneValue = value; } }
    //----------------------------------------------------------

    // Use this for initialization
    void Start () 
    {
        ResetDrink();
        GameEventSystem.Instance.DrinkMade.AddListener(DrinkMadeListener);
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
        drink.Whiskey = Whiskey;
        drink.Rum = Rum;
        drink.Vodka = Vodka;
        drink.Soda = Soda;
        drink.Coke = Coke;
        drink.Vermouth = Vermouth;
        drink.TheGarnish = TheGarnish;
        drink.Lane = lane;
        drink.IsJustWater = false;

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

    void DrinkMadeListener(GameObject drink)
    {
        ResetDrink();
    }

    private void OnDestroy()
    {
        if (GameEventSystem.Instance != null)
            GameEventSystem.Instance.DrinkMade.RemoveListener(DrinkMadeListener);
    }
}
