using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkCreator : MonoBehaviour {
    public Transform drinkSpawnLoc;

    public float DrinkSpeed = -500;


	// Update is called once per frame
	void Update () {

	}

    public void InputDrink(IMixedDrink input)
    {
        SpawnDrink( input );
    }

    private void SpawnDrink(IMixedDrink input)
    {
        input.gameObject.transform.position = drinkSpawnLoc.position;
        input.gameObject.transform.rotation = drinkSpawnLoc.rotation;
        input.gameObject.GetComponent<Rigidbody>().AddForce(DrinkSpeed, 0, 0);

    }
}
