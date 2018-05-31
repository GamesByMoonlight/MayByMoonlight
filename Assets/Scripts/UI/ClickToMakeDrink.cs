using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMakeDrink : MonoBehaviour {
    public scr_levelManager LevelManager;
    public int Lane;

    private void OnMouseDown()
    {
        LevelManager.MakeDrinkAtLane(Lane);
    }
}
