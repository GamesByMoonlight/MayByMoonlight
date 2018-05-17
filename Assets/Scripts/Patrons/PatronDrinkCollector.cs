using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronDrinkCollector : MonoBehaviour {

    private IPatron myPatron;

	// Use this for initialization
	void Start () {
        myPatron = GetComponentInParent<IPatron>();
	}
	
	void OnTriggerEnter (Collider col)
    {
        if (col.GetComponent<Drink>()){
            GameObject drinkCollected = col.gameObject;
            myPatron.ReceiveDrink(drinkCollected);
        }
        
    }

}
