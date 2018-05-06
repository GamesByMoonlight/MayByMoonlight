using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMixedDrink {

    float Whiskey { get; }
    float Rum { get; }
    float Vodka { get; }
    float Soda { get; }
    float Coke { get; }
    float Vermouth { get; }
    int Lane { get; }
    bool IsJustWater { get; } 
}
