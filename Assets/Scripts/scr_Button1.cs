using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Button1 : MonoBehaviour, IButton
{
    public Sprite[] mySprites;
    public scr_levelManager levelManager;
    public enum Type
    {
        rum,
        cola,
        cherry
    };
    private string myName;
    public Type myType;

	// Use this for initialization
	void Start () 
    {
        levelManager = GetComponent<scr_levelManager>();
        myName = "Button1";
        myType = Type.rum;
	}
	
    public void Clicked()
    {
        if (levelManager.currentState == scr_levelManager.State.baseDrink)
        {
            levelManager.drinkType = "rum";
        }
        Debug.Log("clicked");
    }
    public void Switch()
    {
        Debug.Log("clicked");
    }
    public void Reset()
    {
        Debug.Log("clicked");
    }

}
