using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferencesSceneDrinkSpawner : MonoBehaviour {

    public GameObject drinkPrefab;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnDrink());
	}


    IEnumerator SpawnDrink()
    {
        yield return new WaitForSeconds(2);

        Instantiate(drinkPrefab, transform);
        StartCoroutine(SpawnDrink());
    }

}
