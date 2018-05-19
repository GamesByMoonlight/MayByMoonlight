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
    public GameObject CurrentDrinkInProgress;
    IMixedDrink CurrentDrink;

    public string drinkType;
    public string mixerType;

    public bool addDrink;
    public bool addMixer;
    public bool hasGarnish;

    public float drinkAmount;
    public float mixerAmount;

    // IMixedDrink interface ---------------------------------
    public float Whiskey { get { return CurrentDrink.Whiskey; } set { CurrentDrink.Whiskey = value; } }
    public float Rum { get { return CurrentDrink.Rum; } set { CurrentDrink.Rum = value; } }
    public float Vodka { get { return CurrentDrink.Vodka; } set { CurrentDrink.Vodka = value; } }
    public float Soda { get { return CurrentDrink.Soda; } set { CurrentDrink.Soda = value; } }
    public float Coke { get { return CurrentDrink.Coke; } set { CurrentDrink.Coke = value; } }
    public float Vermouth { get { return CurrentDrink.Vermouth; } set { CurrentDrink.Vermouth = value; } }
    public Garnish TheGarnish { get { return CurrentDrink.TheGarnish; } set { CurrentDrink.TheGarnish = value; } }
    public bool IsJustWater { get { return false; } set { Debug.Log("Controller water value set (does nothing) " + value); } }
    public int Lane { get { return CurrentDrink.Lane; } set { CurrentDrink.Lane = value; } }
    //----------------------------------------------------------

    // Use this for initialization
    void Start () 
    {
        ResetDrink();
        CurrentDrink = CurrentDrinkInProgress.GetComponent<IMixedDrink>();
        GameEventSystem.Instance.DrinkMade.AddListener(DrinkMadeListener);
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (addDrink)
        {
            if (Input.GetMouseButton(0))
                drinkAmount += 5;
            if (drinkAmount >= 100)
                drinkAmount = 100;
            if (drinkAmount + mixerAmount >= 100)
                mixerAmount = 100 - drinkAmount;
            UpdateDrink();
        }

        if (addMixer)
        {
            if (Input.GetMouseButton(0))
                mixerAmount += 5;
            if (mixerAmount >= 100)
                mixerAmount = 100;
            if (drinkAmount + mixerAmount >= 100)
                drinkAmount = 100 - mixerAmount;
            UpdateDrink();
        }
	}

    void UpdateDrink()
    {
        
    }

    public void MakeDrinkAtLane(int lane)
    {
        lanes[lane].GetComponent<DrinkCreator>().InputDrink(MakeDrink(lane).gameObject);
        ResetDrink();
    }

    GameObject MakeDrink(int lane)
    {
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
