using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink2DSprite : MonoBehaviour {

    // Class to create a 2D image based on the values of IMixedDrink or IPatron
    // Will search all components of a game object

    public Transform[] drink2DImages;

    Garnish theGarnish;
    float[] drinkLevel;

    bool isPatron = false;
    
    void Start () {
        
        IPatron patron = transform.root.GetComponentInChildren<IPatron>();

        if (patron != null)
        {
            isPatron = true;
            Debug.Log("Do Patron logic");
        }
	}

    public void UpdateImage(IMixedDrink theDrink)
    {
        float[] drinkLevel = new float[6] { theDrink.Vodka, theDrink.Whiskey, theDrink.Rum, theDrink.Coke, theDrink.Soda, theDrink.Vermouth };
        theGarnish = theDrink.TheGarnish;
        SetImage(drinkLevel);
    }


    void SetImage(float[] drinkLevel)
    {
        // Initialize level of all liquids to the bottom of the glass
        for (int i = 0; i < 6; i++)
        {
            drink2DImages[i].localPosition = new Vector3(0, -2.8f, 0);  // the -2.8f offsets the drink level to the bottom of the glass
        }
        
        // This loop sets a particular drink level and every level behind it to the same level
        for (int i = 0; i < 6; i++)
        {
            for (int j = i; j < 6; j++)
                drink2DImages[j].localPosition += new Vector3 (0, ((drinkLevel[i] * 2.8f)), 0);
        }

        // Remove all garnishes
        for (int i = 6; i < 9; i++)
        {
            drink2DImages[i].GetComponent<SpriteRenderer>().enabled = false;
        }

        drink2DImages[(int)theGarnish + 6].GetComponent<SpriteRenderer>().enabled = true;
    }
}
