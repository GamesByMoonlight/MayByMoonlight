using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ScoreReporter : MonoBehaviour {

    public ScoreDisplay ScoreDisplay;

    private Dictionary<string, object> parameters = new Dictionary<string, object>();

    void Start() {
        GameEventSystem.Instance.GameEnded.AddListener(GameOverListener);
        parameters.Add("Score", 0);
    }

    void GameOverListener()
    {
        parameters["Score"] = ScoreDisplay.Score;
        AnalyticsEvent.Custom("HighScore", parameters);
        //Debug.Log("Reporting score of " + parameters["Score"]);
    }

    private void OnDestroy()
    {
        if (GameEventSystem.Instance != null)
        {
            GameEventSystem.Instance.GameEnded.RemoveListener(GameOverListener);
        }
    }

}
