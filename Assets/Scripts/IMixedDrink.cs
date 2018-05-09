using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMixedDrink {
    GameObject gameObject { get; }
    float Whiskey { get; }
    float Rum { get; }
    float Vodka { get; }
    float Soda { get; }
    float Coke { get; }
    float Vermouth { get; }
    Garnish TheGarnish { get; }
    int Lane { get; }
    bool IsJustWater { get; } 
}

public enum Garnish
{
    Lime, Cherry, Olive
}