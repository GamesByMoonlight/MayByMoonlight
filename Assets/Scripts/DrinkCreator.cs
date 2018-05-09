using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkCreator : MonoBehaviour {
    public Transform drinkSpawnLoc;

    public float DrinkSpeed = -500;


	// Update is called once per frame
	void Update () {

	}

    public void InputDrink(Drink input)
    {
        SpawnDrink( input );
    }

    private void SpawnDrink(Drink input)
    {
        input.transform.position = drinkSpawnLoc.position;
        input.transform.rotation = drinkSpawnLoc.rotation;
        input.GetComponent<Rigidbody>().AddForce(DrinkSpeed, 0, 0);

    }
}
