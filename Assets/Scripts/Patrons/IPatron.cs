using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPatron {
    float MoveSpeed { get;   }
    int TipRate { get;  }
    int ScoreRate { get;  }
    float SeenEverySeconds { get; }
    AlcoholPref TheAlcoholPref { get; }
    MixerPref TheMixerPref { get; }
    Garnish TheGarnish { get; }


    void ReceiveDrink(GameObject T);




}

public enum AlcoholPref
{
    Whiskey, Vodka, Rum
}

public enum MixerPref
{
    Soda, Coke, Vermouth
}
