using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDDrinkObject : MonoBehaviour {

    public GameObject[] glasses;
    public Material[] fluidMaterials;
    public GameObject[] garnishes;

	// Use this for initialization
	void Start () {
        Drink thisDrink = GetComponent<Drink>();
        GameObject newDrink;

        if (thisDrink.Vodka > thisDrink.Whiskey && thisDrink.Vodka > thisDrink.Rum)
        {
            newDrink = Instantiate(glasses[1], transform);
        } else if (thisDrink.Rum > thisDrink.Whiskey && thisDrink.Rum > thisDrink.Vodka)
        {
            newDrink = Instantiate(glasses[2], transform);
        } else
        {
            newDrink = Instantiate(glasses[0], transform);
        }


        Material fluidMaterial;

        if (thisDrink.Coke > thisDrink.Soda && thisDrink.Coke > thisDrink.Vermouth)
        {
            fluidMaterial = fluidMaterials[1];
        } else if (thisDrink.Vermouth > thisDrink.Soda && thisDrink.Vermouth > thisDrink.Coke)
        {
            fluidMaterial = fluidMaterials[2];
        } else
        {
            fluidMaterial = fluidMaterials[0];
        }


        FluidColor[] fluids = newDrink.GetComponentsInChildren<FluidColor>();
        
        foreach (FluidColor colors in fluids)
        {
            Renderer renderer = colors.GetComponent<Renderer>();
            renderer.material = fluidMaterial;
        }


        Transform garnishLoc = newDrink.GetComponentInChildren<GarnishLocation>().transform;
        

        if (thisDrink.TheGarnish == Garnish.Lime)
            Instantiate(garnishes[0], garnishLoc);
        if (thisDrink.TheGarnish == Garnish.Cherry)
            Instantiate(garnishes[1], garnishLoc);
        if (thisDrink.TheGarnish == Garnish.Olive)
            Instantiate(garnishes[2], garnishLoc);

    }
	
	
}
