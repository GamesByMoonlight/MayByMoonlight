using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMixedDrink {
    GameObject gameObject { get; }
    float Whiskey { get; set; }
    float Rum { get; set; }
    float Vodka { get; set; }
    float Soda { get; set; }
    float Coke { get; set; }
    float Vermouth { get; set; }
    Garnish TheGarnish { get; set; }
    int Lane { get; set; }
    bool IsJustWater { get; set; } 
}

public enum Garnish
{
    Lime, Cherry, Olive
}