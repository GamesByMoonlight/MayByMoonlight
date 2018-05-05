using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputController : MonoBehaviour {
    public Drink DrinkPrefab;
    public float FillRate = .01f;
    public int MaxLanes = 5;


    float whiskey, rum, vodka, soda, coke, vermouth;        // Final values
    Garnish selectedGarnish;
    int lane = 0;                                               // Current lane
	
    // Calculating in this way clamps each value between 0 - 1.0.  Returning via the ?: operator prevents dividing by 0.
    public float Whiskey { get { return whiskey == 0f ? 0f : whiskey / (whiskey + rum + vodka + soda + coke + vermouth); }}
    public float Rum { get { return rum == 0f ? 0f : rum / (whiskey + rum + vodka + soda + coke + vermouth); } }
    public float Vodka { get { return vodka == 0f ? 0f : vodka / (whiskey + rum + vodka + soda + coke + vermouth); } }
    public float Soda { get { return soda == 0f ? 0f : soda / (whiskey + rum + vodka + soda + coke + vermouth); } }
    public float Coke { get { return coke == 0f ? 0f : coke / (whiskey + rum + vodka + soda + coke + vermouth); } }
    public float Vermouth { get { return vermouth == 0f ? 0f : vermouth / (whiskey + rum + vodka + soda + coke + vermouth); } }

	// Update is called once per frame
	void Update () {
        GetLaneChangeInput();
        GetDrinkMixingInput();

        if(GarnishSelected()) 
        {
            MakeDrink();
            ClearValues();
        }
	}

    void GetLaneChangeInput()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") < 0f)
                lane = lane == 0 ? 0 : lane - 1;
            else
                lane = lane == MaxLanes ? MaxLanes : lane + 1;
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
        var drinkGO = Instantiate(DrinkPrefab);
        drinkGO.Whiskey = Whiskey;
        drinkGO.Rum = Rum;
        drinkGO.Vodka = Vodka;
        drinkGO.Soda = Soda;
        drinkGO.Coke = Coke;
        drinkGO.Vermouth = Vermouth;
        drinkGO.TypeOfGarnish = selectedGarnish;
        drinkGO.Lane = lane;
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
}

