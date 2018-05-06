using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkCreator : MonoBehaviour {

    public Rigidbody drinkPrefab;
    public Transform drinkSpawnLoc;

    public float DrinkSpeed = -500;

    bool keypress = false;

	// Update is called once per frame
	void Update () {

        //Checking for keypress is a temporary work around until actual drink data can be passed in.
        if (Input.GetKey("s") && !keypress)
        {
            // This is the actual drink spawning code to save.
            Rigidbody drinkInstance;
            drinkInstance = Instantiate(drinkPrefab, drinkSpawnLoc.position, drinkSpawnLoc.rotation) as Rigidbody;
            drinkInstance.AddForce(DrinkSpeed, 0, 0);
            keypress = true;

        }
        else if (!Input.GetKey("s"))
        {

            keypress = false;
        }
		
	}
}
