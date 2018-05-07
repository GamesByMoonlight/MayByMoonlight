using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_levelManager : MonoBehaviour 
{
    public enum State
    {
        menu,
        baseDrink,
        mixer,
        garnish,
        serving
    };
    public State currentState;
    public int myMoney;
    public int myXp;

    public string drinkType;
    public string mixerType;
    public string garnishType;

	// Use this for initialization
	void Start () 
    {
        currentState = State.menu;
        StartRound();
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    void BuildDrink()
    {
        
    }

    void StartRound()
    {
        currentState = State.baseDrink;
    }
}
