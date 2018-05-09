using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronDrinkCollector : MonoBehaviour {

    private Patron myPatron;

	// Use this for initialization
	void Start () {
        myPatron = GetComponentInParent<Patron>();
	}
	
	void OnTriggerEnter (Collider col)
    {
        if (col.GetComponent<Drink>()){
            Debug.Log("ow!");
            GameObject drinkCollected = col.gameObject;
            myPatron.ReceiveDrink(drinkCollected);
        }
        
    }

}
