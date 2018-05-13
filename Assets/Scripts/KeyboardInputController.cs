﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputController : MonoBehaviour, IMixedDrink {
    public Drink DrinkPrefab;
    public float FillRate = .3f;
    public float DoubleTapTime = .5f;
    public GameObject[] lanes;

    private int maxLanes;

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
        maxLanes = lanes.Length;
    }

	// Update is called once per frame
	void Update () {
        GetLaneChangeInput();
        GetDrinkMixingInput();

        if(GarnishSelected()) 
        {
            lanes[lane].GetComponent<DrinkCreator>().InputDrink(MakeDrink().gameObject);
            ClearValues();
        } else if(EmptiedDrink() && doubleTapped)
        {
            doubleTapped = false;
            lanes[lane].GetComponent<DrinkCreator>().InputDrink(MakeWater().gameObject);
        }
	}

    void GetLaneChangeInput()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") < 0f)
                lane = lane == 0 ? 0 : lane - 1;
            else
                // Subtracting 1 from the max lanes here due to the array indexing it is used for.
                lane = lane == maxLanes-1 ? maxLanes-1 : lane + 1;
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

    Drink MakeDrink()
    {
        // Drink drink = new Drink();  // I believe this creates memory leaks in Unity
        var drink = Instantiate(DrinkPrefab);
        drink.WhiskeyValue = Whiskey;
        drink.RumValue = Rum;
        drink.VodkaValue = Vodka;
        drink.SodaValue = Soda;
        drink.CokeValue = Coke;
        drink.VermouthValue = Vermouth;
        drink.TypeOfGarnish = selectedGarnish;
        drink.LaneValue = lane;

        return drink;
    }

    Drink MakeWater()
    {
        // Drink drink = new Drink(); // I believe this creates memory leaks in Unity
        var drink = MakeDrink();
        drink.IsJustWaterValue = true;

        return drink;
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
}

