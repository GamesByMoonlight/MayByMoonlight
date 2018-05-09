using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputController : MonoBehaviour, IMixedDrink {
    public Drink DrinkPrefab;
    public float FillRate = .3f;
    public float DoubleTapTime = .5f;
    public int MaxLanes = 5;

    public GameObject lane1;
    public GameObject lane2;
    public GameObject lane3;
    public GameObject lane4;
    public GameObject lane5;
    private GameObject[] lanes;


    float whiskey, rum, vodka, soda, coke, vermouth;    // Final values
    Garnish selectedGarnish;
    int lane = 0;                                       // Current lane
    bool doubleTapped = false;                          // Double tapping the clear glass button creates water
    float timeLastCleared = 0f;

    // Calculating in this way clamps each value between 0 - 1.0.  Returning via the ?: operator prevents dividing by 0.
    public float Whiskey    { get { return (whiskey + rum + vodka + soda + coke + vermouth) < 1f ? whiskey :    whiskey == 0f ? 0f : whiskey / (whiskey + rum + vodka + soda + coke + vermouth); }}
    public float Rum        { get { return (whiskey + rum + vodka + soda + coke + vermouth) < 1f ? rum :        rum == 0f ? 0f : rum / (whiskey + rum + vodka + soda + coke + vermouth); } }
    public float Vodka      { get { return (whiskey + rum + vodka + soda + coke + vermouth) < 1f ? vodka :      vodka == 0f ? 0f : vodka / (whiskey + rum + vodka + soda + coke + vermouth); } }
    public float Soda       { get { return (whiskey + rum + vodka + soda + coke + vermouth) < 1f ? soda :       soda == 0f ? 0f : soda / (whiskey + rum + vodka + soda + coke + vermouth); } }
    public float Coke       { get { return (whiskey + rum + vodka + soda + coke + vermouth) < 1f ? coke :       coke == 0f ? 0f : coke / (whiskey + rum + vodka + soda + coke + vermouth); } }
    public float Vermouth   { get { return (whiskey + rum + vodka + soda + coke + vermouth) < 1f ? vermouth :   vermouth == 0f ? 0f : vermouth / (whiskey + rum + vodka + soda + coke + vermouth); } }
    public int Lane { get { return lane; } }
    public bool IsJustWater { get { return false; } }
    public Garnish TheGarnish { get { return selectedGarnish; } }

    void Start()
    {
        lanes = new GameObject[MaxLanes];
        lanes[0] = lane1;
        lanes[1] = lane2;
        lanes[2] = lane3;
        lanes[3] = lane4;
        lanes[4] = lane5;
    }

	// Update is called once per frame
	void Update () {
        GetLaneChangeInput();
        GetDrinkMixingInput();

        if(GarnishSelected()) 
        {
            MakeDrink();
            ClearValues();
        } else if(EmptiedDrink() && doubleTapped)
        {
            doubleTapped = false;
            MakeWater();
        }
	}

    void GetLaneChangeInput()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") < 0f)
                lane = lane == 0 ? 0 : lane - 1;
            else
                // Subtracting 1 from the max lanes here 
                lane = lane == MaxLanes-1 ? MaxLanes-1 : lane + 1;
        }
    }

    void GetDrinkMixingInput()
    {
        whiskey += Input.GetAxis("Whiskey") * FillRate * Time.deltaTime;
        rum += Input.GetAxis("Rum") * FillRate * Time.deltaTime;
        vodka += Input.GetAxis("Vodka") * FillRate * Time.deltaTime;
        soda += Input.GetAxis("Soda") * FillRate * Time.deltaTime;
        coke += Input.GetAxis("Coke") * FillRate * Time.deltaTime;
        vermouth += Input.GetAxis("Vermouth") * FillRate * Time.deltaTime;
    }

    bool GarnishSelected()
    {
        if(Input.GetButtonDown("Lime"))
        {
            selectedGarnish = Garnish.Lime;
            return true;
        }
        else if (Input.GetButtonDown("Cherry"))
        {
            selectedGarnish = Garnish.Cherry;
            return true;
        }
        else if (Input.GetButtonDown("Olive"))
        {
            selectedGarnish = Garnish.Olive;
            return true;
        }
        return false;
    }

    void MakeDrink()
    {
        Drink drink = new Drink();
        drink.Whiskey = Whiskey;
        drink.Rum = Rum;
        drink.Vodka = Vodka;
        drink.Soda = Soda;
        drink.Coke = Coke;
        drink.Vermouth = Vermouth;
        drink.TypeOfGarnish = selectedGarnish;
        drink.Lane = lane;

        lanes[lane].GetComponent<DrinkCreator>().InputDrink(drink);

    }

    void ClearValues()
    {
        whiskey = 0f;
        rum = 0f;
        vodka = 0f;
        soda = 0f;
        coke = 0f;
        vermouth = 0f;
        // selectedGarnish doesn't matter
        // lane stays the same
    }

    bool EmptiedDrink()
    {
        if(Input.GetButtonDown("Clear"))
        {
            doubleTapped = Time.time - timeLastCleared < DoubleTapTime;
            timeLastCleared = Time.time;
            ClearValues();
            return true;
        }
        return false;
    }

    private void MakeWater()
    {
        Drink drink = new Drink();
        drink.IsJustWater = true;
        drink.Lane = lane;

        lanes[lane].GetComponent<DrinkCreator>().InputDrink(drink);
    }
}

