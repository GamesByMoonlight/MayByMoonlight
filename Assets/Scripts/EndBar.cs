using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBar : MonoBehaviour {

    public ScoreDisplay scoreDisplay;
    public int ScorePenalty = 5;
    public int BucksPenalty= 5;


    void OnTriggerEnter(Collider col )
    {
        if (col.GetComponent<IPatron>() != null)
        {
            Destroy(col.gameObject);
            
            scoreDisplay.SubtractBucks(BucksPenalty);
            scoreDisplay.SubtractScore(ScorePenalty);


        }

    }
}
