using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkCreator : MonoBehaviour {
    public Transform drinkSpawnLoc;

    public float DrinkSpeed = -500;


	// Update is called once per frame
	void Update () {

	}

    public void InputDrink(GameObject input)
    {
        SpawnDrink( input );
        GameEventSystem.Instance.DrinkMade.Invoke(input);
    }

    private void SpawnDrink(GameObject input)
    {
        input.transform.position = drinkSpawnLoc.position;
        input.transform.rotation = drinkSpawnLoc.rotation;
        input.GetComponent<Rigidbody>().AddForce(DrinkSpeed, 0, 0);

    }
}
