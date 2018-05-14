using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink2DSprite : MonoBehaviour {

    // Class to create a 2D image based on the values of IMixedDrink or IPatron
    // Will search all components of a game object
    
    void Start () {
        IPatron patron = transform.root.GetComponentInChildren<IPatron>();

        if (patron != null)
        {
            Debug.Log("Do Patron logic");
        }
	}
	
    public void updateImage(IMixedDrink theDrink)
    {
        Debug.Log("Update UI Image");
    }
}
