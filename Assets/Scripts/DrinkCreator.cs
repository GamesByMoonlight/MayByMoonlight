using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkCreator : MonoBehaviour {

    public Rigidbody drinkPrefab;
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
        Rigidbody drinkInstance;
        drinkInstance = Instantiate(drinkPrefab, drinkSpawnLoc.position, drinkSpawnLoc.rotation) as Rigidbody;
        drinkInstance.AddForce(DrinkSpeed, 0, 0);
        drinkInstance.GetComponent<Drink>().SetValues(input);
        //drinkInstance.


    }
}
