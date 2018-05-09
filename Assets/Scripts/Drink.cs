using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour {
    public int Lane = 0;
    public float Whiskey = 0f;
    public float Vodka = 0f;
    public float Rum = 0f;
    public float Soda = 0f;
    public float Coke = 0f;
    public float Vermouth = 0f;
    public Garnish TypeOfGarnish = Garnish.Lime;
    public bool IsJustWater = false;

	// Use this for initialization
	void Start () {
        if (IsJustWater)
        {
            Debug.Log("Lane: " + Lane + ". I am just water");
            return;
        }
        Debug.Log("Down Lane: " + Lane + ". I am a drink of type (Vodka, Whiskey, Rum | Coke, Soda, Vermouth | Garnish): {" +
                  Vodka + ", " +
                  Whiskey + ", " +
                  Rum + " | " +
                  Coke + ", " +
                  Soda + ", " +
                  Vermouth + " | " +
                  TypeOfGarnish +
                  "}");
	}

    public void SetValues(Drink input)
    {
        this.Whiskey = input.Whiskey;
        this.Vodka = input.Vodka;
        this.Rum = input.Rum;
        this.Soda = input.Soda;
        this.Coke = input.Coke;
        this.Vermouth = input.Vermouth;
        this.TypeOfGarnish = input.TypeOfGarnish;
        this.IsJustWater = input.IsJustWater;
        //this. = input.;

    }
}