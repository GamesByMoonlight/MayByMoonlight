using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnifiedInputController : MonoBehaviour, IMixedDrink {
    public GameObject KeyboardController;
    public GameObject MouseController;

    IMixedDrink keyboard, mouse;
    float whiskey, rum, vodka, soda, coke, vermouth;
    Garnish garnish;
    int lane;


    public float Whiskey { get { return whiskey; } set { keyboard.Whiskey = value; mouse.Whiskey = value; } }
    public float Rum { get { return rum; } set { keyboard.Rum = value; mouse.Rum = value; } }
    public float Vodka { get { return vodka; } set { keyboard.Vodka = value; mouse.Vodka = value; } }
    public float Soda { get { return soda; } set { keyboard.Soda = value; mouse.Soda = value; } }
    public float Coke { get { return coke; } set { keyboard.Coke = value; mouse.Coke = value; } }
    public float Vermouth { get { return vermouth; } set { keyboard.Vermouth = value; mouse.Vermouth = value; } }
    public Garnish TheGarnish { get { return garnish; } set { keyboard.TheGarnish = value; mouse.TheGarnish = value; } }
    public bool IsJustWater { get { return false; } set { Debug.Log("Controller water value set (does nothing) " + value); } }
    public int Lane { get { return lane; } set { keyboard.Lane = value; mouse.Lane = value; } }

    private void Start()
    {
        keyboard = KeyboardController.GetComponent<IMixedDrink>();
        mouse = MouseController.GetComponent<IMixedDrink>();
        ClearValues();
        GameEventSystem.Instance.DrinkMade.AddListener(DrinkMadeListener);
    }

    void Update()
    {
        TakeLargerValues(keyboard, mouse);
        TakeLargerValues(mouse, keyboard);

        if (garnish != mouse.TheGarnish)    // Always take mouse garnish value if different
            garnish = mouse.TheGarnish;
        if (lane != keyboard.Lane)          // Always take keyboard lane if different
            lane = keyboard.Lane;
    }

    void TakeLargerValues(IMixedDrink fromThis, IMixedDrink intoThis)
    {
        if(fromThis.Whiskey > intoThis.Whiskey)
        {
            whiskey = fromThis.Whiskey;
            intoThis.Whiskey = fromThis.Whiskey;
        }
        if (fromThis.Rum > intoThis.Rum)
        {
            rum = fromThis.Rum;
            intoThis.Rum = fromThis.Rum;
        }
        if (fromThis.Vodka > intoThis.Vodka)
        {
            vodka = fromThis.Vodka;
            intoThis.Vodka = fromThis.Vodka;
        }
        if (fromThis.Soda > intoThis.Soda)
        {
            soda = fromThis.Soda;
            intoThis.Soda = fromThis.Soda;
        }
        if (fromThis.Coke > intoThis.Coke)
        {
            coke = fromThis.Coke;
            intoThis.Coke = fromThis.Coke;
        }
        if (fromThis.Vermouth > intoThis.Vermouth)
        {
            vermouth = fromThis.Vermouth;
            intoThis.Vermouth = fromThis.Vermouth;
        }
    }

    void DrinkMadeListener(GameObject drink)
    {
        var mixedDrink = drink.GetComponent<IMixedDrink>();

        lane = mixedDrink.Lane;
        keyboard.Lane = mixedDrink.Lane;
        mouse.Lane = mixedDrink.Lane;

        garnish = mixedDrink.TheGarnish;
        keyboard.TheGarnish = mixedDrink.TheGarnish;
        mouse.TheGarnish = mixedDrink.TheGarnish;

        ClearValues();
    }

    void ClearValues()
    {
        whiskey = 0f;
        rum = 0f;
        vodka = 0f;
        soda = 0f;
        coke = 0f; 
        vermouth = 0f;
    }

    private void OnDestroy()
    {
        if (GameEventSystem.Instance != null)
            GameEventSystem.Instance.DrinkMade.RemoveListener(DrinkMadeListener);
    }
}
