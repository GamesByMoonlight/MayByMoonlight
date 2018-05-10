using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPatron {
    float MoveSpeed { get;   }
    int TipRate { get;  }
    int ScoreRate { get;  }
    float SeenEverySeconds { get; }

    void ReceiveDrink(GameObject T);
}
