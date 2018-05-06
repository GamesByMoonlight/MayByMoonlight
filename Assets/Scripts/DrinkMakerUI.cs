using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkMakerUI : MonoBehaviour {
    public GameObject DrinkToDisplay;

    IMixedDrink theDrink;

	// Use this for initialization
	void Start () {
        if(DrinkToDisplay != null)
        {
            theDrink = DrinkToDisplay.GetComponent<IMixedDrink>();
            if (theDrink != null)
                return;
        }
        Debug.Log("Could not find IMixedDrink implemented on DrinkToDisplay GameObject.  Can not display.");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
