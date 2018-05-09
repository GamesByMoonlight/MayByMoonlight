using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Button : MonoBehaviour
{
    public enum Type
    {
        rum,
        vodka,
        whiskey,
        soda,
        vermouth,
        cola,
        cherry,
        lime,
        olive,
        water,
        cancel
    };

    public scr_levelManager levelManager;
    public Type myType;
    private string myName;

	// Use this for initialization
	void Start () 
    {
        myName = myType.ToString();
    }

    public void PourDrink(string typeOfDrink)
    {
        if (typeOfDrink != levelManager.drinkType)
            levelManager.drinkAmount = 0;
        levelManager.drinkType = typeOfDrink;
        levelManager.addDrink = true;
    }

    public void PourMixer(string typeOfMixer)
    {
        if (typeOfMixer != levelManager.mixerType)
            levelManager.mixerAmount = 0;
        levelManager.mixerType = typeOfMixer;
        levelManager.addMixer = true;
    }

    public void AddGarnish(string typeOfGarnish)
    {
        levelManager.hasGarnish = true;
        levelManager.garnishType = typeOfGarnish;
    }

    public void StopPour()
    {
        levelManager.addDrink = false;
        levelManager.addMixer = false;
    }

    public void Reset()
    {
        Debug.Log("reset");
    }

}
