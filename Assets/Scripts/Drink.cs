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

	// Use this for initialization
	void Start () {
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
	
}

public enum Garnish
{
    Lime, Cherry, Olive
}