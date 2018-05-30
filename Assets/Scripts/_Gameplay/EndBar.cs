using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndBar : MonoBehaviour {

    public ScoreDisplay scoreDisplay;
    public GameObject tipPrefab;
    public int ScorePenalty = 5;
    public int BucksPenalty= 5;


    void OnTriggerEnter(Collider col )
    {
        if (col.GetComponent<IPatron>() != null)
        {
            Destroy(col.gameObject);
            
            scoreDisplay.SubtractBucks(BucksPenalty);
            scoreDisplay.SubtractScore(ScorePenalty);

            DisplayPenalty(col.transform);
        }
        else if(col.GetComponent<PatronDrinkCollector>() != null)
        {
            Destroy(col.transform.parent.gameObject);
            scoreDisplay.SubtractBucks(BucksPenalty);
            scoreDisplay.SubtractScore(ScorePenalty);

            DisplayPenalty(col.transform.parent.transform);
        }

    }

    void DisplayPenalty(Transform patronPosition)
    {
        GameObject newDisplay = Instantiate(tipPrefab, patronPosition.position, Quaternion.identity);
        Text text = newDisplay.GetComponentInChildren<Text>();
        text.text = "-" + BucksPenalty.ToString();
        text.color = Color.red;
        Debug.Log("Patron destroyed at position " + patronPosition.position);
    }
}
