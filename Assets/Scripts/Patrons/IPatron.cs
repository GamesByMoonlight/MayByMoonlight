using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPatron {
    float MoveSpeed { get;   }
    int TipRate { get;  }
    int ScoreRate { get;  }

    void ReceiveDrink(GameObject T);
}
