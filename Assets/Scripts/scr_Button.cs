using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Button : MonoBehaviour
{
    public scr_levelManager levelManager;

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

        switch(typeOfGarnish)
        {
            case "Olive":
                levelManager.garnishType = Garnish.Olive;
                break;
            case "Cherry":
                levelManager.garnishType = Garnish.Cherry;
                break;
            case "Lime":
                levelManager.garnishType = Garnish.Lime;
                break;
        }

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
