using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkCreator : MonoBehaviour {

    public Rigidbody drinkPrefab;
    public Transform drinkSpawnLoc;

    bool keypress = false;

	// Update is called once per frame
	void Update () {

        //Checking for keypress is a temporary work around until actual drink data can be passed in.
        if (Input.GetKey("s") && !keypress)
        {
            Rigidbody drinkInstance;
            drinkInstance = Instantiate(drinkPrefab, drinkSpawnLoc.position, drinkSpawnLoc.rotation) as Rigidbody;
            drinkInstance.AddForce(500, 0, 0);
            keypress = true;

        }
        else if (!Input.GetKey("s"))
        {

            keypress = false;
        }
		
	}
}
