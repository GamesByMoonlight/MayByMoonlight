using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputController : MonoBehaviour {
    public Drink DrinkPrefab;
    public float FillRate = .01f;
    public int MaxLanes = 5;


    float whiskey, rum, vodka, soda, coke, vermouth;        // Final values
    float iwhiskey, irum, ivodka, isoda, icoke, ivermouth;  // Input values per frame
    int lane = 0;                                               // Current lane
	
	// Update is called once per frame
	void Update () {
        GetLaneChangeInput();
        GetDrinkMixingInput();

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
        iwhiskey = Input.GetAxis("Whiskey");
        irum = Input.GetAxis("Rum");
        ivodka = Input.GetAxis("Vodka");
        isoda = Input.GetAxis("Soda");
        icoke = Input.GetAxis("Coke");
        ivermouth = Input.GetAxis("Vermouth");
    }
}
